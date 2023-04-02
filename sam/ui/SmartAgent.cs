﻿using Microsoft.CognitiveServices.Speech.Diagnostics.Logging;
using Microsoft.VisualBasic.Devices;
using Microsoft.Web.WebView2.Core;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using sam.audio;
using sam.gpt;
using sam.helper;
using System;
using System.Data;
using System.Diagnostics;
using System.Formats.Tar;
using System.IO;
using System.Security.Policy;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;
using System.Timers;
using System.Xml;
using WeifenLuo.WinFormsUI.Docking;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace sam
{
    public partial class SmartAgent : DockContent
    {
        public AgentSettings? currentAgentSettings { get; private set; }
        internal Conversation conversation { get; private set; }
        public SAM parentSAM { get; }
        public bool ttsActive { get; private set; }
        public string ttsSelectedVoice { get; private set; }
        public bool micActive { get; private set; }
        public bool bAssistantSpeaking { get; private set; }
        public bool audioRecordingActive { get; private set; }
        internal MicOutput micOutput { get; private set; }
        public int SelectedPlaybackDevice1 { get; private set; }
        public string selectedAudioDeviceForRecognition { get; private set; }
        public bool compActive { get; private set; }
        public string computerAudioFilename { get; private set; }
        public WasapiLoopbackCapture computerAudioCapture { get; private set; }
        public SpeechRecognitionService speechRecognitionService { get; private set; }
        public WaveFileWriter computerAudioWriter { get; private set; }
        public NAudioStream computerAudioStream { get; private set; }
        public string computerAudioFilenameToBeAnalyzed { get; private set; }
        public bool isRecording { get; private set; }
        public bool isTimerRunning { get; private set; }
        public bool speakerActive { get; private set; }
        public bool bNewBytesRecoded { get; private set; }
        public float focustemperature { get; private set; } = 1;

        private List<InstalledVoice> _installedVoices;
        // Construct a new SmartAgent instance with the specified AgentSettings and SAM objects
        public SmartAgent(AgentSettings? selectedAgentSettings = null, SAM sAM = null)
        {
            InitializeComponent();
            parentSAM = sAM;
            LoadAgentSettings(selectedAgentSettings);
            LoadSlaveAgents();
            LoadTTSVoices();
            LoadAudioSettings();
            InitializeAsync();
        }
        async void InitializeAsync()
        {
            await webView21.EnsureCoreWebView2Async(null);
            //webView21.CoreWebView2.WebMessageReceived += UpdateAddressBar;
        }
        //void UpdateAddressBar(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        //{
        //    String uri = args.TryGetWebMessageAsString();
        //    txtAddress.Text = uri;
        //    webView21.CoreWebView2.PostWebMessageAsString(uri);
        //}

        private void LoadAudioSettings()
        {
            var playbackSources = new List<WaveOutCapabilities>();
            var loopbackSources = new List<WaveInCapabilities>();

            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                playbackSources.Add(WaveOut.GetCapabilities(i));
            }

            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                loopbackSources.Add(WaveIn.GetCapabilities(i));
            }

            cmbSpeaker.Items.Clear();
            cmbMicLoop.Items.Clear();


            foreach (var source in playbackSources)
            {
                cmbSpeaker.Items.Add(source.ProductName);

            }


            SelectedPlaybackDevice1 = -1;


            if (cmbSpeaker.Items.Count > 0)
            {
                SelectedPlaybackDevice1 = -1;
            }

            foreach (var source in loopbackSources)
            {
                cmbMicLoop.Items.Add(source.ProductName);
            }

            cmbMicLoop.SelectedIndex = -1;


            // Get all the audio devices
            var devices = new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            foreach (var device in devices)
            {
                cmbAudioSource.Items.Add(device.FriendlyName);
            }

            cmbAudioSource.SelectedIndex = -1;


        }

        // Load the specified AgentSettings or generate a random one, populate the corresponding form fields,
        // create a new Conversation object, and display the chat history in the chat window
        private void LoadAgentSettings(AgentSettings? selectedAgentSettings)
        {
            if (selectedAgentSettings == null)
            {
                selectedAgentSettings = new AgentSettings
                {
                    AgentName = GenerateRandomAgentName(),
                    AgentID = Guid.NewGuid().ToString(),
                    AgentPersonality = SamUserSettings.Default.DefaultAgentPersonality,
                    SlaveAgents = new List<AgentSettings>(),
                    SlaveAgentMessage = txtSlaveMessage.Text,
                    AgentEnforcer = txtAgentRoleEnforcer.Text,
                    AgentFocus = trackTemp.Value,
                    AgentSystem = txtSystem.Text,

                };
            }

            txtAgentPersonality.Text = selectedAgentSettings.AgentPersonality;
            txtAgentName.Text = selectedAgentSettings.AgentName;
            txtAgentID.Text = selectedAgentSettings.AgentID;
            txtSlaveMessage.Text = selectedAgentSettings.SlaveAgentMessage;
            txtSystem.Text = selectedAgentSettings.AgentSystem;
            txtAgentRoleEnforcer.Text = selectedAgentSettings.AgentEnforcer;
            trackTemp.Value = selectedAgentSettings.AgentFocus;

            // Create a new Conversation object with the specified API key, system personality, and agent ID
            List<string> userPersonality = new List<string> { };

            userPersonality.Add(txtAgentPersonality.Text);

            List<string> systemUserPersonality = new List<string> { };

            systemUserPersonality.Add(txtSystem.Text);

            List<string> roleEnforcer = new List<string> { };

            roleEnforcer.Add(txtAgentRoleEnforcer.Text);

            conversation = new Conversation(SamUserSettings.Default.GPT_API_KEY, systemUserPersonality, userPersonality, roleEnforcer, txtAgentID.Text, ConvertToFloat(trackTemp.Value));

            // Display the chat history in the chat window, with user input in green and GPT input in blue
            foreach (var chat in conversation.chatHistory)
            {
                AppendTextToChatAsync(chat.Content, chat.Role == "user" ? Color.Green : Color.Blue);
            }

            this.currentAgentSettings = selectedAgentSettings;

        }

        public float ConvertToFloat(int x)
        {
            float result = 0.0f;

            if (x < 0)
            {
                result = 0.1f * Math.Abs(x);
            }
            else
            {
                result = 0.1f * x + 1.0f;
            }

            return result;
        }


        // Load the available text-to-speech voices and populate the corresponding form fields
        private void LoadTTSVoices()
        {
            // Create a new SpeechSynthesizer object
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                // Inject OneCore voices into the SpeechSynthesizer, if applicable
                SpeechApiReflectionHelper.InjectOneCoreVoices(synth);

                // Add each installed voice name to the dropdown menu and set the default selection
                foreach (var voice in synth.GetInstalledVoices())
                {
                    ttsVoice.Items.Add(voice.VoiceInfo.Name);
                    ttsVoice.Text = voice.VoiceInfo.Name;
                    ttsSelectedVoice = voice.VoiceInfo.Name;
                }
            }
        }

        private void LoadSlaveAgents()
        {
            AgentSettingsManager agentSettingsManager = new AgentSettingsManager();

            var slaveAgents = agentSettingsManager.LoadAgentSettings();
            var agentSetting = agentSettingsManager.LoadAgentSetting(currentAgentSettings.AgentName);
            if (slaveAgents != null)
            {
                foreach (var slaveAgent in slaveAgents)
                {

                    checkedListSelectedSlaves.Items.Add(slaveAgent.AgentName);
                }
                if (agentSetting.SlaveAgents != null)
                {
                    var itemsToCheck = new List<object>(); // create a new list to hold the items that need to be checked
                    foreach (var agentSlave in agentSetting.SlaveAgents)
                    {
                        foreach (var availableSlaves in checkedListSelectedSlaves.Items)
                        {
                            if (agentSlave.AgentName == availableSlaves.ToString())
                            {
                                itemsToCheck.Add(availableSlaves); // add the item to the list of items to check
                            }
                        }
                    }
                    foreach (var item in itemsToCheck)
                    {
                        checkedListSelectedSlaves.SetItemChecked(checkedListSelectedSlaves.Items.IndexOf(item), true); // check the items outside of the loop
                    }
                }
            }

        }

        private void SmartAgent_Load(object sender, EventArgs e)
        {

        }

        private string GenerateRandomAgentName()
        {
            // Create an array of twenty possible agent name options
            string[] agentNames = new string[] { "Alex", "Avery", "Brooke", "Cameron", "Dakota", "Jordan", "Morgan", "Riley", "Taylor", "Logan", "Evelyn", "Madison", "Peyton", "Sydney", "Bailey", "Reagan", "Charlie", "Hayden", "Harper", "Parker", "Ariel", "Phoenix", "Rowan", "Sage", "Aspen", "Emerson", "Dallas", "Skyler", "Casey", "Kendall", "Cassidy" };

            // Generate a random number between 0 and 19 to select a random agent name from the array
            int index = new Random().Next(0, 20);

            // Return the selected agent name
            return agentNames[index];
        }

        private void btnSaveAgent_Click(object sender, EventArgs e)
        {
            SaveAgentSettings();
        }

        private void SaveAgentSettings()
        {

            AgentSettingsManager agentSettingsManager = new AgentSettingsManager();

            // Create a new agent settings object
            AgentSettings agentSettings = new AgentSettings
            {
                AgentName = txtAgentName.Text,
                AgentID = txtAgentID.Text,
                AgentPersonality = txtAgentPersonality.Text,
                AgentSystem = txtSystem.Text,
                AgentEnforcer = txtAgentRoleEnforcer.Text,
                AgentFocus = trackTemp.Value,
                SlaveAgentMessage = txtSlaveMessage.Text
            };

            List<AgentSettings> slaveAgents = new List<AgentSettings>();
            foreach (string slave in checkedListSelectedSlaves.CheckedItems)
            {
                slaveAgents.Add(agentSettingsManager.LoadAgentSetting(slave));
            }
            agentSettings.SlaveAgents = slaveAgents;
            agentSettingsManager.SaveAgentSettings(agentSettings);

            MessageBox.Show("Agent settings saved.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Task.Run(() => SendUserConversationMessageAsync());

        }

        private async Task AppendTextToChatAsync(string text, Color color)
        {
            // Set the color of the text that will be appended
            txtChat.SelectionColor = color;

            // Append the text to the control
            txtChat.AppendText(text);
            txtCode.AppendText(text);

            if (ttsActive)
            {
                if (SamUserSettings.Default.AZURE_API_KEY != "" && SamUserSettings.Default.AZURE_TTS_REGION != "" && SamUserSettings.Default.AZURE_TTS_VOICE != "")
                {
                    if (color == Color.Blue)
                    {
                        bAssistantSpeaking = true;
                        await SpeakAzureTextAsync(text);
                        bAssistantSpeaking = false;
                    }
                }
                else
                {
                    if (color == Color.Blue) { await SpeakTextAsync(text); }
                }

            }

            // Add a new line
            txtChat.AppendText(Environment.NewLine);
            txtChat.AppendText(Environment.NewLine);
            txtChat.ScrollToCaret();

            // Add a new line
            txtCode.AppendText(Environment.NewLine);
            txtCode.AppendText(Environment.NewLine);
        }

        private async Task SpeakAzureTextAsync(string text)
        {
            AzureTextToSpeech azureTTS = new AzureTextToSpeech(SamUserSettings.Default.AZURE_API_KEY, SamUserSettings.Default.AZURE_TTS_REGION, SamUserSettings.Default.AZURE_TTS_VOICE);
            await azureTTS.SynthesizeAsync(text);
        }

        private async Task SendUserConversationMessageAsync(bool requiresResponse = true)
        {
            Invoke((Action)(() => StartAnalysis()));

            if (conversation == null || this.currentAgentSettings.AgentPersonality != txtAgentPersonality.Text)
            {
                List<string> userPersonality = new List<string> { };

                userPersonality.Add(txtAgentPersonality.Text);

                List<string> systemUserPersonality = new List<string> { };

                systemUserPersonality.Add(txtSystem.Text);

                List<string> roleEnforcer = new List<string> { };

                roleEnforcer.Add(txtAgentRoleEnforcer.Text);

                conversation = new Conversation(SamUserSettings.Default.GPT_API_KEY, systemUserPersonality, userPersonality, roleEnforcer, txtAgentID.Text, ConvertToFloat(trackTemp.Value));

            }

            if (txtUserInput.Text != "")
            {
                string userInput = txtUserInput.Text;

                // Append the user's input to the chat with green text
                Invoke((Action)(() => AppendTextToChatAsync(userInput, Color.Green)));

                // Clear the user input field
                Invoke((Action)(() => txtUserInput.Text = ""));

                // Start the conversation and append the system's response with blue text
                List<string> response = await conversation.StartConversation(userInput, requiresResponse, focustemperature);

                foreach (string s in response)
                {
                    Invoke((Action)(() => AppendTextToChatAsync(s, Color.Blue)));
                }

                if (chkSmartAgentEnabled.Checked)
                {
                    Invoke((Action)(() => SendSmartAgentResponseToSlaves(response)));
                }
            };

            // Raise the AnalysisComplete event
            Invoke((Action)(() =>
            {
                OnAnalysisComplete();
                txtUserInput.Focus();
            }));
        }

        private void SendSmartAgentResponseToSlaves(List<string> response)
        {
            AgentSettingsManager agentSettingsManager = new AgentSettingsManager();
            List<AgentSettings> slaveAgents = new List<AgentSettings>();
            foreach (string slave in checkedListSelectedSlaves.CheckedItems)
            {
                slaveAgents.Add(agentSettingsManager.LoadAgentSetting(slave));
            }
            foreach (SmartAgent slave in parentSAM.activeSmartAgents)
            {
                foreach (AgentSettings agentSettings in slaveAgents)
                {
                    if (slave.currentAgentSettings.AgentName == agentSettings.AgentName)
                    {
                        slave.SendSlaveMessageAsync(txtSlaveMessage.Text + String.Join(" ", response));
                    }
                }
            }


        }

        private async Task SendSlaveMessageAsync(string slaveMessage)
        {
            if (chkSmartAgentEnabled.Checked)
            {
                txtUserInput.Text = slaveMessage;
                await SendUserConversationMessageAsync();
            }
        }

        private void SmartAgent_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentSAM.activeSmartAgents.Remove(this);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            if (conversation != null)
            {
                conversation.ClearChatHistory();
                conversation = null;
            }
            txtChat.Text = "";
            txtCode.SelectAll();
            txtCode.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new instance of the OpenFileDialog class
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to only allow WAV files
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3";

            // Set the initial directory to the recordings directory
            openFileDialog.InitialDirectory = Path.Combine(Environment.CurrentDirectory, "rec");

            // Show the file dialog and wait for the user to select a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path and do something with it
                string selectedFilePath = openFileDialog.FileName;

                // Start the analysis task on a background thread
                Task.Run(() => AnalyzeAudioAsync(selectedFilePath));

            }

        }


        private void OnAnalysisComplete()
        {
            agentStatusLabel.Text = "Ready";
            agentProgress.Visible = false;
        }

        private void StartAnalysis()
        {
            agentStatusLabel.Text = "Analyzing";
            agentProgress.Visible = true;
        }

        private async Task AnalyzeAudioAsync(string selectedFilePath)
        {
            Invoke((Action)(() =>
            {
                StartAnalysis();
            }));
            if (conversation == null)
            {
                List<string> userPersonality = new List<string> { };

                userPersonality.Add(txtAgentPersonality.Text);

                List<string> systemUserPersonality = new List<string> { };

                systemUserPersonality.Add(txtSystem.Text);

                List<string> roleEnforcer = new List<string> { };

                roleEnforcer.Add(txtAgentRoleEnforcer.Text);

                conversation = new Conversation(SamUserSettings.Default.GPT_API_KEY, systemUserPersonality, userPersonality, roleEnforcer, txtAgentID.Text, ConvertToFloat(trackTemp.Value));

                if (selectedFilePath != "")
                {

                    // Start the conversation and append the system's response with blue text
                    List<string> response = await conversation.AnalyzeAudio(selectedFilePath);
                    foreach (string s in response)
                    {
                        // Clear the user input field
                        Invoke((Action)(() =>
                        {
                            txtUserInput.Text = s;
                        }));
                        await SendUserConversationMessageAsync(false);
                    }

                    if (chkSmartAgentEnabled.Checked)
                    {
                        Invoke((Action)(() => { SendSmartAgentResponseToSlaves(response); }));

                    }
                };
            }
            else
            {
                if (selectedFilePath != "")
                {

                    // Start the conversation and append the system's response with blue text
                    List<string> response = await conversation.AnalyzeAudio(selectedFilePath);
                    foreach (string s in response)
                    {
                        Invoke((Action)(() => { AppendTextToChatAsync(s, Color.Blue); }));
                    }

                    if (chkSmartAgentEnabled.Checked)
                    {
                        Invoke((Action)(() => { SendSmartAgentResponseToSlaves(response); }));
                    }

                };
            }
            // Raise the AnalysisComplete event
            Invoke((Action)(() =>
            {
                OnAnalysisComplete();
            }));

        }

        private void btnTTS_Click(object sender, EventArgs e)
        {
            if (ttsActive)
            {
                btnTTS.Image = sam.Properties.Resources.mute_sound_speaker_volume_icon;
                ttsActive = false;
            }
            else
            {
                btnTTS.Image = sam.Properties.Resources.lound_sound_speaker_volume_icon;
                ttsActive = true;
            }
        }

        private async Task SpeakTextAsync(string speak)
        {
            try
            {


                // Initialize a new instance of the SpeechSynthesizer.  
                using (SpeechSynthesizer synth = new SpeechSynthesizer())
                {
                    SpeechApiReflectionHelper.InjectOneCoreVoices(synth);
                    foreach (var voice in synth.GetInstalledVoices())
                    {
                        Console.WriteLine(voice.VoiceInfo.Name);
                    }
                    // Set a value for the speaking rate.  
                    synth.Rate = 1;
                    synth.SelectVoice(ttsSelectedVoice);
                    // Configure the audio output.   
                    synth.SetOutputToDefaultAudioDevice();

                    // Create a prompt from a string.  
                    Prompt color = new Prompt(speak);

                    // Speak the contents of the prompt synchronously.  
                    synth.Speak(color);
                }
            }
            catch (Exception ex)
            {
                // Handle any other errors that may occur
                Debug.WriteLine($"Error in SpeakTextAsync: {ex.Message}");
            }
        }

        private void ttsVoice_TextChanged(object sender, EventArgs e)
        {
            ttsSelectedVoice = ttsVoice.Text;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (micActive)
            {
                toolStripButton1.Image = sam.Properties.Resources._9035019_mic_off_icon;
                micActive = false;
                loopback.micMute = true;
            }
            else
            {
                toolStripButton1.Image = sam.Properties.Resources._9036017_mic_sharp_icon;
                micActive = true;
                loopback.micMute = false;
                Task.Run(() => ActivateMicAsync());
            }
        }

        private async Task ActivateMicAsync()
        {
            var tts = new AzureTextToSpeech(SamUserSettings.Default.AZURE_API_KEY, SamUserSettings.Default.AZURE_TTS_REGION, SamUserSettings.Default.AZURE_TTS_VOICE);
            while (micActive)
            {
                while (bAssistantSpeaking) { Thread.Sleep(500); }
                if (micActive)
                {
                    var result = await tts.FromMicAsync();
                    Console.WriteLine($"RECOGNIZED: Text={result.Text}");
                    if (result.Text != "")
                    {
                        // Clear the user input field
                        Invoke((Action)(() =>
                        {
                            txtUserInput.Text = result.Text;
                        }));
                        await SendUserConversationMessageAsync();
                    }
                }
            }
        }

        private void SmartAgent_Shown(object sender, EventArgs e)
        {
            txtUserInput.Focus();
        }

        private void btnRecordComputerAudio_Click(object sender, EventArgs e)
        {
            if (audioRecordingActive)
            {
                btnRecordComputerAudio.Image = sam.Properties.Resources.sharp_sensors_off_black_24dp;
                audioRecordingActive = false;
                StopRecording();
            }
            else
            {
                btnRecordComputerAudio.Image = sam.Properties.Resources.sharp_sensors_black_24dp;
                audioRecordingActive = true;
                StartRecording();
            }
        }
        AudioLoopback loopback = new AudioLoopback();
        private void StartRecording()
        {
            //Subtract one from index to account for null entry.
            int captureDeviceNumber = cmbSpeaker.SelectedIndex;
            int playbackDeviceNumber = cmbMicLoop.SelectedIndex;

            loopback.StartLoopback(captureDeviceNumber, playbackDeviceNumber);

        }

        private void StopRecording()
        {
            loopback.StopLoopback();
        }

        private void btnPlayAudioToMic_Click(object sender, EventArgs e)
        {
            // Create a new instance of the OpenFileDialog class
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to only allow WAV files
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3";

            // Set the initial directory to the recordings directory
            openFileDialog.InitialDirectory = Path.Combine(Environment.CurrentDirectory, "rec");

            // Show the file dialog and wait for the user to select a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path and do something with it
                string selectedFilePath = openFileDialog.FileName;

                // Start the analysis task on a background thread
                Task.Run(() => AnalyzeAudioAsync(selectedFilePath));

            }
        }

        private void cmbSpeaker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnComputerAudioSTT_Click(object sender, EventArgs e)
        {

            if (compActive)
            {
                btnComputerAudioSTT.Image = sam.Properties.Resources._9055836_bxl_microsoft_teams_icon_off_24;
                compActive = false;
                speakerActive = false;
                StopCompRecording();
            }
            else
            {
                btnComputerAudioSTT.Image = sam.Properties.Resources._9055836_bxl_microsoft_teams_icon_24;
                compActive = true;
                speakerActive = true;
                StartCompRecording();
            }
        }

        public event EventHandler<string> RecordingEnded;
        public void OnRecordingEnded(object sender, string path)
        {
            Console.WriteLine("Recording ended: " + path);
            // Use the path to perform some action, such as sending the recorded file to a server or processing it locally.
        }

        int noDataTimeout = 30000; // 3 seconds timeout


        /// <summary>
        /// Starts recording computer audio using the WasapiLoopbackCapture class and saves the audio data to a WAV file.
        /// Audio levels are monitored and if the RMS level of the audio signal is above a specified threshold, recording is started.
        /// If the audio signal level remains below the threshold for a specified duration, recording is stopped.
        /// </summary>
        public void StartCompRecording()
        {
            // Create the directory for recordings if it does not exist
            Directory.CreateDirectory(@"rec");
            // Set initial values for recording and timer flags
            isRecording = true;

            // Get all the audio devices
            var devices = new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            MMDevice sourceDevice = null;

            foreach (var device in devices)
            {
                if (device.FriendlyName == cmbAudioSource.Text)
                {
                    sourceDevice = device;
                }
            }
            if (sourceDevice != null)
            {
                computerAudioFilename = string.Format(@"rec\recording-{0:yyyy-MM-dd-HH-mm-ss}-computerSTTAudio.wav", DateTime.Now);

                computerAudioCapture = new WasapiLoopbackCapture(sourceDevice);

                computerAudioWriter = new WaveFileWriter(new MemoryStream(), computerAudioCapture.WaveFormat);
                computerAudioStream = new NAudioStream();

                speechRecognitionService = new SpeechRecognitionService(SamUserSettings.Default.AZURE_API_KEY, SamUserSettings.Default.AZURE_TTS_REGION, computerAudioStream, computerAudioCapture.WaveFormat);

                // Start recording
                computerAudioCapture.StartRecording();
                computerAudioCapture.DataAvailable += async (sender, e) =>
                {
                    if (e.BytesRecorded > 0)
                    {
                        // Write data to computer audio
                        computerAudioStream.Write(e.Buffer, 0, e.BytesRecorded);
                    }
                };
                speechRecognitionService.TextRecognized += RecognizerService_TextRecognized;

                speechRecognitionService.RecognizeAsync();
            }
        }

        private void RecognizerService_TextRecognized(string text)
        {
            if (text != "")
            {
                // Clear the user input field
                Invoke((Action)(() =>
                {
                    txtUserInput.Text = text;
                }));
                SendUserConversationMessageAsync(false);
            }
        }


        public void StopCompRecording()
        {
            computerAudioFilenameToBeAnalyzed = computerAudioFilename;
            isRecording = false;
            if (computerAudioCapture != null)
            {
                speechRecognitionService.StopRecognizeAsync();
                computerAudioCapture.StopRecording();
                computerAudioWriter.Dispose();
                computerAudioCapture.Dispose();
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            NavigateToAsync(txtAddress.Text);
        }

        private async Task NavigateToAsync(string url)
        {

            var targetUrl = url.StartsWith("https://") ? url : "https://" + url;

            webView21.CoreWebView2.Navigate(targetUrl);


        }

        private void webView21_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {




        }

        private void webView21_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            this.txtAddress.Text = this.webView21.Source.AbsoluteUri;
            GetTextFromUrlAsync(this.txtAddress.Text);
        }

        private async Task GetTextFromUrlAsync(string targetUrl)
        {
            var webPageTextReader = new WebPageTextReader(targetUrl);
            var textList = await webPageTextReader.GetWebPageTextAsync(targetUrl);
            txtWebText.Clear();
            foreach (var txt in textList)
            {
                txtWebText.AppendText(txt);
                txtWebText.AppendText(Environment.NewLine);
                txtWebText.AppendText("================================");
                txtWebText.AppendText(Environment.NewLine);
            }
        }

        private void webView21_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {

        }

        private void trackTemp_Scroll(object sender, EventArgs e)
        {

        }

        private void trackTemp_ValueChanged(object sender, EventArgs e)
        {
            this.focustemperature = ConvertToFloat(trackTemp.Value);
        }
    }
}

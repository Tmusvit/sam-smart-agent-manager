using Microsoft.CognitiveServices.Speech.Diagnostics.Logging;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
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
using System.Windows.Forms;
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
        internal Conversation? conversation { get; private set; }
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
        public SmartAgent(AgentSettings? selectedAgentSettings = null, SAM? sAM = null, string? tagText = null)
        {
            InitializeComponent();
            parentSAM = sAM;
            LoadAgentSettings(selectedAgentSettings, tagText);
            LoadSlaveAgents();
            LoadTTSVoices();
            LoadAudioSettings();
            InitializeAsync();
            LoadChatMemoryDatabase();
        }

        private void LoadChatMemoryDatabase()
        {
            if (File.Exists("chat.db"))
            {
                // Connect to the database
                using (var connection = new SqliteConnection("Data Source=chat.db"))
                {
                    // Open the connection
                    connection.Open();

                    // Select records from the ChatHistory table
                    string selectsql = @"SELECT * FROM ChatMemory";

                    using (var cmd = new SqliteCommand(selectsql, connection))
                    {

                        using (var reader = cmd.ExecuteReader())
                        {
                            // Create a new DataTable to hold the retrieved records
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);

                            // Set the datagridview's DataSource property to the DataTable
                            dataPromptMemory.DataSource = dataTable;
                        }
                    }

                    // Close the connection
                    connection.Close();
                }
            }
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
        private void LoadAgentSettings(AgentSettings? selectedAgentSettings, string tagText)
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
            if (tagText != null)
            {
                txtUserInput.Text = tagText;
            }
            this.focustemperature = selectedAgentSettings.AgentFocus;
            txtAgentPersonality.Text = selectedAgentSettings.AgentPersonality;
            txtAgentName.Text = selectedAgentSettings.AgentName;
            txtAgentID.Text = selectedAgentSettings.AgentID;
            txtSlaveMessage.Text = selectedAgentSettings.SlaveAgentMessage;
            txtSystem.Text = selectedAgentSettings.AgentSystem;
            txtAgentRoleEnforcer.Text = selectedAgentSettings.AgentEnforcer;
            trackTemp.Value = selectedAgentSettings.AgentFocus;
            txtTemp.Text = ConvertToFloat(trackTemp.Value).ToString();
            this.Text = this.Text + " - " + txtAgentName.Text;
            // Create a new Conversation object with the specified API key, system personality, and agent ID
            List<string> userPersonality = new List<string> { };

            userPersonality.Add(txtAgentPersonality.Text);

            List<string> systemUserPersonality = new List<string> { };

            systemUserPersonality.Add(txtSystem.Text);

            List<string> roleEnforcer = new List<string> { };

            roleEnforcer.Add(txtAgentRoleEnforcer.Text);

            conversation = new Conversation(SamUserSettings.Default.GPT_API_KEY, systemUserPersonality, userPersonality, roleEnforcer, txtAgentID.Text, this.focustemperature);

            // Display the chat history in the chat window, with user input in green and GPT input in blue
            foreach (var chat in conversation.chatHistory)
            {
                if (chat.Role == "user")
                {
                    AppendTextToChatAsync(chat.Content, System.Drawing.Color.Green);
                }
                else
                {
                    AppendTextToChatAsync(chat.Content, System.Drawing.Color.Blue);
                }
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

            return (float)Math.Round(result, 1);
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
            txtChat.BackColor = Color.FromArgb(67, 70, 84);

        }

        private string GenerateRandomAgentName()
        {
            // Create an array of possible agent name options
            string[] agentNames = new string[] { "Alex", "Avery", "Brooke", "Cameron", "Dakota", "Jordan", "Morgan", "Riley", "Taylor", "Logan", "Evelyn", "Madison", "Peyton", "Sydney", "Bailey", "Reagan", "Charlie", "Hayden", "Harper", "Parker", "Ariel", "Phoenix", "Rowan", "Sage", "Aspen", "Emerson", "Dallas", "Skyler", "Casey", "Kendall", "Aiko", "Amara", "Anika", "Arjun", "Cai", "Dario", "Elio", "Emre", "Esme", "Fleur", "Gia", "Hana", "Ingrid", "Jia", "Kaida", "Kian", "Lila", "Luca", "Mika", "Niamh", "Noa", "Oskar", "Ravi", "Sari", "Soren", "Tala", "Thalia", "Yara", "Yuna", "Zara" };

            // Generate a random number between 0 and the length of the array to select a random agent name
            int index = new Random().Next(0, agentNames.Length);

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

        private async Task AppendTextToChatAsync(string text, System.Drawing.Color color)
        {
            if (color == System.Drawing.Color.Blue)
            {
                // Set the blue color to a brighter shade of blue
                color = System.Drawing.Color.FromArgb(0, 191, 255);

                // Set the font to a professional sans-serif font in bold
                txtChat.SelectionFont = new Font("Segoe UI", 10, FontStyle.Bold);

            }
            else if (color == System.Drawing.Color.Green)
            {
                // Set the green color to a brighter shade of green
                color = System.Drawing.Color.FromArgb(0, 255, 128);

                // Set the font to a professional sans-serif font in bold
                txtChat.SelectionFont = new Font("Segoe UI", 10, FontStyle.Bold);
            }
            else
            {
                // Set the font to a professional sans-serif font in regular weight
                txtChat.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
            }
            // Set the color of the text that will be appended
            txtChat.SelectionColor = color;

            // Append the text to the control
            txtChat.AppendText(text);
            txtCode.AppendText(text);

            if (ttsActive)
            {
                if (SamUserSettings.Default.AZURE_API_KEY != "" && SamUserSettings.Default.AZURE_TTS_REGION != "" && SamUserSettings.Default.AZURE_TTS_VOICE != "")
                {
                    if (color == System.Drawing.Color.Blue)
                    {
                        bAssistantSpeaking = true;
                        await SpeakAzureTextAsync(text);
                        bAssistantSpeaking = false;
                    }
                }
                else
                {
                    if (color == System.Drawing.Color.Blue) { await SpeakTextAsync(text); }
                }

            }

            // Add a new line
            txtChat.AppendText(Environment.NewLine);
            txtChat.AppendText(Environment.NewLine);
            txtChat.ScrollToCaret();

            // Add a new line
            txtCode.AppendText(Environment.NewLine);
            txtCode.AppendText(Environment.NewLine);
            UpdateDynamicChatDatabase();
        }

        private void UpdateDynamicChatDatabase()
        {
            if (File.Exists("chat.db"))
            {
                // Connect to the database
                using (var connection = new SqliteConnection("Data Source=chat.db"))
                {
                    // Open the connection
                    connection.Open();

                    // Select records from the ChatHistory table
                    string selectsql = @"SELECT * FROM ChatHistory WHERE AgentId = @agentId";

                    using (var cmd = new SqliteCommand(selectsql, connection))
                    {
                        cmd.Parameters.AddWithValue("@agentId", txtAgentID.Text);

                        using (var reader = cmd.ExecuteReader())
                        {
                            // Create a new DataTable to hold the retrieved records
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);

                            // Set the datagridview's DataSource property to the DataTable
                            dataDynamicPrompts.DataSource = dataTable;
                        }
                    }

                    // Close the connection
                    connection.Close();
                }
            }

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

                conversation = new Conversation(SamUserSettings.Default.GPT_API_KEY, systemUserPersonality, userPersonality, roleEnforcer, txtAgentID.Text, this.focustemperature);

            }

            if (txtUserInput.Text != "")
            {
                string userInput = txtUserInput.Text;

                // Append the user's input to the chat with green text
                Invoke((Action)(() => AppendTextToChatAsync(userInput, System.Drawing.Color.Green)));

                // Clear the user input field
                Invoke((Action)(() => txtUserInput.Text = ""));

                // Start the conversation and append the system's response with blue text
                List<string> response = await conversation.StartConversation(userInput, requiresResponse, focustemperature);

                foreach (string s in response)
                {
                    Invoke((Action)(() => AppendTextToChatAsync(s, System.Drawing.Color.Blue)));
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

                conversation = new Conversation(SamUserSettings.Default.GPT_API_KEY, systemUserPersonality, userPersonality, roleEnforcer, txtAgentID.Text, this.focustemperature);

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
                        Invoke((Action)(() => { AppendTextToChatAsync(s, System.Drawing.Color.Blue); }));
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

                        // Check if the user said the keyword
                        if (result.Text.ToLower().Contains(txtAgentName.Text.ToLower()))
                        {
                            await SendUserConversationMessageAsync();
                        }
                        else
                        {
                            await SendUserConversationMessageAsync(false);
                        }
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
            if (textList != null)
            {
                foreach (var txt in textList)
                {
                    txtWebText.AppendText(txt);
                    InsertTextToChatMemory(txt);
                    txtWebText.AppendText(Environment.NewLine);
                    txtWebText.AppendText("================================");
                    txtWebText.AppendText(Environment.NewLine);
                }
            }
            LoadChatMemoryDatabase();
        }

        private void InsertTextToChatMemory(string txt)
        {

            // Connect to the database
            using (var connection = new SqliteConnection("Data Source=chat.db"))
            {
                connection.Open();

                // Check if the text exists in the database
                using (var cmd = new SqliteCommand("SELECT COUNT(*) FROM ChatMemory WHERE Content = @Content AND AgentId=@AgentId", connection))
                {
                    cmd.Parameters.AddWithValue("@Content", txt);
                    cmd.Parameters.AddWithValue("@AgentId", txtAgentID.Text);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 0) // text exists, do not insert again
                    {
                        string insertSql = "INSERT INTO ChatMemory (AgentId, Role, Content) VALUES (@AgentId, @Role, @Content)";
                        using (var insertCmd = new SqliteCommand(insertSql, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@AgentId", txtAgentID.Text);
                            insertCmd.Parameters.AddWithValue("@Role", "assistant");
                            insertCmd.Parameters.AddWithValue("@Content", txt);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }

                connection.Close();
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
            txtTemp.Text = this.focustemperature.ToString();
        }

        private void btnLoadSharepoint_Click(object sender, EventArgs e)
        {


        }


        private void dataPromptMemory_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {




        }

        private void dataPromptMemory_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dataPromptMemory_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Get the index of the AgentId column
            int agentIdColumnIndex = dataPromptMemory.Columns["AgentId"].Index;

            // Check if the cell being edited is not the AgentId cell
            if (e.ColumnIndex != agentIdColumnIndex)
            {
                // Update the AgentId cell with the value from txtAgentID TextBox
                dataPromptMemory.Rows[e.RowIndex].Cells[agentIdColumnIndex].Value = txtAgentID.Text;
            }

        }

        private void dataPromptMemory_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            // Get the updated row from the DataGridView
            DataGridViewRow row = dataPromptMemory.Rows[e.RowIndex];

            // Check if the cell is not null before accessing its value
            if (row.Cells["ID"]?.Value != null && row.Cells["AgentId"]?.Value != null && row.Cells["Role"]?.Value != null && row.Cells["Content"]?.Value != null)
            {
                // Get the values of the updated row
                int id = Convert.ToInt32(row.Cells["ID"].Value);
                string AgentId = row.Cells["AgentId"].Value.ToString();
                string Role = row.Cells["Role"].Value.ToString();
                string Content = row.Cells["Content"].Value.ToString();

                // Connect to the database
                using (var connection = new SqliteConnection("Data Source=chat.db"))
                {
                    connection.Open();

                    // Check if the ID exists in the database
                    using (var cmd = new SqliteCommand("SELECT COUNT(*) FROM ChatMemory WHERE ID = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0) // ID exists, update the row
                        {
                            string updateSql = "UPDATE ChatMemory SET AgentId = @AgentId, Role = @Role, Content = @Content WHERE ID = @id";
                            using (var updateCmd = new SqliteCommand(updateSql, connection))
                            {
                                updateCmd.Parameters.AddWithValue("@AgentId", AgentId);
                                updateCmd.Parameters.AddWithValue("@Role", Role);
                                updateCmd.Parameters.AddWithValue("@Content", Content);
                                updateCmd.Parameters.AddWithValue("@id", id);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                        else // ID does not exist, insert new row
                        {
                            string insertSql = "INSERT INTO ChatMemory (ID, AgentId, Role, Content) VALUES (@id, @AgentId, @Role, @Content)";
                            using (var insertCmd = new SqliteCommand(insertSql, connection))
                            {
                                insertCmd.Parameters.AddWithValue("@id", id);
                                insertCmd.Parameters.AddWithValue("@AgentId", AgentId);
                                insertCmd.Parameters.AddWithValue("@Role", Role);
                                insertCmd.Parameters.AddWithValue("@Content", Content);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    connection.Close();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webView21.CoreWebView2.CanGoBack)
            {
                webView21.CoreWebView2.GoBack();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webView21.CoreWebView2.CanGoForward)
            {
                webView21.CoreWebView2.GoForward();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Reload();
        }

        private void dataPromptMemory_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Get the ID of the row to be deleted
            int id = Convert.ToInt32(e.Row.Cells["ID"].Value);

            // Connect to the database
            using (var connection = new SqliteConnection("Data Source=chat.db"))
            {
                connection.Open();

                // Delete the row from the database
                string deleteSql = "DELETE FROM ChatMemory WHERE ID = @id";
                using (var deleteCmd = new SqliteCommand(deleteSql, connection))
                {
                    deleteCmd.Parameters.AddWithValue("@id", id);
                    deleteCmd.ExecuteNonQuery();
                }

                connection.Close();
            }

        }

        private void contextMenuStripChat_ItemClickedAsync(object sender, ToolStripItemClickedEventArgs e)
        {
            // Check if the clicked item is the "Copy" option
            if (e.ClickedItem.Text == "Copy")
            {
                // Copy the selected text to the Clipboard
                Clipboard.SetText(txtChat.SelectedText);
            }
            // Check if the clicked item is the "Send" option
            if (e.ClickedItem.Text == "Send")
            {

                Invoke((Action)(() =>
                {
                    txtUserInput.Text = txtChat.SelectedText;
                }));
                SendUserConversationMessageAsync();
            }
        }
    }
}

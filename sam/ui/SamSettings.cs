﻿using Microsoft.VisualBasic.FileIO;
using sam.helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sam
{
    public partial class SamSettings : Form
    {
        // This function initializes the component of the SamSettings form.
        public SamSettings()
        {
            InitializeComponent();
        }

        // This function handles the save button click event and saves the user's entered API key and agent personality to the application settings.
        private void btnSaveAgent_Click(object sender, EventArgs e)
        {
            SamUserSettings.Default.GPT_API_KEY = txtApiKey.Text;
            SamUserSettings.Default.AZURE_API_KEY = txtAzureAPI.Text;
            SamUserSettings.Default.AZURE_TTS_REGION = txtTTSregion.Text;
            SamUserSettings.Default.AZURE_TTS_VOICE = cmbTTSVoice.Text;
            SamUserSettings.Default.AZURE_STT_LANG = cmbVoiceRecLang.Text;
            SamUserSettings.Default.DefaultAgentPersonality = txtAgentPersonality.Text;
            SamUserSettings.Default.Save();
        }

        // This function loads the saved settings from the user's last session and populates the API key and agent personality textboxes.
        private void SamSettings_Load(object sender, EventArgs e)
        {
            txtApiKey.Text = SamUserSettings.Default.GPT_API_KEY;
            txtAzureAPI.Text = SamUserSettings.Default.AZURE_API_KEY;
            txtTTSregion.Text = SamUserSettings.Default.AZURE_TTS_REGION;
            cmbTTSVoice.Text = SamUserSettings.Default.AZURE_TTS_VOICE;
            cmbVoiceRecLang.Text = SamUserSettings.Default.AZURE_STT_LANG;
            txtAgentPersonality.Text = SamUserSettings.Default.DefaultAgentPersonality;
        }

        // This function handles the reset button click event and clears the saved API key and agent personality settings, as well as the corresponding textboxes.
        private void btnReset_Click(object sender, EventArgs e)
        {
            SamUserSettings.Default.GPT_API_KEY = "";
            SamUserSettings.Default.DefaultAgentPersonality = "";
            SamUserSettings.Default.AZURE_API_KEY = "";
            SamUserSettings.Default.AZURE_TTS_REGION = "";
            SamUserSettings.Default.AZURE_TTS_VOICE = "";
            SamUserSettings.Default.AZURE_STT_LANG = "";
            SamUserSettings.Default.Save();
            txtApiKey.Text = "";
            txtAzureAPI.Text = "";
            txtAgentPersonality.Text = "";
        }
        public List<(string, string)> DownloadAndParseCsv(string agents)
        {
            // Get the path of the CSV file in the same directory as the executable
            string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvPath = Path.Combine(exePath, agents);

            // Load the CSV file
            List<(string, string)> prompts = new List<(string, string)>();
            using (TextFieldParser parser = new TextFieldParser(csvPath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (fields.Length >= 2)
                    {
                        string act = fields[0].Trim().Trim('"');
                        string prompt = fields[1].Trim().Trim('"').Replace("\\,", ",");
                        prompts.Add((act, prompt));
                    }
                }
            }

            return prompts;
        }
        private void btnLoadDefault_Click(object sender, EventArgs e)
        {
            if (SamUserSettings.Default.AgentSettingsFileLocation != null)
            {
                // Call the function to download and parse the CSV file
                List<(string, string)> prompts = DownloadAndParseCsv(SamUserSettings.Default.AgentSettingsFileLocation);

                // Print out the list of prompts
                foreach ((string act, string prompt) in prompts)
                {
                    AgentSettingsManager agentSettingsManager = new AgentSettingsManager();

                    // Create a new agent settings object
                    if (act != "act")
                    {
                        AgentSettings agentSettings = new AgentSettings
                        {
                            AgentName = act,
                            AgentID = Guid.NewGuid().ToString(),
                            AgentPersonality = prompt,
                            SlaveAgentMessage = ""
                        };
                        List<AgentSettings> slaveAgents = new List<AgentSettings>();
                        agentSettings.SlaveAgents = slaveAgents;
                        agentSettingsManager.SaveAgentSettings(agentSettings);
                    }
                }
                MessageBox.Show("Default agents loaded.");
            }

        }

        private void btnDeleteRecordings_Click(object sender, EventArgs e)
        {

            // Get the full path of the recordings directory
            string recordingsDirectory = Path.Combine(Environment.CurrentDirectory, "rec");

            // Get all files in the recordings directory
            string[] recordingFiles = Directory.GetFiles(recordingsDirectory);

            // Delete each recording file
            foreach (string recordingFile in recordingFiles)
            {
                try
                {
                    // Attempt to delete the file
                    File.Delete(recordingFile);
                }
                catch (IOException ex)
                {
                    // The file is in use
                    MessageBox.Show($"Cannot delete file {recordingFile}. It is in use by another program.");
                }
            }

            MessageBox.Show("Recordings deleted.");
        }
    }
}

namespace sam
{
    partial class SmartAgent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartAgent));
            agentContainer = new SplitContainer();
            tabAgent = new TabControl();
            tabPage1 = new TabPage();
            agentSettingsGrp = new GroupBox();
            settingsPanel = new Panel();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            checkedListSelectedSlaves = new CheckedListBox();
            groupBox2 = new GroupBox();
            txtSlaveMessage = new TextBox();
            grpAgentControl = new GroupBox();
            chkSmartAgentEnabled = new CheckBox();
            btnSaveAgent = new Button();
            btnReset = new Button();
            grpPersonality = new GroupBox();
            txtAgentPersonality = new TextBox();
            grpAgentID = new GroupBox();
            txtAgentID = new TextBox();
            grpName = new GroupBox();
            txtAgentName = new TextBox();
            tabPage2 = new TabPage();
            pnlAudio = new Panel();
            grpAudioDevices = new GroupBox();
            cmbMicLoop = new ComboBox();
            lblMic = new Label();
            cmbSpeaker = new ComboBox();
            lblSpeakers = new Label();
            tabDialogs = new TabControl();
            tabPageText = new TabPage();
            agentConversation = new GroupBox();
            conversationContentPanel = new Panel();
            txtChat = new RichTextBox();
            tabPageCode = new TabPage();
            groupBox4 = new GroupBox();
            panel1 = new Panel();
            txtCode = new FastColoredTextBoxNS.FastColoredTextBox();
            grpUserInput = new GroupBox();
            pnlInput = new Panel();
            btnSend = new Button();
            txtUserInput = new TextBox();
            agentStatus = new StatusStrip();
            agentStatusLabel = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            agentProgress = new ToolStripProgressBar();
            agentTools = new ToolStrip();
            btnTTS = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            ttsVoice = new ToolStripComboBox();
            btnRecordComputerAudio = new ToolStripButton();
            btnPlayAudioToMic = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)agentContainer).BeginInit();
            agentContainer.Panel1.SuspendLayout();
            agentContainer.Panel2.SuspendLayout();
            agentContainer.SuspendLayout();
            tabAgent.SuspendLayout();
            tabPage1.SuspendLayout();
            agentSettingsGrp.SuspendLayout();
            settingsPanel.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            grpAgentControl.SuspendLayout();
            grpPersonality.SuspendLayout();
            grpAgentID.SuspendLayout();
            grpName.SuspendLayout();
            tabPage2.SuspendLayout();
            pnlAudio.SuspendLayout();
            grpAudioDevices.SuspendLayout();
            tabDialogs.SuspendLayout();
            tabPageText.SuspendLayout();
            agentConversation.SuspendLayout();
            conversationContentPanel.SuspendLayout();
            tabPageCode.SuspendLayout();
            groupBox4.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtCode).BeginInit();
            grpUserInput.SuspendLayout();
            pnlInput.SuspendLayout();
            agentStatus.SuspendLayout();
            agentTools.SuspendLayout();
            SuspendLayout();
            // 
            // agentContainer
            // 
            agentContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            agentContainer.Location = new Point(0, 42);
            agentContainer.Name = "agentContainer";
            // 
            // agentContainer.Panel1
            // 
            agentContainer.Panel1.Controls.Add(tabAgent);
            // 
            // agentContainer.Panel2
            // 
            agentContainer.Panel2.Controls.Add(tabDialogs);
            agentContainer.Panel2.Controls.Add(grpUserInput);
            agentContainer.Size = new Size(1185, 687);
            agentContainer.SplitterDistance = 412;
            agentContainer.TabIndex = 0;
            // 
            // tabAgent
            // 
            tabAgent.Controls.Add(tabPage1);
            tabAgent.Controls.Add(tabPage2);
            tabAgent.Dock = DockStyle.Fill;
            tabAgent.Location = new Point(0, 0);
            tabAgent.Name = "tabAgent";
            tabAgent.SelectedIndex = 0;
            tabAgent.Size = new Size(412, 687);
            tabAgent.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(agentSettingsGrp);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(404, 659);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Agent";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // agentSettingsGrp
            // 
            agentSettingsGrp.Controls.Add(settingsPanel);
            agentSettingsGrp.Dock = DockStyle.Fill;
            agentSettingsGrp.Location = new Point(3, 3);
            agentSettingsGrp.Name = "agentSettingsGrp";
            agentSettingsGrp.Size = new Size(398, 653);
            agentSettingsGrp.TabIndex = 0;
            agentSettingsGrp.TabStop = false;
            agentSettingsGrp.Text = "Agent settings";
            // 
            // settingsPanel
            // 
            settingsPanel.AutoScroll = true;
            settingsPanel.Controls.Add(groupBox1);
            settingsPanel.Controls.Add(grpAgentControl);
            settingsPanel.Controls.Add(grpPersonality);
            settingsPanel.Controls.Add(grpAgentID);
            settingsPanel.Controls.Add(grpName);
            settingsPanel.Dock = DockStyle.Fill;
            settingsPanel.Location = new Point(3, 19);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new Size(392, 631);
            settingsPanel.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(6, 293);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(380, 221);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Slave agent settings";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(checkedListSelectedSlaves);
            groupBox3.Location = new Point(9, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(362, 101);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Slave agent names";
            // 
            // checkedListSelectedSlaves
            // 
            checkedListSelectedSlaves.Dock = DockStyle.Fill;
            checkedListSelectedSlaves.FormattingEnabled = true;
            checkedListSelectedSlaves.Location = new Point(3, 19);
            checkedListSelectedSlaves.Name = "checkedListSelectedSlaves";
            checkedListSelectedSlaves.Size = new Size(356, 79);
            checkedListSelectedSlaves.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(txtSlaveMessage);
            groupBox2.Location = new Point(6, 126);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(368, 85);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Message to slave agent";
            // 
            // txtSlaveMessage
            // 
            txtSlaveMessage.Dock = DockStyle.Fill;
            txtSlaveMessage.Location = new Point(3, 19);
            txtSlaveMessage.Multiline = true;
            txtSlaveMessage.Name = "txtSlaveMessage";
            txtSlaveMessage.Size = new Size(362, 63);
            txtSlaveMessage.TabIndex = 1;
            // 
            // grpAgentControl
            // 
            grpAgentControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpAgentControl.Controls.Add(chkSmartAgentEnabled);
            grpAgentControl.Controls.Add(btnSaveAgent);
            grpAgentControl.Controls.Add(btnReset);
            grpAgentControl.Location = new Point(6, 520);
            grpAgentControl.Name = "grpAgentControl";
            grpAgentControl.Size = new Size(380, 108);
            grpAgentControl.TabIndex = 5;
            grpAgentControl.TabStop = false;
            grpAgentControl.Text = "Agent control";
            // 
            // chkSmartAgentEnabled
            // 
            chkSmartAgentEnabled.AutoSize = true;
            chkSmartAgentEnabled.Location = new Point(12, 29);
            chkSmartAgentEnabled.Name = "chkSmartAgentEnabled";
            chkSmartAgentEnabled.Size = new Size(135, 19);
            chkSmartAgentEnabled.TabIndex = 7;
            chkSmartAgentEnabled.Text = "Smart agent enabled";
            chkSmartAgentEnabled.UseVisualStyleBackColor = true;
            // 
            // btnSaveAgent
            // 
            btnSaveAgent.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSaveAgent.Location = new Point(6, 55);
            btnSaveAgent.Name = "btnSaveAgent";
            btnSaveAgent.Size = new Size(78, 47);
            btnSaveAgent.TabIndex = 3;
            btnSaveAgent.Text = "Save";
            btnSaveAgent.UseVisualStyleBackColor = true;
            btnSaveAgent.Click += btnSaveAgent_Click;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnReset.Location = new Point(88, 55);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(78, 47);
            btnReset.TabIndex = 4;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // grpPersonality
            // 
            grpPersonality.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpPersonality.Controls.Add(txtAgentPersonality);
            grpPersonality.Location = new Point(6, 117);
            grpPersonality.Name = "grpPersonality";
            grpPersonality.Size = new Size(380, 170);
            grpPersonality.TabIndex = 2;
            grpPersonality.TabStop = false;
            grpPersonality.Text = "Agent personality";
            // 
            // txtAgentPersonality
            // 
            txtAgentPersonality.Dock = DockStyle.Fill;
            txtAgentPersonality.Location = new Point(3, 19);
            txtAgentPersonality.Multiline = true;
            txtAgentPersonality.Name = "txtAgentPersonality";
            txtAgentPersonality.ScrollBars = ScrollBars.Vertical;
            txtAgentPersonality.Size = new Size(374, 148);
            txtAgentPersonality.TabIndex = 1;
            // 
            // grpAgentID
            // 
            grpAgentID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpAgentID.Controls.Add(txtAgentID);
            grpAgentID.Location = new Point(6, 60);
            grpAgentID.Name = "grpAgentID";
            grpAgentID.Size = new Size(380, 51);
            grpAgentID.TabIndex = 1;
            grpAgentID.TabStop = false;
            grpAgentID.Text = "Agent id";
            // 
            // txtAgentID
            // 
            txtAgentID.Dock = DockStyle.Fill;
            txtAgentID.Location = new Point(3, 19);
            txtAgentID.Name = "txtAgentID";
            txtAgentID.Size = new Size(374, 23);
            txtAgentID.TabIndex = 1;
            // 
            // grpName
            // 
            grpName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpName.Controls.Add(txtAgentName);
            grpName.Location = new Point(9, 3);
            grpName.Name = "grpName";
            grpName.Size = new Size(380, 51);
            grpName.TabIndex = 0;
            grpName.TabStop = false;
            grpName.Text = "Agent name";
            // 
            // txtAgentName
            // 
            txtAgentName.Dock = DockStyle.Fill;
            txtAgentName.Location = new Point(3, 19);
            txtAgentName.Name = "txtAgentName";
            txtAgentName.Size = new Size(374, 23);
            txtAgentName.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(pnlAudio);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(404, 659);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Audio";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlAudio
            // 
            pnlAudio.AutoScroll = true;
            pnlAudio.Controls.Add(grpAudioDevices);
            pnlAudio.Dock = DockStyle.Fill;
            pnlAudio.Location = new Point(3, 3);
            pnlAudio.Name = "pnlAudio";
            pnlAudio.Size = new Size(398, 653);
            pnlAudio.TabIndex = 0;
            // 
            // grpAudioDevices
            // 
            grpAudioDevices.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpAudioDevices.Controls.Add(cmbMicLoop);
            grpAudioDevices.Controls.Add(lblMic);
            grpAudioDevices.Controls.Add(cmbSpeaker);
            grpAudioDevices.Controls.Add(lblSpeakers);
            grpAudioDevices.Location = new Point(5, 3);
            grpAudioDevices.Name = "grpAudioDevices";
            grpAudioDevices.Size = new Size(390, 120);
            grpAudioDevices.TabIndex = 0;
            grpAudioDevices.TabStop = false;
            grpAudioDevices.Text = "Audio devices";
            // 
            // cmbMicLoop
            // 
            cmbMicLoop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbMicLoop.FormattingEnabled = true;
            cmbMicLoop.Location = new Point(6, 81);
            cmbMicLoop.Name = "cmbMicLoop";
            cmbMicLoop.Size = new Size(378, 23);
            cmbMicLoop.TabIndex = 3;
            // 
            // lblMic
            // 
            lblMic.AutoSize = true;
            lblMic.Location = new Point(6, 63);
            lblMic.Name = "lblMic";
            lblMic.Size = new Size(144, 15);
            lblMic.TabIndex = 2;
            lblMic.Text = "Mic loopback (not virtual)";
            // 
            // cmbSpeaker
            // 
            cmbSpeaker.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbSpeaker.FormattingEnabled = true;
            cmbSpeaker.Location = new Point(6, 37);
            cmbSpeaker.Name = "cmbSpeaker";
            cmbSpeaker.Size = new Size(378, 23);
            cmbSpeaker.TabIndex = 1;
            cmbSpeaker.SelectedIndexChanged += cmbSpeaker_SelectedIndexChanged;
            // 
            // lblSpeakers
            // 
            lblSpeakers.AutoSize = true;
            lblSpeakers.Location = new Point(6, 19);
            lblSpeakers.Name = "lblSpeakers";
            lblSpeakers.Size = new Size(260, 15);
            lblSpeakers.TabIndex = 0;
            lblSpeakers.Text = "Speakers or vr (Generally the virtual audio cable)";
            // 
            // tabDialogs
            // 
            tabDialogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabDialogs.Controls.Add(tabPageText);
            tabDialogs.Controls.Add(tabPageCode);
            tabDialogs.Location = new Point(6, 3);
            tabDialogs.Name = "tabDialogs";
            tabDialogs.SelectedIndex = 0;
            tabDialogs.Size = new Size(757, 564);
            tabDialogs.TabIndex = 2;
            // 
            // tabPageText
            // 
            tabPageText.Controls.Add(agentConversation);
            tabPageText.Location = new Point(4, 24);
            tabPageText.Name = "tabPageText";
            tabPageText.Padding = new Padding(3);
            tabPageText.Size = new Size(749, 536);
            tabPageText.TabIndex = 0;
            tabPageText.Text = "Text";
            tabPageText.UseVisualStyleBackColor = true;
            // 
            // agentConversation
            // 
            agentConversation.Controls.Add(conversationContentPanel);
            agentConversation.Dock = DockStyle.Fill;
            agentConversation.Location = new Point(3, 3);
            agentConversation.Name = "agentConversation";
            agentConversation.Size = new Size(743, 530);
            agentConversation.TabIndex = 0;
            agentConversation.TabStop = false;
            agentConversation.Text = "Conversation";
            // 
            // conversationContentPanel
            // 
            conversationContentPanel.AutoScroll = true;
            conversationContentPanel.Controls.Add(txtChat);
            conversationContentPanel.Dock = DockStyle.Fill;
            conversationContentPanel.Location = new Point(3, 19);
            conversationContentPanel.Name = "conversationContentPanel";
            conversationContentPanel.Size = new Size(737, 508);
            conversationContentPanel.TabIndex = 0;
            // 
            // txtChat
            // 
            txtChat.BackColor = Color.White;
            txtChat.BorderStyle = BorderStyle.None;
            txtChat.Dock = DockStyle.Fill;
            txtChat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtChat.Location = new Point(0, 0);
            txtChat.Name = "txtChat";
            txtChat.ReadOnly = true;
            txtChat.Size = new Size(737, 508);
            txtChat.TabIndex = 0;
            txtChat.Text = "";
            // 
            // tabPageCode
            // 
            tabPageCode.Controls.Add(groupBox4);
            tabPageCode.Location = new Point(4, 24);
            tabPageCode.Name = "tabPageCode";
            tabPageCode.Padding = new Padding(3);
            tabPageCode.Size = new Size(749, 536);
            tabPageCode.TabIndex = 1;
            tabPageCode.Text = "C# Code";
            tabPageCode.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(panel1);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(3, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(743, 530);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "Code";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(txtCode);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(737, 508);
            panel1.TabIndex = 0;
            // 
            // txtCode
            // 
            txtCode.AllowSeveralTextStyleDrawing = true;
            txtCode.AutoCompleteBracketsList = (new char[] { '(', ')', '{', '}', '[', ']', '"', '"', '\'', '\'' });
            txtCode.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            txtCode.AutoScrollMinSize = new Size(2, 14);
            txtCode.BackBrush = null;
            txtCode.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            txtCode.CharHeight = 14;
            txtCode.CharWidth = 8;
            txtCode.DefaultMarkerSize = 8;
            txtCode.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            txtCode.Dock = DockStyle.Fill;
            txtCode.IsReplaceMode = false;
            txtCode.Language = FastColoredTextBoxNS.Language.CSharp;
            txtCode.LeftBracket = '(';
            txtCode.LeftBracket2 = '{';
            txtCode.Location = new Point(0, 0);
            txtCode.Name = "txtCode";
            txtCode.Paddings = new Padding(0);
            txtCode.RightBracket = ')';
            txtCode.RightBracket2 = '}';
            txtCode.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            txtCode.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("txtCode.ServiceColors");
            txtCode.Size = new Size(737, 508);
            txtCode.TabIndex = 0;
            txtCode.Zoom = 100;
            // 
            // grpUserInput
            // 
            grpUserInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpUserInput.Controls.Add(pnlInput);
            grpUserInput.Location = new Point(3, 573);
            grpUserInput.Name = "grpUserInput";
            grpUserInput.Size = new Size(760, 114);
            grpUserInput.TabIndex = 1;
            grpUserInput.TabStop = false;
            grpUserInput.Text = "User input";
            // 
            // pnlInput
            // 
            pnlInput.AutoScroll = true;
            pnlInput.Controls.Add(btnSend);
            pnlInput.Controls.Add(txtUserInput);
            pnlInput.Dock = DockStyle.Fill;
            pnlInput.Location = new Point(3, 19);
            pnlInput.Name = "pnlInput";
            pnlInput.Size = new Size(754, 92);
            pnlInput.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSend.Location = new Point(673, 3);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(78, 86);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtUserInput
            // 
            txtUserInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUserInput.BackColor = Color.White;
            txtUserInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUserInput.Location = new Point(3, 3);
            txtUserInput.Multiline = true;
            txtUserInput.Name = "txtUserInput";
            txtUserInput.ScrollBars = ScrollBars.Vertical;
            txtUserInput.Size = new Size(664, 86);
            txtUserInput.TabIndex = 0;
            // 
            // agentStatus
            // 
            agentStatus.Items.AddRange(new ToolStripItem[] { agentStatusLabel, toolStripStatusLabel1, agentProgress });
            agentStatus.Location = new Point(0, 732);
            agentStatus.Name = "agentStatus";
            agentStatus.RenderMode = ToolStripRenderMode.Professional;
            agentStatus.Size = new Size(1185, 22);
            agentStatus.SizingGrip = false;
            agentStatus.TabIndex = 1;
            // 
            // agentStatusLabel
            // 
            agentStatusLabel.Name = "agentStatusLabel";
            agentStatusLabel.Size = new Size(39, 17);
            agentStatusLabel.Text = "Ready";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(1131, 17);
            toolStripStatusLabel1.Spring = true;
            // 
            // agentProgress
            // 
            agentProgress.Name = "agentProgress";
            agentProgress.Size = new Size(100, 16);
            agentProgress.Style = ProgressBarStyle.Marquee;
            agentProgress.Visible = false;
            // 
            // agentTools
            // 
            agentTools.Items.AddRange(new ToolStripItem[] { btnTTS, toolStripButton1, ttsVoice, btnRecordComputerAudio, btnPlayAudioToMic });
            agentTools.Location = new Point(0, 0);
            agentTools.Name = "agentTools";
            agentTools.RenderMode = ToolStripRenderMode.Professional;
            agentTools.Size = new Size(1185, 25);
            agentTools.Stretch = true;
            agentTools.TabIndex = 2;
            agentTools.Text = "agentTools";
            // 
            // btnTTS
            // 
            btnTTS.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnTTS.Image = Properties.Resources.mute_sound_speaker_volume_icon;
            btnTTS.ImageTransparentColor = Color.Magenta;
            btnTTS.Name = "btnTTS";
            btnTTS.Size = new Size(23, 22);
            btnTTS.Text = "Text to speech";
            btnTTS.Click += btnTTS_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = Properties.Resources._9035019_mic_off_icon;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "Mic";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // ttsVoice
            // 
            ttsVoice.DropDownWidth = 200;
            ttsVoice.Name = "ttsVoice";
            ttsVoice.Size = new Size(200, 25);
            ttsVoice.TextChanged += ttsVoice_TextChanged;
            // 
            // btnRecordComputerAudio
            // 
            btnRecordComputerAudio.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRecordComputerAudio.Image = Properties.Resources.sharp_sensors_off_black_24dp;
            btnRecordComputerAudio.ImageTransparentColor = Color.Magenta;
            btnRecordComputerAudio.Name = "btnRecordComputerAudio";
            btnRecordComputerAudio.Size = new Size(23, 22);
            btnRecordComputerAudio.Text = "Mic to audio";
            btnRecordComputerAudio.Click += btnRecordComputerAudio_Click;
            // 
            // btnPlayAudioToMic
            // 
            btnPlayAudioToMic.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPlayAudioToMic.Image = Properties.Resources._2205218_folder_document_file_organize_icon;
            btnPlayAudioToMic.ImageTransparentColor = Color.Magenta;
            btnPlayAudioToMic.Name = "btnPlayAudioToMic";
            btnPlayAudioToMic.Size = new Size(23, 22);
            btnPlayAudioToMic.Text = "Analyze audio";
            btnPlayAudioToMic.Click += btnPlayAudioToMic_Click;
            // 
            // SmartAgent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1185, 754);
            Controls.Add(agentTools);
            Controls.Add(agentStatus);
            Controls.Add(agentContainer);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SmartAgent";
            Text = "Smart Agent";
            FormClosing += SmartAgent_FormClosing;
            Load += SmartAgent_Load;
            Shown += SmartAgent_Shown;
            agentContainer.Panel1.ResumeLayout(false);
            agentContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)agentContainer).EndInit();
            agentContainer.ResumeLayout(false);
            tabAgent.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            agentSettingsGrp.ResumeLayout(false);
            settingsPanel.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            grpAgentControl.ResumeLayout(false);
            grpAgentControl.PerformLayout();
            grpPersonality.ResumeLayout(false);
            grpPersonality.PerformLayout();
            grpAgentID.ResumeLayout(false);
            grpAgentID.PerformLayout();
            grpName.ResumeLayout(false);
            grpName.PerformLayout();
            tabPage2.ResumeLayout(false);
            pnlAudio.ResumeLayout(false);
            grpAudioDevices.ResumeLayout(false);
            grpAudioDevices.PerformLayout();
            tabDialogs.ResumeLayout(false);
            tabPageText.ResumeLayout(false);
            agentConversation.ResumeLayout(false);
            conversationContentPanel.ResumeLayout(false);
            tabPageCode.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtCode).EndInit();
            grpUserInput.ResumeLayout(false);
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            agentStatus.ResumeLayout(false);
            agentStatus.PerformLayout();
            agentTools.ResumeLayout(false);
            agentTools.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer agentContainer;
        private GroupBox agentSettingsGrp;
        private GroupBox agentConversation;
        private Panel conversationContentPanel;
        private Panel settingsPanel;
        private GroupBox grpUserInput;
        private Panel pnlInput;
        private Button btnSend;
        private TextBox txtUserInput;
        private RichTextBox txtChat;
        private GroupBox grpName;
        private TextBox txtAgentName;
        private GroupBox grpAgentID;
        private TextBox txtAgentID;
        private GroupBox grpPersonality;
        private TextBox txtAgentPersonality;
        private Button btnReset;
        private Button btnSaveAgent;
        private GroupBox grpAgentControl;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox txtSlaveMessage;
        private GroupBox groupBox3;
        private CheckedListBox checkedListSelectedSlaves;
        private CheckBox chkSmartAgentEnabled;
        private TabControl tabDialogs;
        private TabPage tabPageText;
        private TabPage tabPageCode;
        private GroupBox groupBox4;
        private Panel panel1;
        private FastColoredTextBoxNS.FastColoredTextBox txtCode;
        private StatusStrip agentStatus;
        private ToolStripStatusLabel agentStatusLabel;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripProgressBar agentProgress;
        private ToolStrip agentTools;
        private ToolStripButton btnTTS;
        private ToolStripComboBox ttsVoice;
        private ToolStripButton toolStripButton1;
        private ToolStripButton btnRecordComputerAudio;
        private ToolStripButton btnPlayAudioToMic;
        private TabControl tabAgent;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel pnlAudio;
        private GroupBox grpAudioDevices;
        private ComboBox cmbMicLoop;
        private Label lblMic;
        private ComboBox cmbSpeaker;
        private Label lblSpeakers;
    }
}
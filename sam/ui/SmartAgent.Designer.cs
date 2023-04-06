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
            groupBox7 = new GroupBox();
            txtTemp = new TextBox();
            trackTemp = new TrackBar();
            groupBox6 = new GroupBox();
            txtAgentRoleEnforcer = new TextBox();
            groupBox5 = new GroupBox();
            txtSystem = new TextBox();
            grpAgentControl = new GroupBox();
            chkSmartAgentEnabled = new CheckBox();
            btnSaveAgent = new Button();
            btnReset = new Button();
            grpPersonality = new GroupBox();
            txtAgentPersonality = new TextBox();
            grpName = new GroupBox();
            txtAgentName = new TextBox();
            tabPage2 = new TabPage();
            pnlAudio = new Panel();
            grpAgentID = new GroupBox();
            txtAgentID = new TextBox();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            checkedListSelectedSlaves = new CheckedListBox();
            groupBox2 = new GroupBox();
            txtSlaveMessage = new TextBox();
            grpAudioDevices = new GroupBox();
            cmbAudioSource = new ComboBox();
            label1 = new Label();
            cmbMicLoop = new ComboBox();
            lblMic = new Label();
            cmbSpeaker = new ComboBox();
            lblSpeakers = new Label();
            splitContainerChat = new SplitContainer();
            tabDialogs = new TabControl();
            tabPageText = new TabPage();
            agentConversation = new GroupBox();
            conversationContentPanel = new Panel();
            txtChat = new RichTextBox();
            tabPageCode = new TabPage();
            groupBox4 = new GroupBox();
            panel1 = new Panel();
            txtCode = new FastColoredTextBoxNS.FastColoredTextBox();
            tabWeb = new TabPage();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            toolWeb = new ToolStrip();
            btnBack = new ToolStripButton();
            btnForward = new ToolStripButton();
            btnRefresh = new ToolStripButton();
            txtAddress = new ToolStripTextBox();
            btnGo = new ToolStripButton();
            tabWebText = new TabPage();
            txtWebText = new RichTextBox();
            tabDynPrompt = new TabPage();
            dataDynamicPrompts = new DataGridView();
            tabMemory = new TabPage();
            dataPromptMemory = new DataGridView();
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
            btnComputerAudioSTT = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            ttsVoice = new ToolStripComboBox();
            btnRecordComputerAudio = new ToolStripButton();
            btnPlayAudioToMic = new ToolStripButton();
            toolTipFocus = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)agentContainer).BeginInit();
            agentContainer.Panel1.SuspendLayout();
            agentContainer.Panel2.SuspendLayout();
            agentContainer.SuspendLayout();
            tabAgent.SuspendLayout();
            tabPage1.SuspendLayout();
            agentSettingsGrp.SuspendLayout();
            settingsPanel.SuspendLayout();
            groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackTemp).BeginInit();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            grpAgentControl.SuspendLayout();
            grpPersonality.SuspendLayout();
            grpName.SuspendLayout();
            tabPage2.SuspendLayout();
            pnlAudio.SuspendLayout();
            grpAgentID.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            grpAudioDevices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerChat).BeginInit();
            splitContainerChat.Panel1.SuspendLayout();
            splitContainerChat.Panel2.SuspendLayout();
            splitContainerChat.SuspendLayout();
            tabDialogs.SuspendLayout();
            tabPageText.SuspendLayout();
            agentConversation.SuspendLayout();
            conversationContentPanel.SuspendLayout();
            tabPageCode.SuspendLayout();
            groupBox4.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtCode).BeginInit();
            tabWeb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            toolWeb.SuspendLayout();
            tabWebText.SuspendLayout();
            tabDynPrompt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataDynamicPrompts).BeginInit();
            tabMemory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataPromptMemory).BeginInit();
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
            agentContainer.Panel2.Controls.Add(splitContainerChat);
            agentContainer.Size = new Size(1185, 687);
            agentContainer.SplitterDistance = 300;
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
            tabAgent.Size = new Size(300, 687);
            tabAgent.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(agentSettingsGrp);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(292, 659);
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
            agentSettingsGrp.Size = new Size(286, 653);
            agentSettingsGrp.TabIndex = 0;
            agentSettingsGrp.TabStop = false;
            agentSettingsGrp.Text = "Agent settings";
            // 
            // settingsPanel
            // 
            settingsPanel.AutoScroll = true;
            settingsPanel.Controls.Add(groupBox7);
            settingsPanel.Controls.Add(groupBox6);
            settingsPanel.Controls.Add(groupBox5);
            settingsPanel.Controls.Add(grpAgentControl);
            settingsPanel.Controls.Add(grpPersonality);
            settingsPanel.Controls.Add(grpName);
            settingsPanel.Dock = DockStyle.Fill;
            settingsPanel.Location = new Point(3, 19);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new Size(280, 631);
            settingsPanel.TabIndex = 1;
            // 
            // groupBox7
            // 
            groupBox7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox7.Controls.Add(txtTemp);
            groupBox7.Controls.Add(trackTemp);
            groupBox7.Location = new Point(6, 457);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(268, 72);
            groupBox7.TabIndex = 8;
            groupBox7.TabStop = false;
            groupBox7.Text = "Agent focus";
            // 
            // txtTemp
            // 
            txtTemp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTemp.Location = new Point(221, 31);
            txtTemp.Name = "txtTemp";
            txtTemp.Size = new Size(41, 23);
            txtTemp.TabIndex = 1;
            // 
            // trackTemp
            // 
            trackTemp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackTemp.BackColor = Color.White;
            trackTemp.LargeChange = 1;
            trackTemp.Location = new Point(3, 19);
            trackTemp.Minimum = -10;
            trackTemp.Name = "trackTemp";
            trackTemp.Size = new Size(212, 45);
            trackTemp.TabIndex = 0;
            trackTemp.TickStyle = TickStyle.Both;
            toolTipFocus.SetToolTip(trackTemp, resources.GetString("trackTemp.ToolTip"));
            trackTemp.Scroll += trackTemp_Scroll;
            trackTemp.ValueChanged += trackTemp_ValueChanged;
            // 
            // groupBox6
            // 
            groupBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox6.Controls.Add(txtAgentRoleEnforcer);
            groupBox6.Location = new Point(6, 317);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(268, 136);
            groupBox6.TabIndex = 7;
            groupBox6.TabStop = false;
            groupBox6.Text = "Agent role enforcer";
            // 
            // txtAgentRoleEnforcer
            // 
            txtAgentRoleEnforcer.Dock = DockStyle.Fill;
            txtAgentRoleEnforcer.Location = new Point(3, 19);
            txtAgentRoleEnforcer.Multiline = true;
            txtAgentRoleEnforcer.Name = "txtAgentRoleEnforcer";
            txtAgentRoleEnforcer.ScrollBars = ScrollBars.Vertical;
            txtAgentRoleEnforcer.Size = new Size(262, 114);
            txtAgentRoleEnforcer.TabIndex = 1;
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox5.Controls.Add(txtSystem);
            groupBox5.Location = new Point(9, 60);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(268, 87);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            groupBox5.Text = "Agent system";
            // 
            // txtSystem
            // 
            txtSystem.Dock = DockStyle.Fill;
            txtSystem.Location = new Point(3, 19);
            txtSystem.Multiline = true;
            txtSystem.Name = "txtSystem";
            txtSystem.ScrollBars = ScrollBars.Vertical;
            txtSystem.Size = new Size(262, 65);
            txtSystem.TabIndex = 1;
            // 
            // grpAgentControl
            // 
            grpAgentControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpAgentControl.Controls.Add(chkSmartAgentEnabled);
            grpAgentControl.Controls.Add(btnSaveAgent);
            grpAgentControl.Controls.Add(btnReset);
            grpAgentControl.Location = new Point(6, 535);
            grpAgentControl.Name = "grpAgentControl";
            grpAgentControl.Size = new Size(268, 93);
            grpAgentControl.TabIndex = 5;
            grpAgentControl.TabStop = false;
            grpAgentControl.Text = "Agent control";
            // 
            // chkSmartAgentEnabled
            // 
            chkSmartAgentEnabled.AutoSize = true;
            chkSmartAgentEnabled.Location = new Point(6, 23);
            chkSmartAgentEnabled.Name = "chkSmartAgentEnabled";
            chkSmartAgentEnabled.Size = new Size(135, 19);
            chkSmartAgentEnabled.TabIndex = 7;
            chkSmartAgentEnabled.Text = "Smart agent enabled";
            chkSmartAgentEnabled.UseVisualStyleBackColor = true;
            // 
            // btnSaveAgent
            // 
            btnSaveAgent.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSaveAgent.Location = new Point(6, 48);
            btnSaveAgent.Name = "btnSaveAgent";
            btnSaveAgent.Size = new Size(78, 39);
            btnSaveAgent.TabIndex = 3;
            btnSaveAgent.Text = "Save";
            btnSaveAgent.UseVisualStyleBackColor = true;
            btnSaveAgent.Click += btnSaveAgent_Click;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnReset.Location = new Point(90, 48);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(78, 39);
            btnReset.TabIndex = 4;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // grpPersonality
            // 
            grpPersonality.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpPersonality.Controls.Add(txtAgentPersonality);
            grpPersonality.Location = new Point(6, 153);
            grpPersonality.Name = "grpPersonality";
            grpPersonality.Size = new Size(268, 158);
            grpPersonality.TabIndex = 2;
            grpPersonality.TabStop = false;
            grpPersonality.Text = "Agent role";
            // 
            // txtAgentPersonality
            // 
            txtAgentPersonality.Dock = DockStyle.Fill;
            txtAgentPersonality.Location = new Point(3, 19);
            txtAgentPersonality.Multiline = true;
            txtAgentPersonality.Name = "txtAgentPersonality";
            txtAgentPersonality.ScrollBars = ScrollBars.Vertical;
            txtAgentPersonality.Size = new Size(262, 136);
            txtAgentPersonality.TabIndex = 1;
            // 
            // grpName
            // 
            grpName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpName.Controls.Add(txtAgentName);
            grpName.Location = new Point(9, 3);
            grpName.Name = "grpName";
            grpName.Size = new Size(268, 51);
            grpName.TabIndex = 0;
            grpName.TabStop = false;
            grpName.Text = "Agent name";
            // 
            // txtAgentName
            // 
            txtAgentName.Dock = DockStyle.Fill;
            txtAgentName.Location = new Point(3, 19);
            txtAgentName.Name = "txtAgentName";
            txtAgentName.Size = new Size(262, 23);
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
            tabPage2.Text = "Settings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlAudio
            // 
            pnlAudio.AutoScroll = true;
            pnlAudio.Controls.Add(grpAgentID);
            pnlAudio.Controls.Add(groupBox1);
            pnlAudio.Controls.Add(grpAudioDevices);
            pnlAudio.Dock = DockStyle.Fill;
            pnlAudio.Location = new Point(3, 3);
            pnlAudio.Name = "pnlAudio";
            pnlAudio.Size = new Size(398, 653);
            pnlAudio.TabIndex = 0;
            // 
            // grpAgentID
            // 
            grpAgentID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpAgentID.Controls.Add(txtAgentID);
            grpAgentID.Location = new Point(11, 3);
            grpAgentID.Name = "grpAgentID";
            grpAgentID.Size = new Size(380, 51);
            grpAgentID.TabIndex = 8;
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
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(5, 229);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(390, 249);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Slave agent settings";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(checkedListSelectedSlaves);
            groupBox3.Location = new Point(6, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(378, 101);
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
            checkedListSelectedSlaves.Size = new Size(372, 79);
            checkedListSelectedSlaves.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(txtSlaveMessage);
            groupBox2.Location = new Point(9, 129);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(375, 114);
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
            txtSlaveMessage.Size = new Size(369, 92);
            txtSlaveMessage.TabIndex = 1;
            // 
            // grpAudioDevices
            // 
            grpAudioDevices.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpAudioDevices.Controls.Add(cmbAudioSource);
            grpAudioDevices.Controls.Add(label1);
            grpAudioDevices.Controls.Add(cmbMicLoop);
            grpAudioDevices.Controls.Add(lblMic);
            grpAudioDevices.Controls.Add(cmbSpeaker);
            grpAudioDevices.Controls.Add(lblSpeakers);
            grpAudioDevices.Location = new Point(5, 60);
            grpAudioDevices.Name = "grpAudioDevices";
            grpAudioDevices.Size = new Size(390, 163);
            grpAudioDevices.TabIndex = 0;
            grpAudioDevices.TabStop = false;
            grpAudioDevices.Text = "Audio devices for mic loopback";
            // 
            // cmbAudioSource
            // 
            cmbAudioSource.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbAudioSource.FormattingEnabled = true;
            cmbAudioSource.Location = new Point(6, 125);
            cmbAudioSource.Name = "cmbAudioSource";
            cmbAudioSource.Size = new Size(378, 23);
            cmbAudioSource.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 107);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 4;
            label1.Text = "Audio source to listen";
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
            // splitContainerChat
            // 
            splitContainerChat.Dock = DockStyle.Fill;
            splitContainerChat.Location = new Point(0, 0);
            splitContainerChat.Name = "splitContainerChat";
            splitContainerChat.Orientation = Orientation.Horizontal;
            // 
            // splitContainerChat.Panel1
            // 
            splitContainerChat.Panel1.Controls.Add(tabDialogs);
            // 
            // splitContainerChat.Panel2
            // 
            splitContainerChat.Panel2.Controls.Add(grpUserInput);
            splitContainerChat.Size = new Size(881, 687);
            splitContainerChat.SplitterDistance = 499;
            splitContainerChat.TabIndex = 3;
            // 
            // tabDialogs
            // 
            tabDialogs.Controls.Add(tabPageText);
            tabDialogs.Controls.Add(tabPageCode);
            tabDialogs.Controls.Add(tabWeb);
            tabDialogs.Controls.Add(tabWebText);
            tabDialogs.Controls.Add(tabDynPrompt);
            tabDialogs.Controls.Add(tabMemory);
            tabDialogs.Dock = DockStyle.Fill;
            tabDialogs.Location = new Point(0, 0);
            tabDialogs.Name = "tabDialogs";
            tabDialogs.SelectedIndex = 0;
            tabDialogs.Size = new Size(881, 499);
            tabDialogs.TabIndex = 2;
            // 
            // tabPageText
            // 
            tabPageText.Controls.Add(agentConversation);
            tabPageText.Location = new Point(4, 24);
            tabPageText.Name = "tabPageText";
            tabPageText.Padding = new Padding(3);
            tabPageText.Size = new Size(873, 471);
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
            agentConversation.Size = new Size(867, 465);
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
            conversationContentPanel.Size = new Size(861, 443);
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
            txtChat.Size = new Size(861, 443);
            txtChat.TabIndex = 0;
            txtChat.Text = "";
            // 
            // tabPageCode
            // 
            tabPageCode.Controls.Add(groupBox4);
            tabPageCode.Location = new Point(4, 24);
            tabPageCode.Name = "tabPageCode";
            tabPageCode.Padding = new Padding(3);
            tabPageCode.Size = new Size(761, 471);
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
            groupBox4.Size = new Size(755, 465);
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
            panel1.Size = new Size(749, 443);
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
            txtCode.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
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
            txtCode.Size = new Size(749, 443);
            txtCode.TabIndex = 0;
            txtCode.Zoom = 100;
            // 
            // tabWeb
            // 
            tabWeb.Controls.Add(webView21);
            tabWeb.Controls.Add(toolWeb);
            tabWeb.Location = new Point(4, 24);
            tabWeb.Name = "tabWeb";
            tabWeb.Size = new Size(761, 471);
            tabWeb.TabIndex = 2;
            tabWeb.Text = "Web";
            tabWeb.UseVisualStyleBackColor = true;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(3, 28);
            webView21.Name = "webView21";
            webView21.Size = new Size(755, 440);
            webView21.Source = new Uri("https://bing.com/", UriKind.Absolute);
            webView21.TabIndex = 1;
            webView21.ZoomFactor = 1D;
            webView21.NavigationCompleted += webView21_NavigationCompleted;
            webView21.WebMessageReceived += webView21_WebMessageReceived;
            webView21.SourceChanged += webView21_SourceChanged;
            // 
            // toolWeb
            // 
            toolWeb.Items.AddRange(new ToolStripItem[] { btnBack, btnForward, btnRefresh, txtAddress, btnGo });
            toolWeb.Location = new Point(0, 0);
            toolWeb.Name = "toolWeb";
            toolWeb.Size = new Size(761, 25);
            toolWeb.TabIndex = 0;
            toolWeb.Text = "toolStrip1";
            // 
            // btnBack
            // 
            btnBack.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnBack.Image = Properties.Resources._211686_back_arrow_icon_24;
            btnBack.ImageTransparentColor = Color.Magenta;
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(23, 22);
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            // 
            // btnForward
            // 
            btnForward.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnForward.Image = Properties.Resources._211688_forward_arrow_icon_24;
            btnForward.ImageTransparentColor = Color.Magenta;
            btnForward.Name = "btnForward";
            btnForward.Size = new Size(23, 22);
            btnForward.Text = "Forward";
            btnForward.Click += btnForward_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRefresh.Image = Properties.Resources._326679_refresh_reload_icon_24;
            btnRefresh.ImageTransparentColor = Color.Magenta;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(23, 22);
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // txtAddress
            // 
            txtAddress.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtAddress.AutoCompleteSource = AutoCompleteSource.AllUrl;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(600, 25);
            // 
            // btnGo
            // 
            btnGo.Alignment = ToolStripItemAlignment.Right;
            btnGo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnGo.Image = Properties.Resources._9035555_navigate_circle_outline_icon_24;
            btnGo.ImageTransparentColor = Color.Magenta;
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(23, 22);
            btnGo.Text = "Go";
            btnGo.Click += btnGo_Click;
            // 
            // tabWebText
            // 
            tabWebText.Controls.Add(txtWebText);
            tabWebText.Location = new Point(4, 24);
            tabWebText.Name = "tabWebText";
            tabWebText.Size = new Size(761, 471);
            tabWebText.TabIndex = 3;
            tabWebText.Text = "Web Text";
            tabWebText.UseVisualStyleBackColor = true;
            // 
            // txtWebText
            // 
            txtWebText.BackColor = Color.White;
            txtWebText.BorderStyle = BorderStyle.None;
            txtWebText.Dock = DockStyle.Fill;
            txtWebText.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtWebText.Location = new Point(0, 0);
            txtWebText.Name = "txtWebText";
            txtWebText.ReadOnly = true;
            txtWebText.Size = new Size(761, 471);
            txtWebText.TabIndex = 1;
            txtWebText.Text = "";
            // 
            // tabDynPrompt
            // 
            tabDynPrompt.Controls.Add(dataDynamicPrompts);
            tabDynPrompt.Location = new Point(4, 24);
            tabDynPrompt.Name = "tabDynPrompt";
            tabDynPrompt.Size = new Size(761, 471);
            tabDynPrompt.TabIndex = 4;
            tabDynPrompt.Text = "Dynamic Prompt memory";
            tabDynPrompt.UseVisualStyleBackColor = true;
            // 
            // dataDynamicPrompts
            // 
            dataDynamicPrompts.AllowUserToAddRows = false;
            dataDynamicPrompts.AllowUserToDeleteRows = false;
            dataDynamicPrompts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataDynamicPrompts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            dataDynamicPrompts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataDynamicPrompts.Dock = DockStyle.Fill;
            dataDynamicPrompts.Location = new Point(0, 0);
            dataDynamicPrompts.Name = "dataDynamicPrompts";
            dataDynamicPrompts.RowTemplate.Height = 25;
            dataDynamicPrompts.Size = new Size(761, 471);
            dataDynamicPrompts.TabIndex = 0;
            // 
            // tabMemory
            // 
            tabMemory.Controls.Add(dataPromptMemory);
            tabMemory.Location = new Point(4, 24);
            tabMemory.Name = "tabMemory";
            tabMemory.Size = new Size(761, 471);
            tabMemory.TabIndex = 5;
            tabMemory.Text = "Prompt Memory";
            tabMemory.UseVisualStyleBackColor = true;
            // 
            // dataPromptMemory
            // 
            dataPromptMemory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataPromptMemory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataPromptMemory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataPromptMemory.Dock = DockStyle.Fill;
            dataPromptMemory.Location = new Point(0, 0);
            dataPromptMemory.Name = "dataPromptMemory";
            dataPromptMemory.RowTemplate.Height = 25;
            dataPromptMemory.Size = new Size(761, 471);
            dataPromptMemory.TabIndex = 1;
            dataPromptMemory.CellBeginEdit += dataPromptMemory_CellBeginEdit;
            dataPromptMemory.RowValidated += dataPromptMemory_RowValidated;
            // 
            // grpUserInput
            // 
            grpUserInput.Controls.Add(pnlInput);
            grpUserInput.Dock = DockStyle.Fill;
            grpUserInput.Location = new Point(0, 0);
            grpUserInput.Name = "grpUserInput";
            grpUserInput.Size = new Size(881, 184);
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
            pnlInput.Size = new Size(875, 162);
            pnlInput.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnSend.Location = new Point(812, 3);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(59, 155);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtUserInput
            // 
            txtUserInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtUserInput.BackColor = Color.White;
            txtUserInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUserInput.Location = new Point(3, 3);
            txtUserInput.Multiline = true;
            txtUserInput.Name = "txtUserInput";
            txtUserInput.ScrollBars = ScrollBars.Vertical;
            txtUserInput.Size = new Size(803, 155);
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
            agentTools.Items.AddRange(new ToolStripItem[] { btnTTS, btnComputerAudioSTT, toolStripButton1, ttsVoice, btnRecordComputerAudio, btnPlayAudioToMic });
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
            // btnComputerAudioSTT
            // 
            btnComputerAudioSTT.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnComputerAudioSTT.Image = Properties.Resources._9055836_bxl_microsoft_teams_icon_off_24;
            btnComputerAudioSTT.ImageTransparentColor = Color.Magenta;
            btnComputerAudioSTT.Name = "btnComputerAudioSTT";
            btnComputerAudioSTT.Size = new Size(23, 22);
            btnComputerAudioSTT.Text = "Transcript computer audio";
            btnComputerAudioSTT.Click += btnComputerAudioSTT_Click;
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
            // toolTipFocus
            // 
            toolTipFocus.ToolTipTitle = "What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic.";
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
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackTemp).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            grpAgentControl.ResumeLayout(false);
            grpAgentControl.PerformLayout();
            grpPersonality.ResumeLayout(false);
            grpPersonality.PerformLayout();
            grpName.ResumeLayout(false);
            grpName.PerformLayout();
            tabPage2.ResumeLayout(false);
            pnlAudio.ResumeLayout(false);
            grpAgentID.ResumeLayout(false);
            grpAgentID.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            grpAudioDevices.ResumeLayout(false);
            grpAudioDevices.PerformLayout();
            splitContainerChat.Panel1.ResumeLayout(false);
            splitContainerChat.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerChat).EndInit();
            splitContainerChat.ResumeLayout(false);
            tabDialogs.ResumeLayout(false);
            tabPageText.ResumeLayout(false);
            agentConversation.ResumeLayout(false);
            conversationContentPanel.ResumeLayout(false);
            tabPageCode.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtCode).EndInit();
            tabWeb.ResumeLayout(false);
            tabWeb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            toolWeb.ResumeLayout(false);
            toolWeb.PerformLayout();
            tabWebText.ResumeLayout(false);
            tabDynPrompt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataDynamicPrompts).EndInit();
            tabMemory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataPromptMemory).EndInit();
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
        private GroupBox grpPersonality;
        private TextBox txtAgentPersonality;
        private Button btnReset;
        private Button btnSaveAgent;
        private GroupBox grpAgentControl;
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
        private ToolStripButton btnComputerAudioSTT;
        private ComboBox cmbAudioSource;
        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private CheckedListBox checkedListSelectedSlaves;
        private GroupBox groupBox2;
        private TextBox txtSlaveMessage;
        private TabPage tabWeb;
        private ToolStrip toolWeb;
        private ToolStripButton btnBack;
        private ToolStripButton btnForward;
        private ToolStripButton btnRefresh;
        private ToolStripTextBox txtAddress;
        private ToolStripButton btnGo;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private TabPage tabWebText;
        private RichTextBox txtWebText;
        private GroupBox groupBox7;
        private TrackBar trackTemp;
        private GroupBox groupBox6;
        private TextBox txtAgentRoleEnforcer;
        private GroupBox groupBox5;
        private TextBox txtSystem;
        private GroupBox grpAgentID;
        private TextBox txtAgentID;
        private ToolTip toolTipFocus;
        private TextBox txtTemp;
        private TabPage tabDynPrompt;
        private DataGridView dataDynamicPrompts;
        private TabPage tabMemory;
        private DataGridView dataPromptMemory;
        private SplitContainer splitContainerChat;
    }
}
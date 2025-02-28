﻿namespace sam
{
    partial class SAM
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAM));
            samTools = new ToolStripContainer();
            dockPanelSAM = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            toolSAM = new ToolStrip();
            samMenu = new ToolStripDropDownButton();
            newSmartAgentToolStripMenuItem = new ToolStripMenuItem();
            loadSmartAgentToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            btnRecAudio = new ToolStripButton();
            btnOpenRecFolder = new ToolStripButton();
            btnPromptTools = new ToolStripButton();
            btnHelp = new ToolStripDropDownButton();
            chatGPTpromptgeneratorToolStripMenuItem = new ToolStripMenuItem();
            openaicookbookToolStripMenuItem = new ToolStripMenuItem();
            allpromptlibrariesinonepageToolStripMenuItem = new ToolStripMenuItem();
            promptEngineeringGuideToolStripMenuItem = new ToolStripMenuItem();
            samTools.ContentPanel.SuspendLayout();
            samTools.LeftToolStripPanel.SuspendLayout();
            samTools.SuspendLayout();
            toolSAM.SuspendLayout();
            SuspendLayout();
            // 
            // samTools
            // 
            // 
            // samTools.ContentPanel
            // 
            samTools.ContentPanel.Controls.Add(dockPanelSAM);
            samTools.ContentPanel.Size = new Size(1282, 782);
            samTools.Dock = DockStyle.Fill;
            // 
            // samTools.LeftToolStripPanel
            // 
            samTools.LeftToolStripPanel.Controls.Add(toolSAM);
            samTools.Location = new Point(0, 0);
            samTools.Name = "samTools";
            samTools.Size = new Size(1314, 807);
            samTools.TabIndex = 0;
            samTools.Text = "toolStripContainer1";
            // 
            // dockPanelSAM
            // 
            dockPanelSAM.Dock = DockStyle.Fill;
            dockPanelSAM.Location = new Point(0, 0);
            dockPanelSAM.Name = "dockPanelSAM";
            dockPanelSAM.Size = new Size(1282, 782);
            dockPanelSAM.TabIndex = 0;
            // 
            // toolSAM
            // 
            toolSAM.Dock = DockStyle.None;
            toolSAM.Items.AddRange(new ToolStripItem[] { samMenu, btnRecAudio, btnOpenRecFolder, btnPromptTools, btnHelp });
            toolSAM.Location = new Point(0, 0);
            toolSAM.Name = "toolSAM";
            toolSAM.RenderMode = ToolStripRenderMode.Professional;
            toolSAM.Size = new Size(32, 782);
            toolSAM.Stretch = true;
            toolSAM.TabIndex = 0;
            // 
            // samMenu
            // 
            samMenu.DisplayStyle = ToolStripItemDisplayStyle.Image;
            samMenu.DropDownItems.AddRange(new ToolStripItem[] { newSmartAgentToolStripMenuItem, loadSmartAgentToolStripMenuItem, settingsToolStripMenuItem, exitToolStripMenuItem });
            samMenu.Image = (Image)resources.GetObject("samMenu.Image");
            samMenu.ImageScaling = ToolStripItemImageScaling.None;
            samMenu.ImageTransparentColor = Color.Magenta;
            samMenu.Name = "samMenu";
            samMenu.ShowDropDownArrow = false;
            samMenu.Size = new Size(30, 28);
            samMenu.Text = "Menu";
            // 
            // newSmartAgentToolStripMenuItem
            // 
            newSmartAgentToolStripMenuItem.Name = "newSmartAgentToolStripMenuItem";
            newSmartAgentToolStripMenuItem.Size = new Size(169, 22);
            newSmartAgentToolStripMenuItem.Text = "New Smart Agent";
            newSmartAgentToolStripMenuItem.Click += newSmartAgentToolStripMenuItem_Click;
            // 
            // loadSmartAgentToolStripMenuItem
            // 
            loadSmartAgentToolStripMenuItem.Name = "loadSmartAgentToolStripMenuItem";
            loadSmartAgentToolStripMenuItem.Size = new Size(169, 22);
            loadSmartAgentToolStripMenuItem.Text = "Load Smart Agent";
            loadSmartAgentToolStripMenuItem.Click += loadSmartAgentToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(169, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(169, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // btnRecAudio
            // 
            btnRecAudio.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRecAudio.Image = Properties.Resources.sharp_sensors_off_black_24dp;
            btnRecAudio.ImageScaling = ToolStripItemImageScaling.None;
            btnRecAudio.ImageTransparentColor = Color.Magenta;
            btnRecAudio.Name = "btnRecAudio";
            btnRecAudio.Size = new Size(30, 28);
            btnRecAudio.Text = "Record audio";
            btnRecAudio.Click += btnRecAudio_Click;
            // 
            // btnOpenRecFolder
            // 
            btnOpenRecFolder.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnOpenRecFolder.Image = Properties.Resources._3643772_folder_archive_open_archives_document_icon_24;
            btnOpenRecFolder.ImageScaling = ToolStripItemImageScaling.None;
            btnOpenRecFolder.ImageTransparentColor = Color.Magenta;
            btnOpenRecFolder.Name = "btnOpenRecFolder";
            btnOpenRecFolder.Size = new Size(30, 28);
            btnOpenRecFolder.Text = "Open rec folder";
            btnOpenRecFolder.Click += btnOpenRecFolder_Click;
            // 
            // btnPromptTools
            // 
            btnPromptTools.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPromptTools.Image = (Image)resources.GetObject("btnPromptTools.Image");
            btnPromptTools.ImageScaling = ToolStripItemImageScaling.None;
            btnPromptTools.ImageTransparentColor = Color.Magenta;
            btnPromptTools.Name = "btnPromptTools";
            btnPromptTools.Size = new Size(30, 28);
            btnPromptTools.Text = "Prompt Tools";
            btnPromptTools.Click += btnPromptTools_Click;
            // 
            // btnHelp
            // 
            btnHelp.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnHelp.DropDownItems.AddRange(new ToolStripItem[] { chatGPTpromptgeneratorToolStripMenuItem, openaicookbookToolStripMenuItem, allpromptlibrariesinonepageToolStripMenuItem, promptEngineeringGuideToolStripMenuItem });
            btnHelp.Image = Properties.Resources._172477_question_help_icon_24;
            btnHelp.ImageTransparentColor = Color.Magenta;
            btnHelp.Name = "btnHelp";
            btnHelp.ShowDropDownArrow = false;
            btnHelp.Size = new Size(30, 20);
            btnHelp.Text = "toolStripDropDownButton1";
            btnHelp.ToolTipText = "Help";
            // 
            // chatGPTpromptgeneratorToolStripMenuItem
            // 
            chatGPTpromptgeneratorToolStripMenuItem.Name = "chatGPTpromptgeneratorToolStripMenuItem";
            chatGPTpromptgeneratorToolStripMenuItem.Size = new Size(248, 22);
            chatGPTpromptgeneratorToolStripMenuItem.Text = "ChatGPT-prompt-generator";
            chatGPTpromptgeneratorToolStripMenuItem.Click += chatGPTpromptgeneratorToolStripMenuItem_Click;
            // 
            // openaicookbookToolStripMenuItem
            // 
            openaicookbookToolStripMenuItem.Name = "openaicookbookToolStripMenuItem";
            openaicookbookToolStripMenuItem.Size = new Size(248, 22);
            openaicookbookToolStripMenuItem.Text = "openai-cookbook";
            openaicookbookToolStripMenuItem.Click += openaicookbookToolStripMenuItem_Click;
            // 
            // allpromptlibrariesinonepageToolStripMenuItem
            // 
            allpromptlibrariesinonepageToolStripMenuItem.Name = "allpromptlibrariesinonepageToolStripMenuItem";
            allpromptlibrariesinonepageToolStripMenuItem.Size = new Size(248, 22);
            allpromptlibrariesinonepageToolStripMenuItem.Text = "all-prompt-libraries-in-one-page";
            allpromptlibrariesinonepageToolStripMenuItem.Click += allpromptlibrariesinonepageToolStripMenuItem_Click;
            // 
            // promptEngineeringGuideToolStripMenuItem
            // 
            promptEngineeringGuideToolStripMenuItem.Name = "promptEngineeringGuideToolStripMenuItem";
            promptEngineeringGuideToolStripMenuItem.Size = new Size(248, 22);
            promptEngineeringGuideToolStripMenuItem.Text = "Prompt Engineering Guide";
            promptEngineeringGuideToolStripMenuItem.Click += promptEngineeringGuideToolStripMenuItem_Click;
            // 
            // SAM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1314, 807);
            Controls.Add(samTools);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SAM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SAM - Smart Agent Manager";
            samTools.ContentPanel.ResumeLayout(false);
            samTools.LeftToolStripPanel.ResumeLayout(false);
            samTools.LeftToolStripPanel.PerformLayout();
            samTools.ResumeLayout(false);
            samTools.PerformLayout();
            toolSAM.ResumeLayout(false);
            toolSAM.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripContainer samTools;
        private ToolStrip toolSAM;
        private ToolStripDropDownButton samMenu;
        private ToolStripMenuItem exitToolStripMenuItem;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanelSAM;
        private ToolStripMenuItem newSmartAgentToolStripMenuItem;
        private ToolStripMenuItem loadSmartAgentToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripButton btnRecAudio;
        private ToolStripButton btnOpenRecFolder;
        private ToolStripButton btnPromptTools;
        private ToolStripDropDownButton btnHelp;
        private ToolStripMenuItem chatGPTpromptgeneratorToolStripMenuItem;
        private ToolStripMenuItem openaicookbookToolStripMenuItem;
        private ToolStripMenuItem allpromptlibrariesinonepageToolStripMenuItem;
        private ToolStripMenuItem promptEngineeringGuideToolStripMenuItem;
    }
}
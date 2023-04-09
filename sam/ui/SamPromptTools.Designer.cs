namespace sam.ui
{
    partial class SamPromptTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SamPromptTools));
            groupBox1 = new GroupBox();
            promptTree = new TreeView();
            toolStrip1 = new ToolStrip();
            btnGenerate = new ToolStripButton();
            Processing = new ToolStripProgressBar();
            groupBox1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(promptTree);
            groupBox1.Location = new Point(0, 28);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(550, 580);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Prompt Library";
            // 
            // promptTree
            // 
            promptTree.Dock = DockStyle.Fill;
            promptTree.Location = new Point(3, 19);
            promptTree.Name = "promptTree";
            promptTree.Size = new Size(544, 558);
            promptTree.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnGenerate, Processing });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(550, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnGenerate
            // 
            btnGenerate.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnGenerate.Image = Properties.Resources._2890588_ai_artificial_intelligence_brain_cloud_electronics_icon_24;
            btnGenerate.ImageTransparentColor = Color.Magenta;
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(23, 22);
            btnGenerate.Text = "Generate suggestions";
            btnGenerate.Click += btnGenerate_Click;
            // 
            // Processing
            // 
            Processing.Alignment = ToolStripItemAlignment.Right;
            Processing.Name = "Processing";
            Processing.Size = new Size(100, 22);
            Processing.Style = ProgressBarStyle.Marquee;
            Processing.Visible = false;
            // 
            // SamPromptTools
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(550, 608);
            Controls.Add(toolStrip1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SamPromptTools";
            Text = "Prompt Tools";
            Load += SamPromptTools_Load;
            groupBox1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TreeView promptTree;
        private ToolStrip toolStrip1;
        private ToolStripButton btnGenerate;
        private ToolStripProgressBar Processing;
    }
}
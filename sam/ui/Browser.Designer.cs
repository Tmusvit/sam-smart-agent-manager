namespace sam.ui
{
    partial class Browser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browser));
            toolWeb = new ToolStrip();
            btnBack = new ToolStripButton();
            btnForward = new ToolStripButton();
            btnRefresh = new ToolStripButton();
            txtAddress = new ToolStripTextBox();
            btnGo = new ToolStripButton();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            toolWeb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // toolWeb
            // 
            toolWeb.Items.AddRange(new ToolStripItem[] { btnBack, btnForward, btnRefresh, txtAddress, btnGo });
            toolWeb.Location = new Point(0, 0);
            toolWeb.Name = "toolWeb";
            toolWeb.Size = new Size(800, 25);
            toolWeb.TabIndex = 1;
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
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(0, 28);
            webView21.Name = "webView21";
            webView21.Size = new Size(800, 419);
            webView21.Source = new Uri("https://about.blank", UriKind.Absolute);
            webView21.TabIndex = 2;
            webView21.ZoomFactor = 1D;
            // 
            // Browser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(webView21);
            Controls.Add(toolWeb);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Browser";
            Text = "Browser";
            Shown += Browser_Shown;
            toolWeb.ResumeLayout(false);
            toolWeb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolWeb;
        private ToolStripButton btnBack;
        private ToolStripButton btnForward;
        private ToolStripButton btnRefresh;
        private ToolStripTextBox txtAddress;
        private ToolStripButton btnGo;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}
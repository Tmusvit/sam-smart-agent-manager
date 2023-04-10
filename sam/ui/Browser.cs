using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace sam.ui
{
    public partial class Browser : DockContent
    {
        public Browser(string address)
        {
            InitializeComponent();
            InitializeAsync();
            this.txtAddress.Text = address;
        }
        async void InitializeAsync()
        {
            await webView21.EnsureCoreWebView2Async(null);
            //webView21.CoreWebView2.WebMessageReceived += UpdateAddressBar;
            webView21.CoreWebView2.Navigate(txtAddress.Text);
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

        private void btnGo_Click(object sender, EventArgs e)
        {
            NavigateToAsync(txtAddress.Text);
        }

        private async Task NavigateToAsync(string url)
        {

            var targetUrl = url.StartsWith("https://") ? url : "https://" + url;

            webView21.CoreWebView2.Navigate(targetUrl);


        }

        private void Browser_Shown(object sender, EventArgs e)
        {
            
        }
    }
}

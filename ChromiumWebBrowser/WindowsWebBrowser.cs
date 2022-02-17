using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace WebBrowser
{
    public partial class WindowsWebBrowser : Form
    {
        ChromiumWebBrowser chromeBrowser1;
        ChromiumWebBrowser chromeBrowser2;

        public WindowsWebBrowser()
        {
            InitializeComponent();

            ////Create a new instance in code or add via the designer
            ////Set the ChromiumWebBrowser.Address property to your Url if you use the designer.
            //ChromiumWebBrowser browser1 = new ChromiumWebBrowser("www.google.com");
            //browser1.Height = this.Height / 2;
            //this.Controls.Add(browser1);

            //ChromiumWebBrowser browser2 = new ChromiumWebBrowser("www.poet.com");
            //browser2.Height = this.Height / 2;

            //this.Controls.Add(browser2);
            this.WindowState = FormWindowState.Maximized;

            string url1 = "http://poet.co.il";
            string url2 = "https://google.com";

            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);

            // Create a browser component
            //ChromiumWebBrowser chromeBrowser1;
            chromeBrowser1 = new ChromiumWebBrowser(url1);
            // Add it to the form and fill it to the form window.
            splitContainer.Panel1.Controls.Add(chromeBrowser1);
            chromeBrowser1.Dock = DockStyle.Fill;

            //ChromiumWebBrowser chromeBrowser2;
            chromeBrowser2 = new ChromiumWebBrowser(url2);
            splitContainer.Panel2.Controls.Add(chromeBrowser2);
            chromeBrowser2.Dock = DockStyle.Fill;
        }

        private void txtUrlForPanel1_Leave(object sender, EventArgs e)
        {
            ChangeUrl(sender, chromeBrowser1);
        }

        private void ChangeUrl(object sender, object target)
        {
            TextBox tb = (TextBox)sender;
            ChromiumWebBrowser cwb = (ChromiumWebBrowser)target;
            cwb.LoadUrl(tb.Text);
        }

        private void txtUrlForPanel2_Leave(object sender, EventArgs e)
        {
            ChangeUrl(sender, chromeBrowser2);
        }

        private void splitContainer_ClientSizeChanged(object sender, EventArgs e)
        {
            //txtUrlForPanel2.Left = splitContainer.Panel2.Left;
        }

        private void label2_SizeChanged(object sender, EventArgs e)
        {
            // txtUrlForPanel2.Left = splitContainer.Panel2.Left;
        }

        private void txtUrlForPanel2_ClientSizeChanged(object sender, EventArgs e)
        {
            //txtUrlForPanel2.Left = splitContainer.Panel2.Left;
        }

        private void splitContainer_Panel2_ClientSizeChanged(object sender, EventArgs e)
        {
            //txtUrlForPanel2.Left = splitContainer.Panel2.Left;
        }
    }
}

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
        readonly ChromiumWebBrowser chromeBrowser1;
        readonly ChromiumWebBrowser chromeBrowser2;
        readonly ChromiumWebBrowser chromeBrowser3;
        double zoomLevel = 0.5;
        double zoom = 0;
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

            #region Set default setting for browser
            string url1 = "https://web.telegram.org/k/#-1826947962";
            string url2 = "https://web.whatsapp.com/";
            string url3 = "https://www.facebook.com/messages/t";

            txtUrlForPanel1.Text = url1;
            txtUrlForPanel2.Text = url2;
            txtUrlForPanel3.Text = url3;

            chromeBrowser1 = new ChromiumWebBrowser(url1);
            chromeBrowser2 = new ChromiumWebBrowser(url2);
            chromeBrowser3 = new ChromiumWebBrowser(url3);

            chromeBrowser1.Dock = DockStyle.Fill;
            chromeBrowser2.Dock = DockStyle.Fill;
            chromeBrowser3.Dock = DockStyle.Fill;

            #endregion

            #region Initialize cef with the provided settings
            CefSettings settings = new CefSettings();
            //Cef.Initialize(settings);
            #endregion

            SplitContainer sc = new SplitContainer();
            sc.Dock = DockStyle.Fill;
            //sc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //txtUrlForPanel1.Dock = DockStyle.Top;
            //sc.Panel1.Controls.Add(txtUrlForPanel1);
            sc.Panel1.Controls.Add(chromeBrowser1);
            splitContainer.Panel1.Controls.Add(sc);

            sc.Panel1.Controls.Add(chromeBrowser1);
            sc.Panel2.Controls.Add(chromeBrowser2);

            splitContainer.Panel2.Controls.Add(chromeBrowser3);
        }

        private void TxtUrlForPanel1_Leave(object sender, EventArgs e)
        {
            ChangeUrl(sender, chromeBrowser1);
        }

        private void ChangeUrl(object sender, object target)
        {
            TextBox tb = (TextBox)sender;
            ChromiumWebBrowser cwb = (ChromiumWebBrowser)target;
            cwb.LoadUrl(tb.Text);
        }

        private void TxtUrlForPanel2_Leave(object sender, EventArgs e)
        {
            ChangeUrl(sender, chromeBrowser2);
        }

        private void SplitContainer_ClientSizeChanged(object sender, EventArgs e)
        {
            //txtUrlForPanel2.Left = splitContainer.Panel2.Left;
        }

        private void Label2_SizeChanged(object sender, EventArgs e)
        {
            // txtUrlForPanel2.Left = splitContainer.Panel2.Left;
        }

        private void TxtUrlForPanel2_ClientSizeChanged(object sender, EventArgs e)
        {
            //txtUrlForPanel2.Left = splitContainer.Panel2.Left;
        }

        private void SplitContainer_Panel2_ClientSizeChanged(object sender, EventArgs e)
        {
            //txtUrlForPanel2.Left = splitContainer.Panel2.Left;
        }

        private void txtUrlForPanel3_Leave(object sender, EventArgs e)
        {
            ChangeUrl(sender, chromeBrowser3);
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            zoom = zoom + zoomLevel;
            chromeBrowser1.SetZoomLevel(zoom);
            chromeBrowser2.SetZoomLevel(zoom);
            chromeBrowser3.SetZoomLevel(zoom);
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            try
            {
                zoom = zoom - zoomLevel;
                chromeBrowser1.SetZoomLevel(zoom);
                chromeBrowser2.SetZoomLevel(zoom);
                chromeBrowser3.SetZoomLevel(zoom);
            }
            catch { }
        }
    }
}

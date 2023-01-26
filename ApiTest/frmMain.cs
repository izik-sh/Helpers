using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace ApiTest
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Init();
            Run();
        }

        private void Init()
        {
            toolStripStatusLabel.Text = String.Empty;
        }

        private void Run()
        {

            try
            {
                int ResponseCode;


                WebRequest myWebRequest = WebRequest.Create(txtUrl.Text);
                myWebRequest.UseDefaultCredentials = true;

                WebProxy myProxy = new WebProxy();

                // Create a new Uri object.
                //Uri newUri = new Uri("https://boi.org.il/PublicApi/GetExchangeRates?asXml=true");

                // Associate the new Uri object to the myProxy object.
                //myProxy.Address = newUri;

                // Create a NetworkCredential object and is assign to the Credentials property of the Proxy object.
                //myProxy.Credentials = new NetworkCredential(Settings.GetAppSettingsValue("C4E.RATE.USER").ToString(),
                //                                            Settings.GetAppSettingsValue("C4E.RATE.PASSWORD").ToString(),
                //                                            Settings.GetAppSettingsValue("C4E.RATE.DOMAIN").ToString());
                //myWebRequest.Proxy = myProxy;

                //myProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

                if (chkTLS.Checked)
                {
                    ServicePointManager.Expect100Continue = true;
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                }
                //System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                if (chkServerCertificateValidationCallback.Checked)
                {
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                }
                //ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => true;


                XmlDocument document = new XmlDocument();
                string output = string.Empty;

                using (WebResponse response = myWebRequest.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    ResponseCode = (int)((HttpWebResponse)response).StatusCode;
                    if (ResponseCode > 0)
                    {
                        try
                        {
                            document.LoadXml(responseFromServer);
                            output = System.Xml.Linq.XDocument.Parse(document.InnerXml).ToString();
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                #region Old tests
                                // dynamic
                                //dynamic json = JsonConvert.DeserializeObject(responseFromServer);

                                // single    
                                //ExchangeRate rate = JsonConvert.DeserializeObject<ExchangeRate>(responseFromServer);

                                // list
                                //List<ExchangeRate> exchangeRates = JsonConvert.DeserializeObject<List<ExchangeRate>>(responseFromServer);
                                //var RootObject datalist = JsonConvert.DeserializeObject<RootObject>(responseFromServer);
                                //var datalist = JsonConvert.DeserializeObject<List<RootObject>>(responseFromServer);

                                //JavaScriptSerializer j = new JavaScriptSerializer();
                                //object a = j.Deserialize(responseFromServer, typeof(object));

                                //var model = JsonConvert.DeserializeObject<ExchangeRate>(responseFromServer);

                                //dynamic myObject = JValue.Parse(responseFromServer);
                                //foreach (dynamic questions in myObject)
                                //{
                                //    //Console.WriteLine(questions.Question.QuestionId + "." + questions.Question.QuestionText.ToString());
                                //}

                                ////List<dynamic> models = JsonConvert.DeserializeObject<List<dynamic>>(responseFromServer);
                                //var des = (ExchangeRate)Newtonsoft.Json.JsonConvert.DeserializeObject(responseFromServer, typeof(ExchangeRate));
                                //var objectWithFields = JsonConvert.DeserializeObject<dynamic[]>(responseFromServer);
                                //List<ExchangeRate> objResponse1 = JsonConvert.DeserializeObject<List<ExchangeRate>>(responseFromServer);
                                //ExchangeRate[] items = JsonConvert.DeserializeObject<ExchangeRate[]>(responseFromServer);
                                #endregion

                                Root root = JsonConvert.DeserializeObject<Root>(responseFromServer);

                            }
                            catch (Exception exc)
                            {
                                toolStripStatusLabel.Text = exc.ToString();
                            }
                            output = responseFromServer;
                        }
                    }

                    reader.Close();
                    dataStream.Close();
                    response.Close();

                    txtResults.Text = output;
                    toolStripStatusLabel.Text = "Operation performed successfully";
                    //MessageBox.Show("Success to connect " + txtUrl.Text);
                }

            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = ex.Message;
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Run();
        }


    }
}

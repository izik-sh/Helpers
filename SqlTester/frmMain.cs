using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlTester
{
    public partial class frmMain : Form
    {
        string filePath = Environment.CurrentDirectory + @"\setting.ini";

        public frmMain()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                txtDataSource.Text = lines[0];
                txtInitialCatalog.Text = lines[1];
                txtUserId.Text = lines[2];
                txtPassword.Text = lines[3];
                txtQuery.Text = lines[4].Replace("___NEW_LINE___",Environment.NewLine);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                SaveParams();

                string connectionString = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", txtDataSource.Text, txtInitialCatalog.Text, txtUserId.Text, txtPassword.Text);
                DataTable dt = DBHelper.GetDataTable(txtQuery.Text, null, null, false, connectionString);
                gvData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveParams()
        {
            string[] lines = { txtDataSource.Text, txtInitialCatalog.Text, txtUserId.Text, txtPassword.Text, txtQuery.Text.Replace(Environment.NewLine,"___NEW_LINE___") };
            System.IO.File.WriteAllLines(filePath, lines);
        }
    }
}

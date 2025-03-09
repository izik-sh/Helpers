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
    public partial class frmDataCompare : Form
    {
        public frmDataCompare()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            string connectionString = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", "mssql30.1host.co.il", "izik-sh_pDB", "izik-sh_dbadmin", "opendoor");

            DataTable dt = DBHelper.GetDataTable("select * from sys.databases", null, null, false, connectionString);
        }
    }
}

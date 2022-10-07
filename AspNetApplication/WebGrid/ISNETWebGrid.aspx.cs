using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ISNETWebGrid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("A", System.Type.GetType("System.Int32"));
        dt.Columns.Add("B");
        dt.Columns.Add("C");

        DataColumnCollection columns = dt.Columns;
        bool isColumnExists = columns.Contains("A");
        isColumnExists = columns.Contains("a");
        isColumnExists = columns.Contains("d");
        DataRow dataRow = dt.NewRow();
        dataRow["A"] = 1;
        dataRow["B"] = 11;
        dataRow["C"] = 5;
        dt.Rows.Add(dataRow);

        dataRow = dt.NewRow();
        dataRow["A"] = 2;
        dataRow["B"] = 22;
        dataRow["C"] = 5;
        dt.Rows.Add(dataRow);

        dataRow = dt.NewRow();
        dataRow["A"] = 20;
        dataRow["B"] = 22;
        dataRow["C"] = 5;
        dt.Rows.Add(dataRow);

        WebGrid1.DataSource = dt;
        WebGrid1.DataBind();
    }
}
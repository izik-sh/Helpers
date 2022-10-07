using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebGrid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("a");
        dt.Columns.Add("b");
        dt.Columns.Add("c");

        DataRow row = dt.NewRow();
        row["a"] = "a";
        row["b"] = "b";
        row["c"] = "c";

        dt.Rows.Add(row);

        row = dt.NewRow();
        row["a"] = "a1";
        row["b"] = "b2";
        row["c"] = "c3";

        dt.Rows.Add(row);

        wgData.DataSource = dt;
        wgData.DataBind();

        wgTransactions.DataSource = dt;



    }

    protected void wgTransactions_InitializeDataSource(object sender, ISNet.WebUI.WebGrid.DataSourceEventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("a");
        dt.Columns.Add("b");
        dt.Columns.Add("c");

        DataRow row = dt.NewRow();
        row["a"] = "a";
        row["b"] = "b";
        row["c"] = "c";

        dt.Rows.Add(row);

    


        return;
        e.DataSource = dt;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DropDown : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlMain.Items.Clear();
            ddlMain.Items.Add(new ListItem("1", "1"));
            ddlMain.Items.Add(new ListItem("2", "2"));
            ddlMain.Items.Add(new ListItem("3", "3"));

            ddlMain.SelectedIndex = 0;

        }

    }

    protected void btnRun_Click(object sender, EventArgs e)
    {
        ddlMain.SelectedIndex = 1;
    }
}
using HelperClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FileUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        var reader = new StreamReader(fileUpload.PostedFile.InputStream)
        {

        }.ReadToEnd();

        StreamReader streamReader = new StreamReader(fileUpload.PostedFile.InputStream);

        DataTable dt = CSVHelper.ConvertCSVtoDataTable(streamReader);

        //Create a DataTable.
        //DataTable dt = CSVHelper.CSVHelper.ConvertCSVtoDataTable(reader);
        //DataTable dt = CSVHelper.CSVHelper.ConvertCSVtoDataTable(new StreamReader(fileUpload.PostedFile.InputStream));


    }
}
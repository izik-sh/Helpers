using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetApplication
{
    public partial class _Default : Page
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

            dt.TableName = "izik";

            object sumObject;
            sumObject = dt.Compute("Sum(A)", "C = 5 and B = 22");

            //string fileName = Guid.NewGuid().ToString() + ".xls";
            //Test(dt, fileName);

            string fileName = Guid.NewGuid().ToString() + ".csv";
            CSV(dt, fileName);

            return;

            //SpreadsheetDocument spreadsheetDocument =
            //    SpreadsheetDocument.Create(filepath, SpreadsheetDocumentType.Workbook);
            ////System.IO.MemoryStream stream = new System.IO.MemoryStream();
            //System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //formatter.Serialize(stream, dt); // dtUsers is a DataTable

            //byte[] bytes = stream.GetBuffer();

            byte[] bytes = ConvertDataSetToByteArray(dt);
            //Stream stream = new MemoryStream(bytes);
            //SpreadsheetDocument spreadsheetDocument =
            //SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);


            string contentType = "application/vnd.ms-excel";
            //contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            //byte[] bytes = Convert.FromBase64String(Convert.ToString(dt.Rows[0]["bytearr"]));
            Response.Clear();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);

            GridView ResultGrid = new GridView();
            ResultGrid.DataSource = dt;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            ResultGrid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
            Response.Flush();

            //var package = new ExcelPackage();

            Response.BinaryWrite(bytes);
            ////            Response.BufferOutput = true;
            ////Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.Flush();
            Response.End();
        }

        private byte[] ConvertDataSetToByteArray(DataTable dataTable)
        {
            byte[] binaryDataResult = null;
            using (MemoryStream memStream = new MemoryStream())
            {
                BinaryFormatter brFormatter = new BinaryFormatter();
                dataTable.RemotingFormat = SerializationFormat.Binary;
                brFormatter.Serialize(memStream, dataTable);
                binaryDataResult = memStream.ToArray();
            }
            return binaryDataResult;
        }

        private void Test(DataTable dt,string fileName)
        {
            //Create a dummy GridView
            GridView gvData = new GridView();
            gvData.AllowPaging = false;
            gvData.DataSource = dt;
            gvData.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=" + fileName);
            Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.ContentType = "application/ms-excel";

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < gvData.Rows.Count; i++)
            {
                //Apply text style to each Row
                gvData.Rows[i].Attributes.Add("class", "textmode");
            }

            gvData.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";

            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        private void CSV(DataTable dt,string fileName)
        {
            CSVExportUtility.OpenAsCSV(dt, fileName);
        }



    }
}
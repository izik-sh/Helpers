using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperClasses
{
    public class ExcelHelper
    {        public static void RunTest()
        {
            // Create a DataTable with four columns
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Sex", typeof(string));
            table.Columns.Add("CreatedDate", typeof(string));
            table.Columns.Add("City", typeof(string));

            // Add five DataRows
            table.Rows.Add(25, "Devesh Omar", "M", DateTime.Now, "Noida");
            table.Rows.Add(50, "Nikhil Vats", "M", DateTime.Now, "Noida");
            table.Rows.Add(10, "Heena Sharma", "F", DateTime.Now, "Delhi");
            table.Rows.Add(21, "Nancy Sharma", "F", DateTime.Now, "Delhi");
            table.Rows.Add(100, "Avinash", "M", DateTime.Now, "Delhi");
            table.Rows.Add(25, "Devesh gupta", "M", DateTime.Now, "Delhi");
            table.Rows.Add(50, "Nikhil gupta", "M", DateTime.Now, "Noida");
            table.Rows.Add(10, "HS gupta", "F", DateTime.Now, "Delhi");
            table.Rows.Add(21, "VS gupta", "F", DateTime.Now, "Delhi");
            table.Rows.Add(100, "RJ gupta", "M", DateTime.Now, "Delhi");

            ExportDataTableToExcel(table);
        }

        public static bool ExportDataTableToExcel(DataTable dt)
        {
            bool results = false;

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            // Start Excel and get Application object.
            excel = new Microsoft.Office.Interop.Excel.Application();

            // Make Excel invisible and disable alerts.
            excel.Visible = false;
            excel.DisplayAlerts = false;

            // Create a new Workbook.
            excelworkBook = excel.Workbooks.Add(Type.Missing);

            // Create a Worksheet.
            excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
            excelSheet.Name = "Test work sheet";

            excelSheet.Cells[1, 1] = "Sample test data";
            excelSheet.Cells[1, 2] = "Date : " + DateTime.Now.ToShortDateString();
            excelSheet.Cells[1, 3] = 4;
            excelSheet.Cells[2, 3] = 5.678;
            // now we resize the columns
            excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[dt.Rows.Count, dt.Columns.Count]];
            excelCellrange.EntireColumn.AutoFit();
            Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
            border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            border.Weight = 2d;
            FormattingExcelCells(excelCellrange, "#ffffff",Color.Red, true);

            excelworkBook.SaveAs(@"c:\temp\" + Guid.NewGuid().ToString() + ".xls");

            return results;
        }


        public static void FormattingExcelCells(Microsoft.Office.Interop.Excel.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool IsFontbool)
        {
            range.Interior.Color = System.Drawing.ColorTranslator.FromHtml(HTMLcolorCode);
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
            if (IsFontbool == true)
            {
                range.Font.Bold = IsFontbool;
            }
        }
    }
}

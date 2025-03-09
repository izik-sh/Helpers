//using iTextSharp.text.pdf;
using Spire.Pdf;
using Spire.Pdf.Texts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Winforms
{
    public partial class frmReadDocuments : Form
    {
        public frmReadDocuments()
        {
            InitializeComponent();
            //ReadPDF();
            //ReadPDFSpire();
        }

        private void ReadPDFSpire(string fileName)
        {
            //Create a PdfDocument object
            PdfDocument doc = new PdfDocument();

            //Load a PDF file
            doc.LoadFromFile(fileName);

            //Get the second page
            PdfPageBase page = doc.Pages[0];

            //Create a PdfTextExtractot object
            PdfTextExtractor textExtractor = new PdfTextExtractor(page);

            //Create a PdfTextExtractOptions object
            PdfTextExtractOptions extractOptions = new PdfTextExtractOptions();

            //Set isExtractAllText to true
            extractOptions.IsExtractAllText = true;
            extractOptions.IsSimpleExtraction= true;
            extractOptions.IsShowHiddenText= true;

            //Extract text from the page
            string text = textExtractor.ExtractText(extractOptions);

            //Write to a txt file
            File.WriteAllText(@"c:\temp\Extracted.txt", text);
            txtResults.Text = text;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            var FD = new System.Windows.Forms.OpenFileDialog();
            FD.InitialDirectory = @"c:\temp\";

            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = FD.FileName;
                txtFileName.Text = fileToOpen;

                ReadPDFSpire(fileToOpen);
                System.IO.FileInfo File = new System.IO.FileInfo(FD.FileName);

                //OR

                System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);
                //etc
            }
        }

        //private void ReadPDF()
        //{

        //    PDFParser pdfParser = new PDFParser();
        //    pdfParser.ExtractText(@"c:\temp\bazan1.pdf", @"c:\temp\bazantext.txt");

        //    return;
        //    // Create a reader from the file bytes.
        //    var reader = new PdfReader(File.ReadAllBytes(@"c:\temp\bazan1.pdf"));

        //    for (var pageNum = 1; pageNum <= reader.NumberOfPages; pageNum++)
        //    {
        //        // Get the page content and tokenize it.
        //        var contentBytes = reader.GetPageContent(pageNum);
        //        var tokenizer = new PRTokeniser(new RandomAccessFileOrArray(contentBytes));


        //        var stringsList = new List<string>();
        //        while (tokenizer.NextToken())
        //        {
        //            if (tokenizer.TokenType == PRTokeniser.TokType.STRING)
        //            {
        //                // Extract string tokens.
        //                stringsList.Add(tokenizer.StringValue);
        //            }
        //        }

        //        // Print the set of string tokens, one on each line.
        //        Console.WriteLine(string.Join("\r\n", stringsList));
        //    }

        //    reader.Close();
        //}
    }
}


//-------------


/// <summary>
/// Parses a PDF file and extracts the text from it.
/// </summary>
//public class PDFParser
//{
//    /// BT = Beginning of a text object operator 
//    /// ET = End of a text object operator
//    /// Td move to the start of next line
//    ///  5 Ts = superscript
//    /// -5 Ts = subscript

//    #region Fields

//    #region _numberOfCharsToKeep
//    /// <summary>
//    /// The number of characters to keep, when extracting text.
//    /// </summary>
//    private static int _numberOfCharsToKeep = 15;
//    #endregion

//    #endregion

//    #region ExtractText
//    /// <summary>
//    /// Extracts a text from a PDF file.
//    /// </summary>
//    /// <param name="inFileName">the full path to the pdf file.</param>
//    /// <param name="outFileName">the output file name.</param>
//    /// <returns>the extracted text</returns>
//    public bool ExtractText(string inFileName, string outFileName)
//    {
//        StreamWriter outFile = null;
//        try
//        {
//            // Create a reader for the given PDF file
//            PdfReader reader = new PdfReader(inFileName);
//            //outFile = File.CreateText(outFileName);
//            outFile = new StreamWriter(outFileName, false, System.Text.Encoding.UTF8);

//            Console.Write("Processing: ");

//            int totalLen = 68;
//            float charUnit = ((float)totalLen) / (float)reader.NumberOfPages;
//            int totalWritten = 0;
//            float curUnit = 0;

//            for (int page = 1; page <= reader.NumberOfPages; page++)
//            {
//                outFile.Write(ExtractTextFromPDFBytes(reader.GetPageContent(page)) + " ");

//                // Write the progress.
//                if (charUnit >= 1.0f)
//                {
//                    for (int i = 0; i < (int)charUnit; i++)
//                    {
//                        Console.Write("#");
//                        totalWritten++;
//                    }
//                }
//                else
//                {
//                    curUnit += charUnit;
//                    if (curUnit >= 1.0f)
//                    {
//                        for (int i = 0; i < (int)curUnit; i++)
//                        {
//                            Console.Write("#");
//                            totalWritten++;
//                        }
//                        curUnit = 0;
//                    }

//                }
//            }

//            if (totalWritten < totalLen)
//            {
//                for (int i = 0; i < (totalLen - totalWritten); i++)
//                {
//                    Console.Write("#");
//                }
//            }
//            return true;
//        }
//        catch
//        {
//            return false;
//        }
//        finally
//        {
//            if (outFile != null) outFile.Close();
//        }
//    }
//    #endregion

//    #region ExtractTextFromPDFBytes
//    /// <summary>
//    /// This method processes an uncompressed Adobe (text) object 
//    /// and extracts text.
//    /// </summary>
//    /// <param name="input">uncompressed</param>
//    /// <returns></returns>
//    private string ExtractTextFromPDFBytes(byte[] input)
//    {
//        if (input == null || input.Length == 0) return "";

//        try
//        {
//            string resultString = "";

//            // Flag showing if we are we currently inside a text object
//            bool inTextObject = false;

//            // Flag showing if the next character is literal 
//            // e.g. '\\' to get a '\' character or '\(' to get '('
//            bool nextLiteral = false;

//            // () Bracket nesting level. Text appears inside ()
//            int bracketDepth = 0;

//            // Keep previous chars to get extract numbers etc.:
//            char[] previousCharacters = new char[_numberOfCharsToKeep];
//            for (int j = 0; j < _numberOfCharsToKeep; j++) previousCharacters[j] = ' ';


//            for (int i = 0; i < input.Length; i++)
//            {
//                char c = (char)input[i];

//                if (inTextObject)
//                {
//                    // Position the text
//                    if (bracketDepth == 0)
//                    {
//                        if (CheckToken(new string[] { "TD", "Td" }, previousCharacters))
//                        {
//                            resultString += "\n\r";
//                        }
//                        else
//                        {
//                            if (CheckToken(new string[] { "'", "T*", "\"" }, previousCharacters))
//                            {
//                                resultString += "\n";
//                            }
//                            else
//                            {
//                                if (CheckToken(new string[] { "Tj" }, previousCharacters))
//                                {
//                                    resultString += " ";
//                                }
//                            }
//                        }
//                    }

//                    // End of a text object, also go to a new line.
//                    if (bracketDepth == 0 &&
//                        CheckToken(new string[] { "ET" }, previousCharacters))
//                    {

//                        inTextObject = false;
//                        resultString += " ";
//                    }
//                    else
//                    {
//                        // Start outputting text
//                        if ((c == '(') && (bracketDepth == 0) && (!nextLiteral))
//                        {
//                            bracketDepth = 1;
//                        }
//                        else
//                        {
//                            // Stop outputting text
//                            if ((c == ')') && (bracketDepth == 1) && (!nextLiteral))
//                            {
//                                bracketDepth = 0;
//                            }
//                            else
//                            {
//                                // Just a normal text character:
//                                if (bracketDepth == 1)
//                                {
//                                    // Only print out next character no matter what. 
//                                    // Do not interpret.
//                                    if (c == '\\' && !nextLiteral)
//                                    {
//                                        nextLiteral = true;
//                                    }
//                                    else
//                                    {
//                                        if (((c >= ' ') && (c <= '~')) ||
//                                            ((c >= 128) && (c < 255)))
//                                        {
//                                            resultString += c.ToString();
//                                        }

//                                        nextLiteral = false;
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }

//                // Store the recent characters for 
//                // when we have to go back for a checking
//                for (int j = 0; j < _numberOfCharsToKeep - 1; j++)
//                {
//                    previousCharacters[j] = previousCharacters[j + 1];
//                }
//                previousCharacters[_numberOfCharsToKeep - 1] = c;

//                // Start of a text object
//                if (!inTextObject && CheckToken(new string[] { "BT" }, previousCharacters))
//                {
//                    inTextObject = true;
//                }
//            }
//            return resultString;
//        }
//        catch
//        {
//            return "";
//        }
//    }
//    #endregion

//    #region CheckToken
//    /// <summary>
//    /// Check if a certain 2 character token just came along (e.g. BT)
//    /// </summary>
//    /// <param name="search">the searched token</param>
//    /// <param name="recent">the recent character array</param>
//    /// <returns></returns>
//    private bool CheckToken(string[] tokens, char[] recent)
//    {
//        foreach (string token in tokens)
//        {
//            if ((recent[_numberOfCharsToKeep - 3] == token[0]) &&
//                (recent[_numberOfCharsToKeep - 2] == token[1]) &&
//                ((recent[_numberOfCharsToKeep - 1] == ' ') ||
//                (recent[_numberOfCharsToKeep - 1] == 0x0d) ||
//                (recent[_numberOfCharsToKeep - 1] == 0x0a)) &&
//                ((recent[_numberOfCharsToKeep - 4] == ' ') ||
//                (recent[_numberOfCharsToKeep - 4] == 0x0d) ||
//                (recent[_numberOfCharsToKeep - 4] == 0x0a))
//                )
//            {
//                return true;
//            }
//        }
//        return false;
//    }
//    #endregion
//}




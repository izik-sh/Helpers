// See https://aka.ms/new-console-template for more information

#region Culture
using System.Globalization;

try
{
    string datetimestring = "14/5/2023";
    DateTime dateValue;
    CultureInfo culture = CultureInfo.CurrentCulture;
    DateTimeStyles styles = DateTimeStyles.None;
    DateTime.TryParse(datetimestring, culture, styles, out dateValue);

    DateTime date = new DateTime();
    try
    {
        string CurrentPattern = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
        string[] Split = new string[] { "-", "/", @"\", "." };
        string[] Patternvalue = CurrentPattern.Split(Split, StringSplitOptions.None);
        string[] DateSplit = datetimestring.Split(Split, StringSplitOptions.None);
        string NewDate = "";
        if (Patternvalue[0].ToLower().Contains("d") == true && Patternvalue[1].ToLower().Contains("m") == true && Patternvalue[2].ToLower().Contains("y") == true)
        {
            NewDate = DateSplit[1] + "/" + DateSplit[0] + "/" + DateSplit[2];
        }
        else if (Patternvalue[0].ToLower().Contains("m") == true && Patternvalue[1].ToLower().Contains("d") == true && Patternvalue[2].ToLower().Contains("y") == true)
        {
            NewDate = DateSplit[0] + "/" + DateSplit[1] + "/" + DateSplit[2];
        }
        else if (Patternvalue[0].ToLower().Contains("y") == true && Patternvalue[1].ToLower().Contains("m") == true && Patternvalue[2].ToLower().Contains("d") == true)
        {
            NewDate = DateSplit[2] + "/" + DateSplit[0] + "/" + DateSplit[1];
        }
        else if (Patternvalue[0].ToLower().Contains("y") == true && Patternvalue[1].ToLower().Contains("d") == true && Patternvalue[2].ToLower().Contains("m") == true)
        {
            NewDate = DateSplit[2] + "/" + DateSplit[1] + "/" + DateSplit[0];
        }
        date = DateTime.Parse(NewDate, Thread.CurrentThread.CurrentCulture);
    }
    catch (Exception ex)
    {

    }
    finally
    {

    }



}
catch (Exception ex)
{

}
#endregion

return;

#region Get HTML Content
string urlToRead = "https://ethos.smarticket.co.il/iframe/רוקולנוע_לייב_%7C_להקת_הכבשים-_מופע_מחווה_ל_כבש_ה16_?id=21776";
string htmlHelperResults = HtmlHelper.HtmlHelper.GetHtmlContentFromUrl(urlToRead);
#endregion

#region Strings
//using Microsoft.Extensions.Configuration;
//using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
//using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;

string strForPadding = "izik";
string a = strForPadding.PadLeft(10);
string b = strForPadding.PadRight(10);
#endregion

#region TimeOut

var response = TimeOut.RunTaskWithTimeout<bool>(
        (Func<bool>)delegate { return SomeMethod(); }, 5);
try
{
    TimeOutFramwork4_0.TimeOutFramwork4_0.CallTimedOutMethod(SomeMethod2, Error, 5000);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
bool SomeMethod()
{
    Thread.Sleep(1000);
    Console.WriteLine("Finished SomeMethod");
    return true;
}

void SomeMethod2()
{
    try
    {
        Thread.Sleep(1000);
        Console.WriteLine("Finished SomeMethod2");
    }
    catch (System.Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void Error()
{
    Console.WriteLine("Timeout");
}
#endregion

#region ExtensionMethods
#region Demo 1
string str = "hello world";

str = str.RemoveChar("l");
Console.WriteLine(str);
#endregion

#region Demo 2
string strHebrew = "שלום";
string strEnglish = "hello";

Console.WriteLine("Is strHebrew is english ? " + strHebrew.IsEnglishWord());
Console.WriteLine("Is strEnglish is english ? " + strEnglish.IsEnglishWord());
#endregion

#region Demo 3
string formatedDate = DateTime.Now.GetMonthAndYearForamted("MM-yyyy");
#endregion
#endregion

#region Email
string from = "myEmail@gmail.com";
string to = "izik.shtemer@gmail.com";
string subject = "Hello mike";
string body = "Hello world";
string mailServer = "smtp.gmail.com";
string emailUserName = "emailUserName";
string emailPassword = "emailPassword";

#region Demo 1
bool results = Email.SendEmail(from, to, subject, body);
Console.WriteLine("Send mail results: " + results);
#endregion

#region Demo 2
results = Email.SendEmail(from, to, subject, body, mailServer, emailUserName, emailPassword);
Console.WriteLine("Send mail results: " + results);
#endregion
#endregion

#region Json
string url = "https://jsonplaceholder.typicode.com/todos/1";
string json = "{\"user\":\"test\"," +
                 "\"password\":\"bla\"}";
results = PostJson.Post(url, json);
Console.WriteLine(results.ToString());

Task task = PostJson.PostAsHttpClient(url, json);
Console.WriteLine(task.Status.ToString());

json = "{\"user\":\"test\"," +
                 "\"שם משתמש\":\"bla\"}";
results = PostJson.Post(url, json);


#endregion

#region WCF Service
SVC.ServiceClient svc = new SVC.ServiceClient();

svc.GetData(new SVC.GetDataRequest());
#endregion

#region Configuration objects - 

//IConfigurationSource configSource = ConfigurationSourceFactory.Create();
//var logSettings = configSource.GetSection(LoggingSettings.SectionName) as LoggingSettings;

//var flatFileTraceListener = logSettings.TraceListeners
//    .First(t => t is FlatFileTraceListenerData) as FlatFileTraceListenerData;

//string fileName = flatFileTraceListener.FileName;

//IConfigurationSource configSource2 = ConfigurationSourceFactory.Create();
//var logSettings2 = configSource.GetSection(LoggingSettings.SectionName) as LoggingSettings;

//var flatFileTraceListener2 = logSettings.TraceListeners
//    .FirstOrDefault(t => t is FlatFileTraceListenerData && t.Name == "Flat File Trace Listener")
//    as FlatFileTraceListenerData;

//string fileName2 = flatFileTraceListener.FileName;
#endregion

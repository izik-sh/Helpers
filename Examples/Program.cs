// See https://aka.ms/new-console-template for more information
#region Strings
using Microsoft.Extensions.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;

string strFroPadding = "izik";
string a = strFroPadding.PadLeft(10);
string b = strFroPadding.PadRight(10);
#endregion

#region TimeOut

var response = TimeOut.RunTaskWithTimeout<bool>(
        (Func<bool>)delegate { return SomeMethod(); }, 5);
try
{
    TimeOutFramwork4_0.TimeOutFramwork4_0.CallTimedOutMethod(SomeMethod2, Error, 5000);
}
catch(Exception ex)
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
    catch(System.Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void Error()
{
    Console.WriteLine("Timeout");
}
#endregion

return;

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

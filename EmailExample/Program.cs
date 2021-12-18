// See https://aka.ms/new-console-template for more information

#region Email
string from = "myEmail@gmail.com";
string to = "izik.shtemer@gmail.com";
string subject = "Hello mike";
string body = "Hello world";
string mailServer = "smtp.gmail.com";
string emailUserName = "emailUserName";
string emailPassword = "emailPassword";

bool results = Email.SendEmail(from, to, subject, body);
results = Email.SendEmail(from, to, subject, body, mailServer, emailUserName, emailPassword);
Console.WriteLine(results);
#endregion

#region ExtensionMethods
string str = "hello world";
str = str.RemoveChar("l");
Console.WriteLine(str);
#endregion

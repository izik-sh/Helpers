// See https://aka.ms/new-console-template for more information

string from = "myEmail@gmail.com";
string to = "izik.shtemer@gmail.com";
string subject = "Hello mike";
string body = "Hello world";
string mailServer = "smtp.gmail.com";
string emailUserName = "emailUserName";
string emailPassword = "emailPassword";

bool results = Email.SendEmail(from, to,subject, body,mailServer,emailUserName,emailPassword);


using System.Net;
using System.Net.Mail;

public class Email
{
    public static bool SendEmail(string from, string to, string subject, string body, string server, string emailUserName, string emailPassword)
    {
        bool results = false;

        MailMessage message = new MailMessage(from, to);
        message.Subject = subject;
        message.Body = body;

        #region Credentials Version 1
        // If credentials are not necessary use this instead of Credentials Version 2 or 3
        //client.UseDefaultCredentials = true;
        #endregion

        #region Credentials Version 2
        SmtpClient client = new SmtpClient(server);
        client.Port = 587;
        client.Credentials = new NetworkCredential(emailUserName, emailPassword);
        client.EnableSsl = true;
        #endregion

        #region Credentials Version 3
        //var smtpClient = new SmtpClient(server)
        //{
        //    Port = 587,
        //    Credentials = new NetworkCredential(emailUserName, emailPassword),
        //    EnableSsl = true,
        //};
        #endregion



        try
        {
            client.Send(message);
            results = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught in CreateTestMessage2(): {0}", ex.ToString());
        }

        return results;
    }
}

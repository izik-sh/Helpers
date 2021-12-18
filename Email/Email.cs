using System.Configuration;
using System.Net;
using System.Net.Mail;

public class Email
{
    /// <summary>
    /// SendEmail
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="subject"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    public static bool SendEmail(string from, string to, string subject, string body)
    {
        bool results = false;

        string? server = ConfigurationManager.AppSettings["Server"];
        string? emailUserName = ConfigurationManager.AppSettings["EmailUserName"];
        string? emailPassword = ConfigurationManager.AppSettings["EmailPassword"];
        

        if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(emailUserName) || string.IsNullOrEmpty(emailPassword))
        {
            return results;
        }

        MailMessage message = new MailMessage(from, to);
        message.Subject = subject;
        message.Body = body;
        message.IsBodyHtml = true;

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
            Console.WriteLine(ex.Message);
        }

        return results;
    }

    /// <summary>
    /// SendEmail
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="subject"></param>
    /// <param name="body"></param>
    /// <param name="server"></param>
    /// <param name="emailUserName"></param>
    /// <param name="emailPassword"></param>
    /// <returns></returns>
    public static bool SendEmail(string from, string to, string subject, string body, string server, string emailUserName, string emailPassword)
    {
        bool results = false;

        MailMessage message = new MailMessage(from, to);
        message.Subject = subject;
        message.Body = body;
        message.IsBodyHtml = true;

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
            Console.WriteLine(ex.Message);
        }

        return results;
    }
}

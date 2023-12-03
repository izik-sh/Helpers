using OpenPop.Mime;
using OpenPop.Pop3;
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

    public static void GetMail()
    {
        var client = new Pop3Client();
        client.Connect("pop.gmail.com", 995, true);
        client.Authenticate("izik.shtemer@gmail.com", "rkwnjxfrfttbjygy");
        var count = client.GetMessageCount();
        Message message = client.GetMessage(1);
        Console.WriteLine(message.Headers.Subject);
        Console.WriteLine(message.MessagePart.GetBodyAsText());
        Console.WriteLine(message.Headers.Date.ToString());

        //List<Message> list = FetchAllMessages("pop.gmail.com", 995, true, "izik.shtemer@gmail.com", "rkwnjxfrfttbjygy");

        List<string> seenUids = new List<string>();
        List<Message> list = FetchUnseenMessages("pop.gmail.com", 995, true, "izik.shtemer@gmail.com", "rkwnjxfrfttbjygy", seenUids);

    }


    public static List<Message> FetchAllMessages(string hostname, int port, bool useSsl, string username, string password)
    {
        // The client disconnects from the server when being disposed
        using (Pop3Client client = new Pop3Client())
        {
            // Connect to the server
            client.Connect(hostname, port, useSsl);

            // Authenticate ourselves towards the server
            client.Authenticate(username, password);

            // Get the number of messages in the inbox
            int messageCount = client.GetMessageCount();

            // We want to download all messages
            List<Message> allMessages = new List<Message>(messageCount);

            // Messages are numbered in the interval: [1, messageCount]
            // Ergo: message numbers are 1-based.
            // Most servers give the latest message the highest number
            for (int i = messageCount; i > 0; i--)
            {
                allMessages.Add(client.GetMessage(i));
            }

            // Now return the fetched messages
            return allMessages;
        }
    }

    public static List<Message> FetchUnseenMessages(string hostname, int port, bool useSsl, string username, string password, List<string> seenUids)
    {
        // The client disconnects from the server when being disposed
        using (Pop3Client client = new Pop3Client())
        {
            // Connect to the server
            client.Connect(hostname, port, useSsl);

            // Authenticate ourselves towards the server
            client.Authenticate(username, password);

            // Fetch all the current uids seen
            List<string> uids = client.GetMessageUids();

            // Create a list we can return with all new messages
            List<Message> newMessages = new List<Message>();

            // All the new messages not seen by the POP3 client
            for (int i = 0; i < uids.Count; i++)
            {
                string currentUidOnServer = uids[i];
                if (!seenUids.Contains(currentUidOnServer))
                {
                    // We have not seen this message before.
                    // Download it and add this new uid to seen uids

                    // the uids list is in messageNumber order - meaning that the first
                    // uid in the list has messageNumber of 1, and the second has 
                    // messageNumber 2. Therefore we can fetch the message using
                    // i + 1 since messageNumber should be in range [1, messageCount]
                    Message unseenMessage = client.GetMessage(i + 1);

                    // Add the message to the new messages
                    newMessages.Add(unseenMessage);

                    // Add the uid to the seen uids, as it has now been seen
                    seenUids.Add(currentUidOnServer);
                }
            }

            // Return our new found messages
            return newMessages;
        }
    }

}

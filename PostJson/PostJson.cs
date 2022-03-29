using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

public class PostJson
{
    /// <summary>
    /// Post json data
    /// </summary>
    /// <param name="url"></param>
    /// <param name="json"></param>
    /// <returns></returns>
    public static bool Post(string url, string json,string contentType = "application/json")
    {
        bool results = false;

        try
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = contentType;
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var res = streamReader.ReadToEnd();
                if (res.ToUpper() == "OK")
                {
                    results = true;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return results;
    }

    static readonly HttpClient client = new HttpClient();

    public static async Task PostAsHttpClient(string url, string json)
    {
        // Call asynchronous network methods in a try/catch block to handle exceptions.
        try
        {
            await client.PostAsync(url,
                                   new StringContent(
                                   json,
                                   Encoding.UTF8,
                                   "application/json"));

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            // Above three lines can be replaced with new helper method below
            // string responseBody = await client.GetStringAsync(uri);

            Console.WriteLine(responseBody);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
    }
}

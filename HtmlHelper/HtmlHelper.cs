namespace HtmlHelper
{
    public class HtmlHelper
    {

        public static string GetHtmlContentFromUrl(string url)
        {
            string result = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        result = content.ReadAsStringAsync().Result;
                    }
                }
            }

            return result;

        }
    }
}
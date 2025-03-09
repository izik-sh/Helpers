using HtmlHelper;
using Microsoft.Playwright;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HtmlCompare
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<string> urls = new List<string>();
            urls.Add("https://www.eventer.co.il/3580f");
            //urls.Add("https://www.eventer.co.il/vw80f");

            foreach (string url in urls)
            {
                // Initialize ChromeDriver
                IWebDriver driver = new ChromeDriver();

                // Navigate to the page
                driver.Navigate().GoToUrl(url);

                // Wait for the page to load completely (or you can use WebDriverWait for more precise control)
                System.Threading.Thread.Sleep(5000);  // Wait for 5 seconds (adjust as needed)

                // Get the final rendered HTML
                string currentHtml = driver.PageSource;
                //// Launch Playwright browser
                //var playwright = await Playwright.CreateAsync();
                //var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
                //var page = await browser.NewPageAsync();

                //// Navigate to the page
                //await page.GotoAsync(url);

                //// Wait for some element or the page to load completely (you can specify your waiting criteria here)
                //await page.WaitForSelectorAsync("body");

                //// Get the final rendered HTML
                //string renderedHtml = await page.ContentAsync();

                //Console.WriteLine("Final Rendered HTML:");
                //Console.WriteLine(renderedHtml);

                //// Close the browser
                //await browser.CloseAsync();

                string currentDirectory = Environment.CurrentDirectory;

                string filePath = currentDirectory + @"\" + url.Split('/').LastOrDefault().ToLower() + ".html";  // Path to store the previous version locally

                //string currentHtml = HtmlHelper.HtmlHelper.GetHtmlContentFromUrl(url);

                //string currentHtml = await GetHtmlFromUrl(url);


                string previousHtml = File.Exists(filePath) ? File.ReadAllText(filePath) : null;

                bool areEqual = CompareHtml(currentHtml, previousHtml);

                // If previous version exists, compare with the current one
                if (previousHtml != null)
                {
                    if (string.Equals(currentHtml, previousHtml, StringComparison.Ordinal))
                    {
                        Console.WriteLine("The page content has not changed.");
                    }
                    else
                    {
                        Console.WriteLine("The page content has changed.");
                        // Optionally, show the differences here (using a diff tool or custom logic)
                    }
                }
                else
                {
                    Console.WriteLine("No previous version found, saving the current page.");
                }

                // Save the current version for the next comparison
                File.WriteAllText(filePath, currentHtml);
            }
        }

        static async Task<string> GetHtmlFromUrl(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string htmlContent = await client.GetStringAsync(url);
                    return htmlContent;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching the URL: {ex.Message}");
                    return null;
                }
            }
        }

        public static string NormalizeHtml(string html)
        {
            // Remove extra spaces and newlines
            string normalizedHtml = Regex.Replace(html, @"\s+", " ").Trim();

            // Optional: Remove dynamic elements like timestamps or unique IDs if known
            // Example: Remove JavaScript code between <script> tags (or other dynamic content)
            normalizedHtml = Regex.Replace(normalizedHtml, @"<script.*?</script>", "", RegexOptions.Singleline);

            return normalizedHtml;
        }

        public static bool CompareHtml(string currentHtml, string previousHtml)
        {
            string normalizedCurrentHtml = NormalizeHtml(currentHtml);
            string normalizedPreviousHtml = NormalizeHtml(previousHtml);

            // Compare the normalized HTML
            return string.Equals(normalizedCurrentHtml, normalizedPreviousHtml, StringComparison.Ordinal);
        }
    }
}

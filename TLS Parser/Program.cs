using System;
using System.Text;
using HtmlAgilityPack;

namespace TLS_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            WebScraperClient client = new WebScraperClient(Encoding.GetEncoding("UTF-8"));
            string htmlResponse = client.NavigateGet("http://webscraper.io/test-sites/e-commerce/allinone");
            htmlResponse = client.NavigateGet("http://webscraper.io/test-sites/e-commerce/allinone/phones");
            Console.WriteLine("navigation finished");
        }
    }
}

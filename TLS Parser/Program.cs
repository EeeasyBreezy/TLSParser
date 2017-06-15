using System;
using System.Text;
using System.Collections.Generic;
using TLS_Parser.Parser;
using TLS_Parser.Clients;
using System.Runtime.Serialization.Json;
using System.IO;

namespace TLS_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            WebScraperClient client = new WebScraperClient(Encoding.GetEncoding("UTF-8"));
            string htmlResponse = client.NavigateGet("http://webscraper.io/test-sites/e-commerce/allinone");
            htmlResponse = client.NavigateGet("http://webscraper.io/test-sites/e-commerce/allinone/phones");
            List<Item> topPhones = WebScrapperParser.Parse(htmlResponse);
            htmlResponse = client.NavigateGet("http://webscraper.io/test-sites/e-commerce/allinone/computers");
            List<Item> topComputers = WebScrapperParser.Parse(htmlResponse);
            htmlResponse = client.NavigateGet("http://webscraper.io/test-sites/e-commerce/allinone/computers/laptops");
            List<Item> laptops = WebScrapperParser.Parse(htmlResponse);
            htmlResponse = client.NavigateGet("http://webscraper.io/test-sites/e-commerce/allinone/computers/tablets");
            List<Item> tablets = WebScrapperParser.Parse(htmlResponse);
            htmlResponse = client.NavigateGet("http://webscraper.io/test-sites/e-commerce/allinone/phones/touch");
            List<Item> touchPhones = WebScrapperParser.Parse(htmlResponse);
            WebScraperData data = new WebScraperData(topPhones, topComputers, laptops,
                tablets, touchPhones);
            DataContractJsonSerializer serializer =
                new DataContractJsonSerializer(typeof(WebScraperData));
            StreamWriter stream = new StreamWriter("items.json");
            serializer.WriteObject(stream.BaseStream, data);
            Console.WriteLine("navigation finished");
        }
    }
}

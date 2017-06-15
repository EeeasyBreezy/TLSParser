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
            #region INIT
            Console.Write("Creating client.......");
            WebScraperClient client = new WebScraperClient(Encoding.GetEncoding("UTF-8"));
            string htmlResponse = client.NavigateGet("http://webscraper.io/test-sites/e-commerce/allinone");
            Console.WriteLine("OK");
            #endregion

            #region TOP PHONES
            Console.Write("Parsing top phones.......");
            htmlResponse = client.NavigateGet("http://webscraper.io/test-sites/e-commerce/allinone/phones");
            List<Item> topPhones = WebScrapperParser.Parse(htmlResponse);
            Console.WriteLine("OK");
            #endregion

            #region TOP COMPUTERS
            Console.Write("Parsing top computers.......");
            htmlResponse = client.NavigateGet("http://webscraper.io/test-sites/e-commerce/allinone/computers");
            List<Item> topComputers = WebScrapperParser.Parse(htmlResponse);
            Console.WriteLine("OK");
            #endregion

            #region LAPTOPS
            Console.Write("Parsing laptops.......");
            htmlResponse = client.NavigateGet("http://webscraper.io/test-sites/e-commerce/allinone/computers/laptops");
            List<Item> laptops = WebScrapperParser.Parse(htmlResponse);
            Console.WriteLine("OK");
            #endregion

            #region TABLETS
            Console.Write("Parsing tablets..........");
            htmlResponse = client.NavigateGet("http://webscraper.io/test-sites/e-commerce/allinone/computers/tablets");
            List<Item> tablets = WebScrapperParser.Parse(htmlResponse);
            Console.WriteLine("OK");
            #endregion

            #region TOUCH PHONES
            Console.Write("Parsing touch phones.......");
            htmlResponse = client.NavigateGet("http://webscraper.io/test-sites/e-commerce/allinone/phones/touch");
            List<Item> touchPhones = WebScrapperParser.Parse(htmlResponse);
            Console.WriteLine("OK");
            #endregion

            #region SERIALIZE
            Console.Write("Serializing data to json.......");
            WebScraperData data = new WebScraperData(topPhones, topComputers, laptops,
                tablets, touchPhones);
            DataContractJsonSerializer serializer =
                new DataContractJsonSerializer(typeof(WebScraperData));
            StreamWriter stream = new StreamWriter("items.json");
            serializer.WriteObject(stream.BaseStream, data);
            #endregion

            #region FINISH
            Console.WriteLine("OK");
            Console.WriteLine("Serialization completed to file items.json");
            Console.WriteLine("Parsing finished");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            #endregion
        }
    }
}

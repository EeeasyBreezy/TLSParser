using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace TLS_Parser.Parser
{
    /// <summary>
    /// Парсинг сайта WebScrapper
    /// </summary>
    public static class WebScrapperParser
    {
        public static List<Item> Parse(string html)
        {
            List<Item> result = null;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var name = doc.DocumentNode.SelectNodes("//a[@class = 'title']");
            var description = doc.DocumentNode.SelectNodes("//p[@class = 'description']");
            var price = doc.DocumentNode.SelectNodes("//h4[@class = 'pull-right price']");
            var reviewsNumber = doc.DocumentNode.SelectNodes("//p[@class = 'pull-right']");
            result = new List<Item>();
            Regex expression = new Regex(" review.");
            for (int i = 0; i < name.Count; i++)
            {
                string floatPriceString = price[i].InnerText.Remove(0, 1);
                string reviewString = reviewsNumber[i].InnerText;
                if (expression.IsMatch(reviewString))
                    reviewString = expression.Replace(reviewString, string.Empty);
                result.Add(new Item(name[i].InnerText, 
                    Convert.ToSingle(floatPriceString, CultureInfo.InvariantCulture),
                   description[i].InnerText.Replace("&quot", "'"), Convert.ToInt32(reviewString)));
            }
            return result;
        }
    }
}

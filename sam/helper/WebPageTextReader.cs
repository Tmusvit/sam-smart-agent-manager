using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using HtmlAgilityPack;
namespace sam.helper
{
    internal class WebPageTextReader
    {
        private readonly string _url;

        public WebPageTextReader(string url)
        {
            _url = url;
        }

        public async Task<List<string>> GetWebPageTextAsync(string url)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
            var html = string.Empty;
            HtmlAgilityPack.HtmlDocument htmlDocument = null;
            try
            {
                html = await client.GetStringAsync(url);
                htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(html);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error - {ex.Message}");
                return null;
            }

            // get all text nodes that are not inside script or style tags, and the section tag with class description-container__full-text
            var textNodes = htmlDocument.DocumentNode.DescendantsAndSelf()
                .Where(n => n.NodeType == HtmlNodeType.Text
                && n.ParentNode != null
                && n.ParentNode.Name != "script"
                && n.ParentNode.Name != "style"
                && (n.ParentNode.Name != "section"
                || (n.ParentNode.Attributes["class"] != null
                && n.ParentNode.Attributes["class"].Value == "description-container__full-text")));


            var textList = new List<string>();
            var builder = new StringBuilder();
            foreach (var node in textNodes)
            {
                if (node.InnerText.Length > 1)
                {
                    builder.Append(node.InnerText + " ");
                    if (builder.Length > 1000)
                    {
                        textList.Add(Regex.Replace(builder.ToString(), "<.*?>", ""));
                        builder.Clear();
                    }
                }
            }
            return textList;
        }







    }
}

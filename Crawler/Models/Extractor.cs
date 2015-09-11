using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace UltimateCrawler
{
    public class Extractor : IExtractor
    {
        private List<string> _hrefs;
        public List<string> Hrefs
        {
            get { return _hrefs; }
        }
        public Extractor()
        {
           
        }
        public List<string> ExtractUrls(HtmlAgilityPack.HtmlDocument doc)
        {
             if (doc.StreamEncoding != null)
            {
                _hrefs = new List<string>();

                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                {
                    _hrefs.Add(link.GetAttributeValue("href", string.Empty));
                }
                return _hrefs;
            }
            else
            {
                Logger.Error("HtmlDocument is empty ", "Extractor");
                return null;
            }
        }
    }
}

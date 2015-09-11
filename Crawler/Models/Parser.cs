using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace UltimateCrawler
{
    public class Parser : IParser
    {
        private HtmlAgilityPack.HtmlDocument _htmlDocument;
        public HtmlAgilityPack.HtmlDocument HtmlDocument
        {
            get { return _htmlDocument; }
            set
            {
                _htmlDocument = value;
            }
        }

        public Parser()
        {
            HtmlDocument = new HtmlAgilityPack.HtmlDocument();
        }

        public void ObtainDocumentHTML(string url)
        {
            try
            {
             
                HtmlDocument = new HtmlAgilityPack.HtmlDocument();
                var web = new HtmlWeb();
                HtmlDocument = web.Load(url);

                
            }
            catch (Exception e)
            {
                Logger.Error("Parsing failed ! :) ", "Parser");
            }
            Logger.Info("parsing successful ! ", "Parser");
        }
    }
}

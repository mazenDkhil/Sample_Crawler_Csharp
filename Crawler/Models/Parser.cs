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
        //public Parser(string url)
        {
            HtmlDocument = new HtmlAgilityPack.HtmlDocument();
            //HtmlDocument = new HtmlWeb().Load( url );
        }

        public void ObtainDocumentHTML(string url)
        {
            try
            {
                HtmlDocument = new HtmlAgilityPack.HtmlDocument();
                HtmlDocument = new HtmlWeb().Load(url);
            }
            catch (Exception e)
            {

            }

        }



    }
}

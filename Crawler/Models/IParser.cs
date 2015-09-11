using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace UltimateCrawler
{
    public interface IParser
    {
        HtmlDocument HtmlDocument
        {
            get;
            set;
        }

        void ObtainDocumentHTML( string url );
    }
}

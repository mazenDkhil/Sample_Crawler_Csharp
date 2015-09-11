using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCrawler
{
    public interface IExtractor
    {
        List<string> Hrefs
        {
            get;
        }
    }
}

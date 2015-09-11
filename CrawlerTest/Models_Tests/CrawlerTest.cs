using UltimateCrawler;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace UltimateCrawlerTest
{
    [TestFixture]
    public class CrawlerTest
    {
        [Test]
        public void New_Crawler()
        {
            #region Init constructor
            Parameters param = new Parameters(new Uri("http://stackoverflow.com/"),
                  "http://stackoverflow.com/questions(/[a-z0-9/-]+)?",
                  "http://stackoverflow.com/questions/([a-z0-9/-]+)?",
                  2,
                  "test");
            Crawler crawler = new Crawler(param);
            Assert.AreEqual("test", crawler.param.Name);
            #endregion

            #region LoadXML
            XElement doc = XElement.Parse(File.ReadAllText(@"C:\Users\MazenDK\Desktop\test.xml"));
            Crawler crawler2 = new Crawler(doc, param);
            int count = crawler2.CountToVisiteUrls();
            Assert.That(crawler2.CountToVisiteUrls() == 2);
            #endregion

            #region Crawler Run
            Assert.That(crawler2.CountToVisiteUrls() == 2);
            crawler2.RunCrawler();
            Assert.That(crawler2.CountToVisiteUrls() == 0);
            // Assert.That(crawler2.http.Response == 200);
            #endregion

        }
    }
}

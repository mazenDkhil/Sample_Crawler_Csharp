using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCrawler;

namespace CrawlerTest.Models_Tests
{
    [TestFixture]
    class HTTPClientTest
    {
        [Test]
        public void New_HTTPClient()
        {
            HTTPClient http = new HTTPClient("http://google.com");
            http.CheckStatus();
            Assert.That( http.Status == 200);
             
        }
    }
}

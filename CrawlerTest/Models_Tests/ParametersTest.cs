using UltimateCrawler;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCrawlerTest
{
    [TestFixture]
    public class ParametersTest
    
    {
         [Test]
        public void New_Paramaters()
        {
            #region Init constructor
            Parameters param = new Parameters(new Uri("http://tlevesque.developpez.com/tutoriels/dotnet/extraction-donnees-web-html-agility-pack/"),
                "http://tlevesque.developpez.com/(cours|tutoriels)/([a-z0-9/-]+)?",
                "http://[a-z0-9-]+.developpez.com/tutoriels/dotnet/extraction-donnees-web-html-agility-pack/",
                2,
                "Tuto");
            Assert.AreEqual("Tuto", param.Name);
            Assert.AreEqual("http://tlevesque.developpez.com/tutoriels/dotnet/extraction-donnees-web-html-agility-pack/", param.Url.AbsoluteUri);
            #endregion 
        }
    }
}

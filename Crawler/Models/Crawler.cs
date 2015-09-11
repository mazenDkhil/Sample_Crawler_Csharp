using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using HtmlAgilityPack;

namespace UltimateCrawler
{
    public class Crawler
    {
        public enum StateType { Stopped, Paused, Running, Finished }
        private StateType _state;
        private DateTime _startTime;
        private Dictionary<Uri,bool> _urls;
        public IParser Parser;
        public IExtractor Extractor;
        public FilterURL Filter;
        public Parameters param;
        public HTTPClient http;
        public StateType State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        public Crawler(Parameters param)
        {
            this.param = param;
        }

        public Crawler(XElement e, Parameters param)
        {
            this.param = param;
            _urls = DictionaryFromXml( e );
        }


        private Dictionary<Uri,bool> DictionaryFromXml( XElement e )
        {
            return e
                .Elements("Url")
                .ToDictionary(x => new Uri( x.Attribute("link").Value ), x => Boolean.Parse( x.Value ) );
        }

        public void Init()
        {
            string curFile = @"C:\Users\MazenDK\Desktop\" + param.Name + ".xml";

            if( File.Exists( curFile ) )
            {
                _urls = DictionaryFromXml( XElement.Parse( File.ReadAllText( curFile ) ) );
            }
            else
            {
                _urls = new Dictionary<Uri, bool>();
                _urls.Add( param.Url, false );
            }
            StartTime = DateTime.Now;
            Parser = new Parser();
        }

        public void RunCrawler()
        {
            if (CheckPreviousState())
            {
                Init();

                while( CountToVisiteUrls() > 0 )
                {
                    http = new HTTPClient( FirstUrls() );
                    http.CheckStatus();
                    Parser.ObtainDocumentHTML( http.URL.AbsoluteUri ); 
                    Extractor = new Extractor( Parser.HtmlDocument);
                    Filter = new FilterURL( Extractor.Hrefs, param.Url.Host);
                    if (Filter.CleanedUrls != null) { 
                    foreach( string url in Filter.CleanedUrls )
                    {
                        if (!_urls.ContainsKey(new Uri(url)))
                        {
                            _urls.Add(new Uri(url), false);
                        }
                  
                    }
                    _urls[http.URL] = true;
                    }
                  
                }
            }
        }

        public void Stop()
        {
            System.Environment.Exit(1);
        }

        private bool CheckPreviousState()
        {
            if (this.State == StateType.Running)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public int CountToVisiteUrls()
        {
            return _urls.Count( x => x.Value == false );
        }

        public Uri FirstUrls()
        {
            return _urls.Where( x => x.Value == false ).Select( x => x.Key ).First();
        }
    }
}

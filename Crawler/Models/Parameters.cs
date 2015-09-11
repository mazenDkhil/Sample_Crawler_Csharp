using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace UltimateCrawler 
{
    [Serializable]
    public class Parameters
    {
        private Uri _url;

        private string _regexpToAccept;

        private string _regexpToParse;

        private int _delay;

        private string _name;

        public Uri Url
        {
            get { return _url; }
            set
            {
                _url = value;
            }
        }

        public string RegexpToAccept
        {
            get
            {
                return _regexpToAccept;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                else
                    if (value.StartsWith(Url.AbsoluteUri))
                    {
                        _regexpToAccept = value;
                    }
            }
        }
        public string RegexpToParse
        {
            get
            {
                return _regexpToParse;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                else
                    if (value.StartsWith(Url.AbsoluteUri))
                    {
                        _regexpToParse = value;
                    }
            }
        }

        public int Delay
        {
            get
            {
                return _delay;
            }
            set
            {
                if (value >= 0)
                {
                    _delay = value;
                }
                else
                {
                    throw new Exception("The delay must be positive");
                }

            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }

        }

        public Parameters()
        {
        }
        public Parameters(XElement e)
        {
            Url = new Uri(e.Attribute("Url").Value);
            RegexpToAccept = e.Attribute("RegexpToAccept").Value;
            RegexpToParse = e.Attribute("RegexpToParse").Value;
            Name = e.Attribute("Name").Value;
            try
            {
                Delay = Int32.Parse(e.Attribute("Delay").Value);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public Parameters(Uri uri, string regExpToAccept, string regExpToParse, int delay, string name)
        {
            Url = uri;
            RegexpToAccept = regExpToAccept;
            RegexpToParse = regExpToParse;
            Delay = delay;
            Name = name;

           // ToXml();
        }

        public void ToXml()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Parameters));
            using (StreamWriter wr = new StreamWriter("C:/" + Name + ".xml"))
            {
                xs.Serialize(wr, this);
            }
        }
    }
}

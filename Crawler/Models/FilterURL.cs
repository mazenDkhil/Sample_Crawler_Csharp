using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UltimateCrawler
{
    public class FilterURL
    {
        private List<string> _cleanedUrls;
        public List<string> CleanedUrls
        {
            get
            {
                return _cleanedUrls;
            }
        }

        public FilterURL(List<string> urls, string baseUrl)
        {
            if (urls != null)
            {
                _cleanedUrls = new List<string>();
                foreach (string url in urls)
                {
                    if ((url.StartsWith("http://" + baseUrl) || url.StartsWith("https://" + baseUrl)) && !url.Contains("=") && !url.Contains("/users/") && !url.Contains("="))
                    {
                        _cleanedUrls.Add(url);
                    }
                    else if (url.StartsWith("/") && !url.Contains("//") && !url.Contains("/users/") && !url.Contains("="))
                    {
                        if (baseUrl.EndsWith("/"))
                        {
                            _cleanedUrls.Add("http://" + baseUrl + url.Remove(0));
                        }
                        else
                        {
                            _cleanedUrls.Add("http://" + baseUrl + url);
                        }

                    }
                }
            }
        }
    }
}

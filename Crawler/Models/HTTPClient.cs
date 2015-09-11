using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCrawler
{
    public class HTTPClient
    {
        private HttpWebResponse _response;
        private Uri _url;
        public StatusResponse _statusResponse;
        public Uri URL
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }

        public HttpWebResponse Response
        {
            get
            {
                return _response;
            }
            set
            {
                _response = value;
            }
        }

        public HTTPClient(Uri url)
        {
            URL = url;
        }
        public async void CheckStatus()
        {
            StatusResponse statusResponse = new StatusResponse( await AccessTheWebAsync( _url ) );
            Uri uriTmp = statusResponse.CheckStatusResponse();

            if( uriTmp == null ) throw new ArgumentNullException();
            if( !_url.AbsoluteUri.Equals( uriTmp.AbsoluteUri ) )
            {
                _url = uriTmp;
            }
        }
        async Task<HttpWebResponse> AccessTheWebAsync( Uri url )
        {
            HttpWebRequest request;
            try
            {
                request = WebRequest.Create( url ) as HttpWebRequest;
                request.Method = "HEAD";
                return request.GetResponse() as HttpWebResponse;
            }
            catch
            {
                //Any exception will returns false.
                return null;
            }
        }
    }
}

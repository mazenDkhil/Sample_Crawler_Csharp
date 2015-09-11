using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCrawler
{
    public class StatusResponse
    {
        private HttpWebResponse _httpWebResponse;

        public StatusResponse(HttpWebResponse httpWebResponse)
        {
            _httpWebResponse = httpWebResponse;
        }

        public Uri CheckStatusResponse()
        {
            if (_httpWebResponse != null)
            {

                switch (_httpWebResponse.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return _httpWebResponse.ResponseUri;
                    case HttpStatusCode.Redirect:
                        // recupère la bonne url puis la transmet 
                        return FoundUrlRedirect(_httpWebResponse);
                    case HttpStatusCode.RedirectMethod:
                        return FoundUrlRedirect(_httpWebResponse);
                    case HttpStatusCode.BadRequest:
                        return null;
                    default:
                        return null;
                }
            }
            return null;
        }
        private Uri FoundUrlRedirect(HttpWebResponse _httpWebResponse)
        {
            //Prevenir du changement d URL
            return new Uri(_httpWebResponse.Headers["Location"]);
        }
    }
}

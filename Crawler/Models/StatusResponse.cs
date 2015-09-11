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
                        Logger.Info("HTTP status OK ", "StatusResponse");
                        return _httpWebResponse.ResponseUri;
                    case HttpStatusCode.Redirect:
                        Logger.Info("HTTP status Redirect ", "StatusResponse");
                        return FoundUrlRedirect(_httpWebResponse);
                    case HttpStatusCode.RedirectMethod:
                        Logger.Info("HTTP status RedirectMethod ", "StatusResponse");
                        return FoundUrlRedirect(_httpWebResponse);
                    case HttpStatusCode.BadRequest:
                        Logger.Error("HTTP status BadRequest ! :)", "StatusResponse");
                        return null;
                    default:
                        Logger.Error("HTTP status BadRequest ! :)", "StatusResponse");
                        return null;
                }
            }
            else
            {
                Logger.Error("HTTP response null ! ", "StatusResponse");
                return null;

            }
          
        }
        private Uri FoundUrlRedirect(HttpWebResponse _httpWebResponse)
        {
            return new Uri(_httpWebResponse.Headers["Location"]);
        }
    }
}

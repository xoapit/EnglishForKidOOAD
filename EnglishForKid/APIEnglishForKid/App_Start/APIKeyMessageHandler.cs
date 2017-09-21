using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Threading;
using System.Threading.Tasks;


namespace APIEnglishForKid.App_Start
{
    public class APIKeyMessageHandler : DelegatingHandler
    {
        private const string APIKey = ApplicationConfig.API_KEY;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken)
        {
            bool validKey = false;
            IEnumerable<string> requestHeaders;
            var isAPIKeyExists = httpRequestMessage.Headers.TryGetValues(ApplicationConfig.API_KEY_NAME, out requestHeaders);
            if (isAPIKeyExists)
            {
                if (requestHeaders.FirstOrDefault().Equals(APIKey))
                {
                    validKey = true;
                }
            }

            if (!validKey)
            {
                return httpRequestMessage.CreateResponse(HttpStatusCode.Forbidden, "Invalid API Key");
            }

            var response = await base.SendAsync(httpRequestMessage, cancellationToken);
            return response;
        }
    }
}
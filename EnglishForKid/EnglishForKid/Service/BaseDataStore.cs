using EnglishForKid.App_Start;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace EnglishForKid.Service
{
    public class BaseDataStore
    {
        protected string baseApiUrl = ApplicationConfig.BaseApiUrl;
        protected static HttpClient client;
        protected JsonSerializerSettings jsonSetting;

        public BaseDataStore()
        {
            jsonSetting = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000,
                BaseAddress = new Uri(baseApiUrl),
                Timeout = TimeSpan.FromMilliseconds(4000)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
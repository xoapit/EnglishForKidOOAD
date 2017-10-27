using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKid.Helpers
{
    public class Credential
    {
        public List<HttpCookie> CreateCookies(CredentialInfo credentialInfo)
        {
            List<HttpCookie> cookies = new List<HttpCookie>();
            HttpCookie ckToken = new HttpCookie("token");
            ckToken.Value = credentialInfo.Token;
            ckToken.Expires = DateTime.Now.AddDays(15);

            HttpCookie ckUsername = new HttpCookie("username");
            ckUsername.Value = credentialInfo.Token;
            ckUsername.Expires = DateTime.Now.AddDays(15);

            cookies.Add(ckToken);
            cookies.Add(ckUsername);
            return cookies;
        }

         public class CredentialInfo
        {
            public string Token { get; set; }
            public string Username { get; set; }
            public string RememberMe { get; set; }
        }
    }
}
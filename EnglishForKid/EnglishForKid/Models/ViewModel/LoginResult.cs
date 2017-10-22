using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnglishForKid.Models.Error;

namespace EnglishForKid.Models.ViewModel
{
    public class LoginResult
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public int expires_in { get; set; }

        public ErrorDescription Error { get; set; }
    }
}
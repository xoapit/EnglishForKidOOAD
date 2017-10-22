using EnglishForKid.Models.ViewModel;
using EnglishForKid.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models.Error
{
    public class ErrorDescription: LoginResult
    {
        public string error { get; set; }
        public string error_description { get; set; }
    }
}
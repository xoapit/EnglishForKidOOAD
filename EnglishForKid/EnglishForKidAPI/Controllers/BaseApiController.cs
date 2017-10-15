using EnglishForKidAPI.Models;
using EnglishForKidAPI.Models.Factory;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EnglishForKidAPI.Controllers
{
    public class BaseApiController : ApiController
    {
        protected ApplicationDbContext db = ApplicationDbContext.Create();
      
    }
}
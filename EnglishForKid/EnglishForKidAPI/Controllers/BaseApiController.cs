using EnglishForKidAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
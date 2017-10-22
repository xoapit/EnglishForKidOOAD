using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;
using System.Web.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using EnglishForKid.Service;
using EnglishForKid.Models.ViewModel;

namespace EnglishForKid.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult GetCount() {
            ViewCountDataStore viewCountDataStore = new ViewCountDataStore();
            var result = viewCountDataStore.GetCountAsync().Result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
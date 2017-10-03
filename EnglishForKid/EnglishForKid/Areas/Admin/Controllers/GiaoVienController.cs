using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishForKid.Areas.Admin.Controllers
{
    public class GiaoVienController : Controller
    {
        // GET: GiaoVien
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ThongTinGiaoVien()
        {
            return View();
        }
        public ActionResult AddGV()
        {
            return View();
        }
    }
}
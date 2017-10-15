using EnglishForKid.Models;
using EnglishForKid.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishForKid.Areas.Admin.Controllers
{
    public class FeedbackController : Controller
    {
        private FeedbackDataStore feedbackDataStore = new FeedbackDataStore();
        // GET: Admin/Feedback
        public ActionResult Index()
        {
            List<Feedback> feedbacks = feedbackDataStore.GetItemsAsync().Result;
            ViewBag.Feedbacks = feedbacks;
            return View();
        }

        [HttpPost]
        public void Delete()
        {

        }
    }
}
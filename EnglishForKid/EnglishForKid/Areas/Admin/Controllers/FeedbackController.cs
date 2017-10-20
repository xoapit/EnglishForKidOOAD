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
        public ActionResult Delete(Guid id)
        {
            bool result = feedbackDataStore.DeleteItemAsync(id).Result;
            return Json(new { status = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddFeedbackReplyHistory(string FeedbackID, string Subject, string Content)
        {
            FeedbackReplyHistory feedbackReplyHistory = new FeedbackReplyHistory()
            {
                ID = Guid.NewGuid(),
                Subject = Subject,
                Content = Content,
                CreateAt = DateTime.Now,
                FeedbackID = new Guid(FeedbackID)
            };
            FeedbackReplyHistoryDataStore feedbackReplyHistoryDataStore = new FeedbackReplyHistoryDataStore();
            bool result = feedbackReplyHistoryDataStore.AddItemAsync(feedbackReplyHistory).Result;
            return Json(new { status = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FeedbackReplyHistoriesByFeedbackID(Guid id)
        {
            FeedbackReplyHistoryDataStore feedbackReplyHistoryDataStore = new FeedbackReplyHistoryDataStore();
            var result = feedbackReplyHistoryDataStore.GetFeedbackReplyHistoriesByFeedbackIDAsync(id).Result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
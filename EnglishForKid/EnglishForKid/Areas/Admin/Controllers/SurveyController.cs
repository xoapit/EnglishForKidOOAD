using EnglishForKid.Models;
using EnglishForKid.Models.ViewModels;
using EnglishForKid.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace EnglishForKid.Areas.Admin.Controllers
{
    public class SurveyController : Controller
    {
        QuestionSurveyDataStore questionSurveyDataStore = new QuestionSurveyDataStore();
        // GET: Admin/Survey
        public ActionResult Index()
        {
            List<BaseQuestionSurveyViewModel> baseQuestionSurveyViewModels = questionSurveyDataStore.GetBaseQuestionSurveysAsync()?.Result;
            ViewBag.BaseQuestions = baseQuestionSurveyViewModels;
            return View();
        }

        public ActionResult GetQuestion(Guid id)
        {
            QuestionSurvey questionSurvey = questionSurveyDataStore.GetItemAsync(id)?.Result;
            return Json(new { questionSurvey }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(QuestionSurvey questionSurvey)
        {
            var result = questionSurveyDataStore.AddItemAsync(questionSurvey);
            ViewBag.Result = result;
            return View();
        }
    }
}
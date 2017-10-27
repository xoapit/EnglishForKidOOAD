using EnglishForKid.Models;
using EnglishForKid.Models.ViewModels;
using EnglishForKid.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Add(QuestionSurvey questionSurvey)
        {

            return View();
        }
    }
}
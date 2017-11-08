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

        public ActionResult GetActiveQuestion(Guid id)
        {
            QuestionSurvey questionSurvey = questionSurveyDataStore.GetActiveQuestion()?.Result;
            return Json(new { questionSurvey }, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public ActionResult DeleteQuestion(Guid id)
        {
            var result = questionSurveyDataStore.DeleteItemAsync(id)?.Result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddQuestion(string content, string[] answers)
        {
            Guid idQuestion = Guid.NewGuid();
            QuestionSurvey questionSurvey = new QuestionSurvey
            {
                ID = idQuestion,
                Content = content,
                CreateAt = DateTime.Now,

                ApplicationUserID = Request.Cookies["id"].Value
            };

            foreach (var answer in answers)
            {
                questionSurvey.AnswerSurveys.Add(new AnswerSurvey
                {
                    ID = Guid.NewGuid(),
                    QuestionSurveyID = idQuestion,
                    Answer = answer
                });
            }

            var result = questionSurveyDataStore.AddItemAsync(questionSurvey)?.Result;
            ViewBag.Result = result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateQuestion(Guid id, string content, string[] answers)
        {
            QuestionSurvey questionSurvey = questionSurveyDataStore.GetItemAsync(id)?.Result;

            questionSurvey.ApplicationUser = null;

            questionSurvey.Content = content;
            for (int i = 0; i < answers.Length; i++)
            {
                questionSurvey.AnswerSurveys[i].Answer = answers[i];
            }

            var result = questionSurveyDataStore.UpdateItemAsync(questionSurvey)?.Result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ActiveQuestion(Guid id)
        {
            var result = questionSurveyDataStore.ActiveQuestion(id)?.Result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
    }
}
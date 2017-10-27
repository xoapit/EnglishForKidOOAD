using EnglishForKid.Constants;
using EnglishForKid.Helpers;
using EnglishForKid.Models.ViewModel;
using EnglishForKid.Models.ViewModels;
using EnglishForKid.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static EnglishForKid.Helpers.Credential;

namespace EnglishForKid.Controllers
{
    public class AccountController : Controller
    {
        AccountDataStore accountDataStore = new AccountDataStore();

        [HttpPost]
        public JsonResult Login(string username, string password, bool rememberMe)
        {
            string grantTypeDefault = "password";
            string urlForward = "/Home";
            LoginViewModel loginViewModel = new LoginViewModel()
            {
                UserName = username,
                Password = password,
                RememberMe = rememberMe,
                ShouldLockOut = false,
                grant_type = grantTypeDefault
            };

            LoginResult loginResult = accountDataStore.Login(loginViewModel).Result;
            if (loginResult != null)
            {
                if (loginResult.access_token != null)
                {
                    UserReturnModel userReturnModel = accountDataStore.GetAccountByUserNameAsync(loginViewModel.UserName).Result;
                    urlForward = GetUrlForward(userReturnModel);
                    SaveTokenIntoCookie(loginResult.access_token);
                    return Json(urlForward, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(loginResult, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(urlForward, JsonRequestBehavior.AllowGet);
        }

        private string GetUrlForward(UserReturnModel userReturnModel)
        {
            string urlForward = "/Home";

            if (userReturnModel != null)
            {
                SaveUserInfo(userReturnModel);
                if (userReturnModel.Roles.Contains(ApplicationConfig.AdminRole))
                {
                    urlForward = "/Admin/Home";
                }
                else if (userReturnModel.Roles.Contains(ApplicationConfig.TeacherRole))
                {
                    urlForward = "/Teacher/Home";
                }
            }
            return urlForward;
        }

        private void SaveUserInfo(UserReturnModel userReturnModel)
        {
            SetCookie("username", userReturnModel.UserName);
        }

        private void SaveTokenIntoCookie(string access_token)
        {
            SetCookie("token", access_token);
        }

        private void SetCookie(string key, string value)
        {
            HttpCookie ck = new HttpCookie(key);
            ck.Value = value;
            ck.Expires = DateTime.Now.AddDays(15);
        }

        private string GetCookie(string key)
        {
            HttpCookie ck = Request.Cookies[key];
            return ck.Value;
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

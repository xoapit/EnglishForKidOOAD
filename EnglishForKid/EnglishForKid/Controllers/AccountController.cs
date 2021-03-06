﻿using EnglishForKid.Constants;
using EnglishForKid.Helpers;
using EnglishForKid.Models.ViewModel;
using EnglishForKid.Models.ViewModels;
using EnglishForKid.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static EnglishForKid.Helpers.Credential;

namespace EnglishForKid.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountDataStore accountDataStore = new AccountDataStore();

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

        public ActionResult Logout()
        {
            DeleteCookie();
            return RedirectToAction("Index", "Home");
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
            string roles = "";
            foreach (string role in userReturnModel.Roles)
            {
                roles += role;
            }
            SetCookie("roles", roles);
            SetCookie("username", userReturnModel.UserName);
            SetCookie("id", userReturnModel.Id);
        }

        private void SaveTokenIntoCookie(string access_token)
        {
            SetCookie("token", access_token);
        }

        private void DeleteCookie()
        {
            DeleteCookieByKey("roles");
            DeleteCookieByKey("token");
            DeleteCookieByKey("username");
            DeleteCookieByKey("id");
        }

        private void SetCookie(string key, string value)
        {
            HttpCookie ck = new HttpCookie(key);
            ck.Value = value;
            ck.Expires = DateTime.Now.AddDays(15);
            Response.Cookies.Add(ck);
        }

        private void DeleteCookieByKey(string key)
        {
            if (Request.Cookies.AllKeys.Contains(key))
            {
                HttpCookie ck = Request.Cookies[key];
                ck.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(ck);
            }
        }

        private string GetCookie(string key)
        {
            HttpCookie ck = Request.Cookies[key];
            return ck?.Value;
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(FormCollection form)
        {
            string email = form.Get("email");
            ResetPasswordViewModel resetPassword = new ResetPasswordViewModel
            {
                Email = email
            };
            bool result = accountDataStore.ResetPasswordAsync(resetPassword).Result;
            return RedirectToAction("Index","Home");
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details()
        {
            string username = Request.Cookies["username"]?.Value;
            UserReturnModel user = accountDataStore.GetAccountByUserNameAsync(username).Result;
            return View(user);
        }



        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            try
            {
                var email = collection["email"];
                var username = collection["Username"];
                var fullname = collection["fullname"];
                var roleName = collection["rolename"];
                var phone = collection["phonenumber"];
                var gender = collection["gender"];
                var birthday = collection["birthday"];
                var address = collection["address"];
                var password = collection["password"];
                var confirmPassword = collection["confirmpassword"];

                CreateUserBindingModel account = new CreateUserBindingModel
                {
                    Email = email,
                    Username = username,
                    Address = address,
                    Birthday = Convert.ToDateTime(birthday),
                    FullName = fullname,
                    Gender = gender == "Male" ? true : false,
                    Password = password,
                    PhoneNumber = phone,
                    RoleName = roleName,
                    Status = true,
                    ConfirmPassword = confirmPassword
                };

                var result = accountDataStore.AddItemAsync(account).Result;
                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        [AllowAnonymous]
        public async Task<JsonResult> UsernameAlreadyExistsAsync(string username)
        {
            var result = await accountDataStore.UsernameAlreadyExistAsync(username);
            return Json(!result, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public async Task<JsonResult> EmailAlreadyExistsAsync(string email)
        {
            var result = await accountDataStore.EmailAlreadyExistAsync(email);
            return Json(!result, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public async Task<JsonResult> EmailNotAlreadyExistsAsync(string email)
        {
            var result = await accountDataStore.EmailAlreadyExistAsync(email);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Account/Edit/
        public ActionResult Edit()
        {
            string username = Request.Cookies["username"]?.Value;
            UserReturnModel user = accountDataStore.GetAccountByUserNameAsync(username).Result;
            return View(user);
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                var email = collection["email"];
                var username = collection["Username"];
                var fullname = collection["fullname"];
                var roleName = collection["rolename"];
                var phone = collection["phonenumber"];
                var gender = collection["gender"];
                var birthday = collection["birthday"];
                var address = collection["address"];
                var password = collection["password"];
                var confirmPassword = collection["confirmpassword"];

                UserReturnModel account = new UserReturnModel
                {
                    Email = email,
                    UserName = username,
                    Address = address,
                    Birthday = Convert.ToDateTime(birthday),
                    FullName = fullname,
                    Gender = gender == "Male" ? true : false,
                    PhoneNumber = phone,
                    Status = true,
                    Id = id
                };

                var result = accountDataStore.UpdateAccountAsync(account).Result;
                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}

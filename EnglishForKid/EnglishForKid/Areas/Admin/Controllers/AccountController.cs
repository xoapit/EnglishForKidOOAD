using EnglishForKid.Constants;
using EnglishForKid.Models.ViewModels;
using EnglishForKid.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EnglishForKid.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        AccountDataStore accountDataStore = new AccountDataStore();
        // GET: Admin/Student
        public ActionResult Index()
        {
            List<UserReturnModel> users = accountDataStore.GetAccountsByRoleNameAsync(ApplicationConfig.StudentRole).Result;
            ViewBag.Users = users;

            List<UserReturnModel> teachers = accountDataStore.GetAccountsByRoleNameAsync(ApplicationConfig.TeacherRole).Result;
            ViewBag.Teachers = teachers;

            List<UserReturnModel> admins = accountDataStore.GetAccountsByRoleNameAsync(ApplicationConfig.TeacherRole).Result;
            ViewBag.Admins = admins;
            return View();
        }

        // GET: Admin/Student/Details/5
        public ActionResult Details(string id)
        {
            UserReturnModel user = accountDataStore.GetAccountByIDAsync(id).Result;
            ViewBag.User = user;
            return View(user);
        }

        // GET: Admin/Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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
                    return RedirectToAction("Index");
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

        // GET: Admin/Student/Edit/5
        public ActionResult Edit(string id)
        {
            UserReturnModel user = accountDataStore.GetAccountByIDAsync(id).Result;
            ViewBag.User = user;
            return View();
        }

        // POST: Admin/Student/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                string accountId = Request.Form["accountId"];
                string fullname = Request.Form["fullname"];
                string birthday = Request.Form["birthday"];
                string phone = Request.Form["phone"];
                string address = Request.Form["address"];
                string isMan = Request.Form["gender"];
                bool gender = true;
                if (isMan == null)
                {
                    gender = false;
                }
                UserReturnModel user = new UserReturnModel()
                {
                    Id = accountId,
                    FullName = fullname,
                    Birthday = Convert.ToDateTime(birthday),
                    PhoneNumber = phone,
                    Address = address,
                    Gender = gender
                };

                bool result = accountDataStore.UpdateAccountAsync(user).Result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                bool result = false;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Admin/Student/Lock/5
        [HttpPost]
        public ActionResult Lock()
        {
            try
            {
                string id = Request.Form["id"];
                bool status = Convert.ToBoolean(Request.Form["status"]);
                status = !status;
                bool result = accountDataStore.LockAccountAsync(id, status).Result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                bool result = false;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Admin/Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Student/Delete/5
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

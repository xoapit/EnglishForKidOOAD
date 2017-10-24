using EnglishForKid.Constants;
using EnglishForKid.Models.ViewModels;
using EnglishForKid.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishForKid.Areas.Admin.Controllers
{
    public class StudentController : Controller
    {
        AccountDataStore accountDataStore = new AccountDataStore();
        // GET: Admin/Student
        public ActionResult Index()
        {
            List<UserReturnModel> users = accountDataStore.GetAccountsByRoleNameAsync(ApplicationConfig.StudentRole).Result;
            ViewBag.Users = users;
            return View();
        }

        // GET: Admin/Student/Details/5
        public ActionResult Details(string id)
        {
            UserReturnModel user = accountDataStore.GetAccountByIDAsync(id).Result;
            return View();
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
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Student/Edit/5
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

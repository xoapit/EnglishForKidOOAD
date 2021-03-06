﻿using EnglishForKid.Constants;
using EnglishForKid.Models.ViewModel;
using EnglishForKid.Models.ViewModels;
using EnglishForKid.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishForKid.Areas.Admin.Controllers
{
    public class PermissionController : Controller
    {
        AccountDataStore accountDataStore = new AccountDataStore();
        // GET: Admin/Permission
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Permission/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Permission/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Permission/Create
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

        // GET: Admin/Permission/Edit/5
        public ActionResult Edit(string id)
        {
            UserReturnModel userReturnModel = accountDataStore.GetAccountByIDAsync(id).Result;
            RoleViewModel roleViewModel = new RoleViewModel
            {
                UserID = userReturnModel.Id,
                IsStudent = userReturnModel.Roles.Contains(ApplicationConfig.StudentRole),
                IsTeacher = userReturnModel.Roles.Contains(ApplicationConfig.TeacherRole),
                IsAdmin = userReturnModel.Roles.Contains(ApplicationConfig.AdminRole),
                FullName = userReturnModel.FullName,
                Username = userReturnModel.UserName
            };

            ViewBag.MyRoles = roleViewModel;

            return View();
        }

        // POST: Admin/Permission/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                string id = collection["UserID"];
                string student = collection["IsStudent"];
                string teacher = collection["IsTeacher"];
                string admin = collection["IsAdmin"];
                bool isStudent = Convert.ToBoolean(student);
                bool isTeacher = Convert.ToBoolean(teacher);
                bool isAdmin = Convert.ToBoolean(admin);

                RoleViewModel roleViewModel = new RoleViewModel
                {
                    UserID = id,
                    IsAdmin = isAdmin,
                    IsStudent = isStudent,
                    IsTeacher = isTeacher
                };

                bool result = accountDataStore.UpdateRoleAsync(roleViewModel).Result;

                return RedirectToAction("Index","Account");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Permission/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Permission/Delete/5
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

﻿using EnglishForKid.Models.ViewModel;
using EnglishForKid.Models.ViewModels;
using EnglishForKid.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishForKid.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        StatisticDataStore statisticDataStore = new StatisticDataStore();

        // GET: Admin/Home
        public ActionResult Index()
        {
            StatisticViewModel statisticViewModel = new StatisticViewModel();
            statisticViewModel = statisticDataStore.GetStatisticAsync().Result;
            ViewBag.StatisticViewModel = statisticViewModel;
            return View();
        }

        [HttpGet]
        public ActionResult GetChartData(int days)
        {
            ChartStatisticViewModel statisticViewModel = new ChartStatisticViewModel();
            statisticViewModel = statisticDataStore.GetChartStatisticAsync(days).Result;
            return Json(statisticViewModel, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Home/Create
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

        // GET: Admin/Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Home/Edit/5
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

        // GET: Admin/Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Home/Delete/5
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

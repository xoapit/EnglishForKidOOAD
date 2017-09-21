using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;
using System.Web.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using EnglishForKid.Service;

namespace EnglishForKid.Controllers
{
    public class HomeController : Controller
    {
        private AccountDataStore accountDataStore = new AccountDataStore();

        public ActionResult Index()
        {
            List<Account> accounts = (List<Account>)accountDataStore.GetItemsAsync().Result;
            ViewBag.Accounts = accounts;
            return View();
        }

        public ActionResult file()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult file(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Content/files"),
                    Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View("Index");
        }

        public void ExportExcel(dynamic items, string fileName, string extension)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet1 = workbook.CreateSheet("Sheet 1");

            //make a header row
            IRow row1 = sheet1.CreateRow(0);
            var arrayAttribute = items[0].GetType().GetCustomAttributes(true);
            int sizeOfProperties = arrayAttribute.Count();
            for (int i = 0; i < sizeOfProperties; i++)
            {
                ICell cell = row1.CreateCell(i);
                cell.SetCellValue(arrayAttribute[i].ToString());
            }

            var boldFont = workbook.CreateFont();
            boldFont.FontHeightInPoints = 11;
            boldFont.FontName = "Calibri";
            boldFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

            ICellStyle style = workbook.CreateCellStyle();
            style.SetFont(boldFont);
            //loops through data
            for (int i = 0; i < items.Count; i++)
            {
                for (int j = 0; j < sizeOfProperties; j++)
                {
                    IRow row = sheet1.CreateRow(i + 1);
                    ICell cell = row.CreateCell(0);
                    string value = items[i].GetType().GetProperty(arrayAttribute[j].ToString()).GetValue(items.ElementAt[i]).ToString();
                    cell.SetCellValue(value);
                }
            }
            for (int i = 0; i < sizeOfProperties; i++)
            {
                sheet1.AutoSizeColumn(i);
            }

            using (var exportData = new MemoryStream())
            {
                Response.Clear();
                workbook.Write(exportData);
                if (extension == "xlsx") //xlsx file format
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName + ".xls"));
                    Response.BinaryWrite(exportData.ToArray());
                }
                else if (extension == "xls")  //xls file format
                {
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName + ".xls"));
                    Response.BinaryWrite(exportData.GetBuffer());
                }
                Response.End();
            }
        }

        public void ExportExcelAccount()
        {

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
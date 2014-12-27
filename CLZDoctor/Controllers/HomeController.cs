using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLZDoctor.Domain;
using CLZDoctor.Domain.Common;
using CLZDoctor.Entities;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace CLZDoctor.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPrescriptionCore _prescriptionCore;

        public HomeController(IPrescriptionCore prescriptionCore)
        {
            _prescriptionCore = prescriptionCore;
        }
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "SQDoctor";
            return View();
        }

        [HttpPost]
        public ActionResult Search(int searchType = 1, string searchVal = "", int take = 10, int skip = 1)
        {
            if (string.IsNullOrEmpty(searchVal))
                return Json(new OperationResult(OperationResultType.ParamError, "搜索内容不能为空！"), JsonRequestBehavior.AllowGet);
            int count;
            var list = _prescriptionCore.SelectPrescriptions(searchType, searchVal, take, skip, out  count);
            var json = new { total = count, rows = list };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SearchResult(int searchType = 1, string searchVal = "", int pageIndex = 1, int pageSize = 10)
        {
            int count;
            var list = new List<Prescription>();
            var names = new List<string>();
            if (searchType == 2)
            {
                var strNames = searchVal.Trim().Replace(",", " ").Replace("，", " ");
                strNames = Regex.Replace(strNames, @" +", " ");
                names = strNames.Split(' ').ToList();
            }
            if (searchType == 2 && names.Count > 1)
            {
                list = _prescriptionCore.SelectPrescriptionsByMakeUp(names, pageSize, pageIndex, out count);
            }
            else
            {
                list = _prescriptionCore.SelectPrescriptions(searchType, searchVal, pageSize, pageIndex, out count);
            }
            foreach (var item in list)
            {
                item.Name = item.Name.Replace("<span style=\"color:red;font-weight:bold;\">", "").Replace("</span>", "");
                item.MakeUp = item.MakeUp.Replace("<span style=\"color:red;font-weight:bold;\">", "").Replace("</span>", "");
            }
            var result = new PageDataModel<Prescription>
            {
                TotalCount = (count + pageSize - 1) / pageSize,
                Rows = list,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            return View(result);
        }

        [HttpGet]
        public ActionResult SearchDetail(int id)
        {
            var result = _prescriptionCore.SelectPrescription(id);
            return View(result);
        }
    }
}

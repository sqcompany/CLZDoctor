using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLZDoctor.Domain;
using CLZDoctor.Domain.Common;
using CLZDoctor.Entities;
using Newtonsoft.Json;

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
            if (string.IsNullOrEmpty(searchVal))
                return Json(new OperationResult(OperationResultType.ParamError, "搜索内容不能为空！"), JsonRequestBehavior.AllowGet);
            int count;
            var list = _prescriptionCore.SelectPrescriptions(searchType, searchVal, pageSize, pageIndex, out  count);
            var result = new PageDataModel<Prescription>
            {
                TotalCount = count,
                Rows = list
            };
            ViewBag.Result = result;
            return View();
        }
    }
}

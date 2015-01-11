using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLZDoctor.Domain;
using CLZDoctor.Domain.Common;
using CLZDoctor.Entities;

namespace CLZDoctor.Areas.ManageSystem.Controllers
{
    public class MedicalController : Controller
    {
        //
        // GET: /Medical/
        private readonly IMedicalCore _medicalCore;

        public MedicalController(IMedicalCore medicalCore)
        {
            _medicalCore = medicalCore;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MedicalGrid(int page = 1, int row = 10)
        {
            int count;
            var list = _medicalCore.SelectMedicals(row, page, out count);
            var json = new { total = count, rows = list };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Data = _medicalCore.SelectMedical(id);
            return View();
        }

        public ActionResult Save(Medical medical)
        {
            if (medical == null)
                return View(Json(new OperationResult(OperationResultType.ParamError, "信息不能为空！")));
            if (string.IsNullOrEmpty(medical.Patient))
                return View(Json(new OperationResult(OperationResultType.ParamError, "姓名不能为空！")));


            bool state;
            if (medical.Id != 0)
            {
                state = _medicalCore.Update(medical);
            }
            else
            {
                state = _medicalCore.Insert(medical) > 0;
            }
            return state
                ? Json(new OperationResult(OperationResultType.Success, "保存成功！"), JsonRequestBehavior.AllowGet)
                : Json(new OperationResult(OperationResultType.Error, "保存失败，请稍后再试！"), JsonRequestBehavior.AllowGet);
        }

        public string Remove(int Id)
        {
            return _medicalCore.Delete(Id) ? "success" : "error";
        }
    }
}

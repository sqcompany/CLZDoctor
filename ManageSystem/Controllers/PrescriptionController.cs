using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using CLZDoctor.Domain;
using CLZDoctor.Domain.Common;
using CLZDoctor.Entities;

namespace ManageSystem.Controllers
{
    public class PrescriptionController : Controller
    {
        //
        // GET: /Prescription/
        private readonly IPrescriptionCore _prescriptionCore;

        public PrescriptionController(IPrescriptionCore prescription)
        {
            _prescriptionCore = prescription;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrescriptionGrid(int type = 0, string value = "", int page = 1, int row = 10)
        {
            int count;
            var list = new List<Prescription>();
            var names = new List<string>();
            if (type == 2)
            {
                var strNames = value.Trim().Replace(",", " ").Replace("，", " ");
                strNames = Regex.Replace(strNames, @" +", " ");
                names = strNames.Split(' ').ToList();
            }
            if (type == 2 && names.Count > 1)
            {
                list = _prescriptionCore.SelectPrescriptions(names);
                count = list.Count;
            }
            else
            {
                list = _prescriptionCore.SelectPrescriptions(type, value, row, page, out count);
            }
            //switch (type)
            //{
            //    case 2:
            //        list = _prescriptionCore.SelectPrescriptions(value);
            //        count = list.Count;
            //        break;
            //    default:
            //        list = _prescriptionCore.SelectPrescriptions(type, value, row, page, out count);
            //        break;
            //}

            var json = new { total = count, rows = list };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Data = _prescriptionCore.SelectPrescription(id);
            return View();
        }

        public ActionResult Save(Prescription prescription)
        {
            if (prescription == null)
                return View(Json(new OperationResult(OperationResultType.ParamError, "信息不能为空！")));
            if (string.IsNullOrEmpty(prescription.Name))
                return View(Json(new OperationResult(OperationResultType.ParamError, "名称不能为空")));
            if (string.IsNullOrEmpty(prescription.MakeUp))
                return View(Json(new OperationResult(OperationResultType.ParamError, "组成不能为空")));
            bool sstate;
            if (prescription.Id != 0)
            {
                sstate = _prescriptionCore.Update(prescription);
            }
            else
            {
                sstate = _prescriptionCore.Insert(prescription) > 0;
            }
            return sstate
                ? Json(new OperationResult(OperationResultType.Success),JsonRequestBehavior.AllowGet)
                : Json(new OperationResult(OperationResultType.Error, "保存失败，请稍后再试！"),JsonRequestBehavior.AllowGet);
        }

        public string Remove(int id)
        {
            return _prescriptionCore.Delete(id) ? "success" : "error";
        }

        public ActionResult GetInfo(int id)
        {
            var result = _prescriptionCore.SelectPrescription(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFjlist()
        {
            return View();
        }

   
    }
}

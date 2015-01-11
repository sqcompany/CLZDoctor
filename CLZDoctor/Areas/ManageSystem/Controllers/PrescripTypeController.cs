using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLZDoctor.Domain;
using CLZDoctor.Entities;

namespace CLZDoctor.Areas.ManageSystem.Controllers
{
    public class PrescripTypeController : Controller
    {
        //
        // GET: /PrescripType/
        private readonly IPrescriptTypeCore _prescripTypeCore;

        public PrescripTypeController(IPrescriptTypeCore prescripType)
        {
            _prescripTypeCore = prescripType;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrescripTypeGrid()
        {
            var list = _prescripTypeCore.SelectPrescripTypes();
            foreach (var type in list)
            {
                type.children = list.Where(p => p.ParentId == type.Id).ToList();
            }
            var newList = list.Where(p => p.ParentId == 0);
            return Json(newList, JsonRequestBehavior.AllowGet);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLZDoctor.Domain;
using CLZDoctor.Entities;

namespace CLZDoctor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "SQDoctor";
            //var p = new PrescriptionCore();
            //p.Insert(new Prescription
            //{
            //    Name = "异功散",
            //    Alias = "异功散",
            //    MakeUp = "人参去芦,白术,茯苓去皮,甘草炙,陈皮",
            //    Effect = "健脾，益气，和胃",
            //    Remark = "脾虚夹滞证。食欲不振，，或胸脘痞闷不舒，或呕吐泄泻，舌淡苔薄，脉弱。"
            //});
            return View();
        }
    }
}

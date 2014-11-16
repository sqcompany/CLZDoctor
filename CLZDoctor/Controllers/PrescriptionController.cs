using System.Web.Mvc;
using CLZDoctor.Domain;
using CLZDoctor.Entities;

namespace CLZDoctor.Controllers
{
    public class PrescriptionController : Controller
    {
        //
        // GET: /Prescription/
        private readonly IPrescriptionCore _prescriptionCore;


        public PrescriptionController(IPrescriptionCore prescriptionCore)
        {
            _prescriptionCore = prescriptionCore;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public bool AddPrescription(string name, string alias, string makeup, string effect, string remark)
        {
            if (string.IsNullOrEmpty(name))
                return false;
            if (string.IsNullOrEmpty(makeup))
                return false;
            if(string.IsNullOrEmpty(effect))
                return false;
            return _prescriptionCore.Insert(new Prescription
            {
                Name = name,
                Alias = string.IsNullOrEmpty(alias) ? name : alias,
                MakeUp = makeup,
                Effect = effect,
                Remark = remark
            }) > 0;
        }

    }
}

using CLZDoctor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLZDoctor.Areas.ManageSystem.Controllers
{
    public class RecipeController : Controller
    {

        // GET: /Recipe/
        private readonly IRecipeCore _recipeCore;

        public RecipeController(IRecipeCore recipeCore)
        {
            _recipeCore = recipeCore;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public string Remove(int id)
        {
            return _recipeCore.DeleteById(id) ? "success" : "error";
        }

        public ActionResult RecipeGrid(int page = 1, int row = 10)
        {
            int count;
            var list = _recipeCore.SelectList(row, page, out count);
            var json = new { total = count, rows = list };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}

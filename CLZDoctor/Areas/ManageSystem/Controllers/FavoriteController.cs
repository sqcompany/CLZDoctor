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
    public class FavoriteController : Controller
    {
        #region 私有属性
        private readonly IFavoriteCore _favoriteCore;
        #endregion

        #region 构造函数
        public FavoriteController(IFavoriteCore favoriteCore)
        {
            _favoriteCore = favoriteCore;
        }
        #endregion

        #region 公共方法

        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult FavoriteGrid(int type = 0, string value = "", int page = 1, int row = 10)
        {
            FavoriteQuery query = null;
            switch (type)
            {
                case 1:
                    query = new FavoriteQuery { UserName = value };
                    break;
                default:
                    query = new FavoriteQuery();
                    break;
            }
            int count;
            var list = _favoriteCore.GetFavorites(query, row, page, out count);
            var json = new { total = count, rows = list };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}

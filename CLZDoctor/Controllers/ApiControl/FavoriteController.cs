using CLZDoctor.Domain;
using CLZDoctor.Domain.Common;
using CLZDoctor.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CLZDoctor.Controllers.ApiControl
{
    public class FavoriteController : ApiController
    {
        private readonly IFavoriteCore _favoriteCore;
        public FavoriteController(IFavoriteCore favoriteCore)
        {
            _favoriteCore = favoriteCore;
        }

        public string AddFavorite(Favorite favorite)
        {
            if (favorite == null)
                return Json(new OperationResult(OperationResultType.ParamError, "处方不能为空！"));
            int re = _favoriteCore.CreateFavorite(favorite);
            if (re > 0)
                return Json(new OperationResult(OperationResultType.Success, "收藏成功！"));
            else
                return Json(new OperationResult(OperationResultType.Error, "收藏失败！"));
        }

        public string RomoveFavorite(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
                return Json(new OperationResult(OperationResultType.ParamError, "参数不能为空！"));
            bool re = _favoriteCore.DeleteFavorites(id);
            if (re)
                return Json(new OperationResult(OperationResultType.Success, "删除收藏成功！"));
            else
                return Json(new OperationResult(OperationResultType.Error, "删除收藏失败！"));
        }


        public string Json(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}

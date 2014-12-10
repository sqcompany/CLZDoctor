using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLZDoctor.Domain;
using CLZDoctor.Domain.Common;
using CLZDoctor.Entities;

namespace ManageSystem.Controllers
{
    public class UserManageController : Controller
    {
        #region 私有属性
        private readonly IAccountCore _accountCore;
        #endregion

        #region 构造方法
        public UserManageController(IAccountCore accountCore)
        {
            _accountCore = accountCore;
        }
        #endregion

        #region 公共方法
        //
        // GET: /UserManage/

        public ActionResult Index()
        {
            return View();
        }

        #region 分页获取列表数据

        public ActionResult UserGrid(int type = 0, string value = "", int page = 1, int row = 10)
        {
            AccountQuery query = null;
            switch (type)
            {
                case 1:
                    query = new AccountQuery { Name = value };
                    break;
                case 2:
                    query = new AccountQuery { Mobile = value };
                    break;
                default:
                    query = new AccountQuery();
                    break;
            }
            int count;
            var list = _accountCore.GetAccounts(query, row, page, out count);
            var json = new { total = count, rows = list };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除用户
        [HttpPost]
        public ActionResult RemoveUser(int id)
        {
            var result = _accountCore.DeleteAccount(id);
            if (result)
                return Json(new OperationResult(OperationResultType.Success, "删除成功！"), JsonRequestBehavior.DenyGet);
            else
                return Json(new OperationResult(OperationResultType.Error, "删除失败，请稍后再试！"), JsonRequestBehavior.DenyGet);
        }
        #endregion

        #region 冻结帐号
        [HttpPost]
        public ActionResult FreezeUser(int id)
        {
            var result = _accountCore.ModifyState(id, 1);
            if (result)
                return Json(new OperationResult(OperationResultType.Success, "冻结成功！"), JsonRequestBehavior.DenyGet);
            else
                return Json(new OperationResult(OperationResultType.Error, "冻结失败，请稍后再试！"), JsonRequestBehavior.DenyGet);

        }
        #endregion
        #endregion
    }
}

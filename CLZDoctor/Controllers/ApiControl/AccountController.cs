using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CLZDoctor.Domain;
using CLZDoctor.Entities;
using CLZDoctor.Domain.Common;
using Newtonsoft.Json;
namespace CLZDoctor.Controllers.ApiControl
{
    public class AccountController : ApiController
    {
        private readonly IAccountCore _accountCore;

        public AccountController(IAccountCore accountCore)
        {
            _accountCore = accountCore;
        }
        //IHttpActionResult
        public string RegisterAccount(Account account)
        {
            if (string.IsNullOrEmpty(account.Name))
                return Json(new OperationResult(OperationResultType.ParamError, "用户名不能为空！"));
            if (string.IsNullOrEmpty(account.Mobile))
                return Json(new OperationResult(OperationResultType.ParamError, "手机号不能为空！"));
            if (string.IsNullOrEmpty(account.Password))
                return Json(new OperationResult(OperationResultType.ParamError, "密码不能为空！"));

            int re = _accountCore.CreateAccount(account);
            if (re > 0)
            {
                return Json(new OperationResult(OperationResultType.Success, "用户创建成功！"));
            }
            else
            {
                return Json(new OperationResult(OperationResultType.Error, "用户创建失败！"));
            }
        }

        public string UpdatePwd(int id, string oldpwd, string password)
        {
            if (string.IsNullOrEmpty(password))
                return Json(new OperationResult(OperationResultType.ParamError, "密码不能为空！"));

            bool re = _accountCore.ModifyPassword(id, password);
            if (re)
                return Json(new OperationResult(OperationResultType.Success, "密码修改成功！"));
            else
                return Json(new OperationResult(OperationResultType.Error, "密码修改失败！"));
        }

        public string Json(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }


    }
}

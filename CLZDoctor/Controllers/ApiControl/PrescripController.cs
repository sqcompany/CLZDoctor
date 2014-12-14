using CLZDoctor.Domain;
using CLZDoctor.Domain.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CLZDoctor.Controllers.ApiControl
{
    public class PrescripController : ApiController
    {
        private readonly IPrescriptionCore _prescriptionCore;
        public PrescripController(IPrescriptionCore prescriptionCore)
        {
            _prescriptionCore = prescriptionCore;
        }

        public string Query(int type = 1, string value = "", int take = 10, int skip = 1)
        {
            if (string.IsNullOrEmpty(value))
                return Json(new OperationResult(OperationResultType.ParamError, "搜索内容不能为空！"));

            int count;
            var list = _prescriptionCore.SelectPrescriptions(type, value, take, skip, out  count);
            var json = new { total = count, rows = list };
            return Json(json);
        }

        public string Json(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}

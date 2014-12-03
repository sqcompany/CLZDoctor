using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Transactions;
using CLZDoctor.Entities;
using Ninject;

// ReSharper disable once CheckNamespace
namespace CLZDoctor.Domain
{
    public class PrescriptionCore : IPrescriptionCore
    {
        private readonly static IKernel Kernel = new StandardKernel(new DomainModule());
        public int Insert(Prescription prescription)
        {
            var pId = Kernel.Get<IPrescriptionRepo>().Insert(prescription);
            if (pId > 0)
            {
                InsertRecipe(prescription.MakeUp, pId);
            }
            return pId;
        }

        public void SplitRecipe()
        {
            var prescrList = Kernel.Get<IPrescriptionRepo>().SelectList();
            foreach (var prescription in prescrList)
            {
                InsertRecipe(prescription.MakeUp, prescription.Id);
            }
        }

        public bool Update(Prescription prescription)
        {
            var ustate = Kernel.Get<IPrescriptionRepo>().Update(prescription);
            if (!ustate) return false;
            using (var trans = new TransactionScope())
            {
                var dstate = Kernel.Get<IRecipeRepo>().Delete(prescription.Id);
                InsertRecipe(prescription.MakeUp, prescription.Id);
                if (dstate)
                    trans.Complete();
            }
            return true;
        }

        /// <summary>
        /// 分页获取方剂
        /// </summary>
        /// <param name="value">查询条件</param>
        /// <param name="take">获取记录数</param>
        /// <param name="skip">当前索引（索引值从1开始）</param>
        /// <param name="count">总记录数</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public List<Prescription> SelectPrescriptions(int type, string value, int take, int skip, out int count)
        {
            var values = value.Trim().Trim(',').Trim('，');
            var repo = Kernel.Get<IPrescriptionRepo>();
            count = repo.Size(type, values);
            var list = repo.SelectList(type, values, take, skip).ToList();
            if (string.IsNullOrEmpty(value))
                return list;
            foreach (var pre in list)
            {
                switch (type)
                {
                    case 2:
                        pre.MakeUp = pre.MakeUp.Replace(value, "<span style=\"color:red;font-weight:bold;\">" + value + "</span>");
                        break;
                    case 1:
                        pre.Name = pre.Name.Replace(value, "<span style=\"color:red;font-weight:bold;\">" + value + "</span>");
                        break;
                }
            }
            return list;
        }

        public List<Prescription> SelectPrescriptions(List<string> names)
        {
            var ids = Kernel.Get<IRecipeRepo>().SelectList(names);
            var pres = new List<Prescription>();
            if (ids.Count <= 0) return pres;
            pres = Kernel.Get<IPrescriptionRepo>().SelectList(ids).ToList();
            foreach (var pre in pres)
            {
                foreach (var l in names)
                {
                    pre.MakeUp = pre.MakeUp.Replace(l, "<span style=\"color:red;font-weight:bold;\">" + l + "</span>");
                }
            }
            return pres;
        }

        public Prescription SelectPrescription(int id)
        {
            return Kernel.Get<IPrescriptionRepo>().SelectPrescription(id);
        }

        public bool Delete(int id)
        {
            return Kernel.Get<IPrescriptionRepo>().Delete(id);
        }

        #region ==== 私有方法 ====
        private static void InsertRecipe(string makeUp, int pId)
        {
            var recipes = makeUp.Trim().Replace("  ", " ").Split(' ');
            if (recipes.Length == 1)
            {
                recipes = makeUp.Trim().Replace("、", " ").Replace("，", " ").Replace("  ", " ").Split(' ');
            }
            foreach (var r in recipes)
            {
                //int mId;
                //var m = Kernel.Get<IMaterialsRepo>().SelectMaterials(r);
                //if (m == null)
                //{
                //    mId = Kernel.Get<IMaterialsRepo>().Insert(new Materials
                //    {
                //        Name = r,
                //        Alias = r,
                //        State = 0
                //    });
                //}
                //else
                //{
                //    mId = m.Id;
                //}

                Kernel.Get<IRecipeRepo>().Insert(new Recipe
                {
                    Name = r,
                    PrescripId = pId,
                    MaterialsId = 0,
                    State = 0
                });
            }
        }
        #endregion



    }
}

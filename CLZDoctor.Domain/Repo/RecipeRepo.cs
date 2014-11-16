using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLZDoctor.Entities;
using Dapper;
using Ninject;

// ReSharper disable once CheckNamespace
namespace CLZDoctor.Domain
{
    internal class RecipeRepo : IRecipeRepo
    {
        private static readonly IKernel Kernel = new StandardKernel(new DomainModule());
        public int Insert(Recipe recipe)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = @"insert into recipe(PrescripId,MaterialsId,[Name],Dosage,Unit,State,CreateTime,UpdateTime)
                                 values(@PrescripId,@MaterialsId,@Name,@Dosage,@Unit,@State,@CreateTime,@UpdateTime);select @@identity;";
                return conn.ExecuteScalar<int>(sql, recipe);
            }
        }

        public IEnumerable<Recipe> SelectList(int prescripId)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "select * from recipe where PrescripId=@p0";
                return conn.Query<Recipe>(sql, new { p0 = prescripId });
            }
        }

        public List<int> SelectList(List<string> recipes)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                var strb = new StringBuilder();
                strb.Append("select PrescripId from (");
                strb.Append(" select PrescripId,Count(*) Num from recipe where ");
                foreach (var recipe in recipes)
                {
                    if (recipes.IndexOf(recipe) == 0)
                    {
                        strb.Append(string.Format(" [Name] like '%{0}%' ", recipe));
                    }
                    else
                    {
                        strb.Append(string.Format(" or [Name] like '%{0}%' ", recipe));
                    }
                    
                }
                strb.Append(" group by PrescripId ) b where b.Num > 1 order by b.Num desc");
                return conn.Query<int>(strb.ToString()).ToList();
            }
        }


        public bool Delete(int prescriptId)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "delete from recipe where PrescripId=@PrescripId ";
                return conn.Execute(sql, new { PrescripId = prescriptId }) > 0;
            }
        }
    }
}

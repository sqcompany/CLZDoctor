using System.Collections.Generic;
using System.Linq;
using CLZDoctor.Entities;
using Dapper;
using Ninject;

// ReSharper disable once CheckNamespace
namespace CLZDoctor.Domain
{
    internal class MaterialsRepo : IMaterialsRepo
    {
        private static readonly IKernel Kernel = new StandardKernel(new DomainModule());
        public int Insert(Materials materials)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = @"insert into materials([Name],Alias,State,CreateTime,UpdateTime)
                                 values(@Name,@Alias,@State,@CreateTime,@UpdateTime);select @@identity;";
                return conn.ExecuteScalar<int>(sql, materials);
            }
        }

        public IEnumerable<Materials> SelectMaterialses(string name)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                var sql = string.Format("select * from materials where Name like '%{0}%'", name);
                return conn.Query<Materials>(sql);
            }
        }

        public Materials SelectMaterials(string name)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                var sql = string.Format("select * from materials where Name='{0}' or Alias='{1}'", name, name);
                return conn.Query<Materials>(sql).SingleOrDefault<Materials>();
            }
        }
    }
}

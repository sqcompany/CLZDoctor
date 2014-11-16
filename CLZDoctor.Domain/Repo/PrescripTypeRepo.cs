using System.Collections.Generic;
using System.Linq;
using CLZDoctor.Entities;
using Dapper;
using Ninject;


// ReSharper disable once CheckNamespace
namespace CLZDoctor.Domain
{
    public class PrescripTypeRepo : IPrescripTypeRepo
    {
        private static readonly IKernel Kernel = new StandardKernel(new DomainModule());
        public IEnumerable<PrescripType> SelectPrescripTypes()
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = @"select * from prescriptype ";
                return conn.Query<PrescripType>(sql);
            }
        }

        public int Insert(PrescripType prescripType)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = @"insert into prescriptype(Name,ParentId,Remark,State,CreateTime,UpdateTime)
                                     values(@Name,@ParentId,@Remark,@State,@CreateTime,@UpdateTime);select @@identity;";
                return conn.ExecuteScalar<int>(sql, prescripType);
            }
        }

        public bool Update(PrescripType prescripType)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = @"update prescriptype set Name=@Name,ParentId=@ParentId,Remark=@Remark,UpdateTime=@UpdateTime where Id=@Id ";
                return conn.Execute(sql, prescripType) > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "update prescriptype set State=1 where Id=@Id";
                return conn.Execute(sql, new { Id = id }) > 0;
            }
        }


        public PrescripType SelectPrescripType(int id)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "select * from prescriptype where Id=@Id";
                return conn.Query<PrescripType>(sql, new {Id = id}).SingleOrDefault<PrescripType>();
            }
        }
    }
}

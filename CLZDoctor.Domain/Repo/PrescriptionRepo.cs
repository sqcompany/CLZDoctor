using System.Collections.Generic;
using System.Linq;
using CLZDoctor.Entities;
using Dapper;
using Ninject;

// ReSharper disable once CheckNamespace
namespace CLZDoctor.Domain
{
    internal class PrescriptionRepo : IPrescriptionRepo
    {
        private static readonly IKernel Kernel = new StandardKernel(new DomainModule());
        public int Insert(Prescription prescription)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = @"insert into prescription([Type]
                                   ,[Name]
                                   ,[Alias]
                                   ,[MakeUp]
                                   ,[Usage]
                                   ,[Effect]
                                   ,[Explain]
                                   ,[FangGe]
                                   ,[Notes]
                                   ,[Related]
                                   ,[Similar]
                                   ,[Source]
                                   ,[Remark]
                                   ,[State]
                                   ,[CreateTime]
                                   ,[UpdateTime])
                                   values(@Type
                                   ,@Name
                                   ,@Alias
                                   ,@MakeUp
                                   ,@Usage
                                   ,@Effect
                                   ,@Explain
                                   ,@FangGe
                                   ,@Notes
                                   ,@Related
                                   ,@Similar
                                   ,@Source
                                   ,@Remark
                                   ,@State
                                   ,@CreateTime
                                   ,@UpdateTime);select @@identity;";
                return conn.ExecuteScalar<int>(sql, prescription);
            }
        }

        public bool Update(Prescription prescription)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = @"update prescription set
                                    [Name]=@Name
                                   ,[Alias]=@Alias
                                   ,[MakeUp]=@MakeUp
                                   ,[Usage]=@Usage
                                   ,[Effect]=@Effect
                                   ,[Explain]=@Explain
                                   ,[FangGe]=@FangGe
                                   ,[Notes]=@Notes
                                   ,[Related]=@Related
                                   ,[Similar]=@Similar
                                   ,[Source]=@Source
                                   ,[Remark]=@Remark
                                   ,[UpdateTime]=@UpdateTime where Id=@Id";
                return conn.Execute(sql, prescription) > 0;
            }
        }

        public int Size(int type, string value)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                var strWhere = GetSearchWhere(type, value);
                var sql = "select count(*) from prescription " + strWhere;
                return conn.ExecuteScalar<int>(sql);
            }
        }

        public IEnumerable<Prescription> SelectList()
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                var sql = string.Format(@"select * from prescription ");
                return conn.Query<Prescription>(sql);
            }
        }
        public IEnumerable<Prescription> SelectList(string name)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                var sql = string.Format(@"select * from prescription where Name like '%{0}%' or Alias like '%{1}%'", name, name);
                return conn.Query<Prescription>(sql);
            }
        }

        public IEnumerable<Prescription> SelectList(int type, string value, int take, int skip)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                var strWhere = GetSearchWhere(type, value);
                var sql = string.Format(@"select Id,[Type],[Name],Alias,MakeUp,Effect,Remark,State,CreateTime,UpdateTime from 
                                    (select *,row_number() over (order by UpdateTime desc) n from prescription {0}) pp where pp.n>@p0 and pp.n<=@p1 and State=0", strWhere);
                return conn.Query<Prescription>(sql, new { p0 = (skip - 1) * take, p1 = skip * take });
            }
        }

        public IEnumerable<Prescription> SelectList(List<int> ids)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                var sql = string.Format(" select * from prescription where Id in ({0})", string.Join(",", ids));
                return conn.Query<Prescription>(sql);
            }
        }

        private string GetSearchWhere(int type, string value)
        {
            var strWhere = "where 1=1 ";
            if (string.IsNullOrEmpty(value))
                return strWhere;
            switch (type)
            {
                case 1:
                    strWhere += string.Format(" and [Name] like '%{0}%'", value);
                    break;
                case 2:
                    var makeups = value.Split(' ');
                    strWhere = makeups.Aggregate(strWhere, (current, s) => current + string.Format(" and charindex('{0}',MakeUp)>0 ", s));
                    break;
                default:
                    strWhere = "";
                    break;
            }
            return strWhere;
        }

        public bool Delete(int id)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = @"update prescription set State=1 where Id=@p0";
                return conn.Execute(sql, new { p0 = id }) > 0;
            }
        }


        public Prescription SelectPrescription(int id)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "select * from prescription where Id=@Id";
                return conn.Query<Prescription>(sql, new {Id = id}).SingleOrDefault();
            }
        }
    }
}

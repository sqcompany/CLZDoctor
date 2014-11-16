using System;
using System.Collections.Generic;
using CLZDoctor.Entities;
using Dapper;
using Ninject;

namespace CLZDoctor.Domain
{
    internal class MedicalRepo : IMedicalRepo
    {
        private static readonly IKernel Kernel = new StandardKernel(new DomainModule());


        public int Insert(Medical medical)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = @"insert into medical(Patient,Age,Gender,Diagnose,Treatment,Contract,IsVisit,VisitResult,Prescription,State,CreateTime,UpdateTime)
                                     values(@Patient,@Age,@Gender,@Diagnose,@Treatment,@Contract,@IsVisit,@VisitResult,@Prescription,@State,@CreateTime,@UpdateTime);select @@identity";
                return conn.ExecuteScalar<int>(sql, medical);
            }
        }

        public IEnumerable<Medical> SelectMedicals()
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "select * from medical where State=0";
                return conn.Query<Medical>(sql);
            }
        }

        public IEnumerable<Medical> SelectMedicals(int take, int skip)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = @"select * from (select *,row_number() over (order by UpdateTime desc) n from medical where State=0) pp where pp.n>@p0 and pp.n<=@p1 ";
                return conn.Query<Medical>(sql, new { p0 = (skip - 1) * take, p1 = skip * take });
            }
        }

        public bool Update(int id, int isVisit)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "update medical set IsVisit=@IsVisit where Id=@Id";
                return conn.Execute(sql, new { IsVisit = @isVisit, Id = id }) > 0;
            }
        }


        public int Size()
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "select count(*) from medical where State=0";
                return conn.ExecuteScalar<int>(sql);
            }
        }
    }
}

using System.Collections.Generic;
using CLZDoctor.Entities;
using Dapper;
using Ninject;

namespace CLZDoctor.Domain
{
    public class GrabDataRepo : IGrabDataRepo
    {
        private static readonly IKernel Kernel = new StandardKernel(new DomainModule());
        public int Add(GrabData grabData)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "insert into grabdata([Name],[Url],State,CreateTime,UpdateTime) values(@Name,@Url,@State,@CreateTime,@UpdateTime);select @@identity";
                return conn.ExecuteScalar<int>(sql, grabData);
            }
        }

        public IEnumerable<GrabData> Select()
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "select * from grabdata where [State]=0";
                return conn.Query<GrabData>(sql);
            }
        }

        public IEnumerable<GrabData> Select(int count)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                var sql = string.Format("select top {0} * from grabdata where [State]=1", count);
                return conn.Query<GrabData>(sql);
            }
        }

        public void UpdateState(int id, int state)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "update grabdata set [State]=@State where Id=@Id";
                conn.Execute(sql, new { State = state, Id = id });
            }
        }
    }
}

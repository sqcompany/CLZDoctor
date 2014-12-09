using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLZDoctor.Entities;
using Dapper;
using Ninject;

namespace CLZDoctor.Domain
{
    internal class FavoriteRepo : IFavoriteRepo
    {
        private static readonly IKernel Kernel = new StandardKernel(new DomainModule());
        public IEnumerable<Favorite> SelectFavorites(FavoriteQuery query, int take, int skip, out int count)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                var strWhere = SqlWhere(query);
                var sql_count = string.Format("select count(1) from favorite {0}", strWhere);
                var sql = string.Format(@"select Id,UserId,UserName,PrescripId,PrescripName,Remark,State,CreateTime,UpdateTime from
                                    (select *,row_number() over (order by CreateTime desc) n from favorite {0}) pp where pp.n>@p0 and pp.n<=@p1", strWhere);
                count = conn.ExecuteScalar<int>(sql_count);
                return conn.Query<Favorite>(sql, new { p0 = (skip - 1) * take, p1 = take * skip });
            }
        }

        private string SqlWhere(FavoriteQuery query)
        {
            var strSql = new StringBuilder();
            strSql.Append("where 1=1 ");
            if (query.UserName != string.Empty)
                strSql.Append(string.Format(" and [UserName] = '{0}'", query.UserName));
            return strSql.ToString();
        }
    }
}

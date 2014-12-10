using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLZDoctor.Entities;
using Ninject;
using Dapper;

namespace CLZDoctor.Domain
{
    internal class AccountRepo : IAccountRepo
    {
        private readonly IKernel Kernel = new StandardKernel(new DomainModule());
        public int InsertAccount(Account account)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = @"insert into account([Name],[Mobile],[Password],[CurrState],[State],[CreateTime],[UpdateTime])
                                    values(@Name,@Mobile,@Password,@CurrState,@State,@CreateTime,@UpdateTime);select @@identity;";
                return conn.ExecuteScalar<int>(sql, account);
            }
        }

        public IEnumerable<Account> SelectAccounts(AccountQuery query, int take, int skip, out int count)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                var strWhere = SqlWhere(query);
                var sql_count = string.Format("select count(1) from account {0}", strWhere);
                var sql = string.Format(@"select Id,Name,Mobile,Password,CurrState,State,CreateTime,UpdateTime from
                                    (select *,row_number() over (order by CreateTime desc) n from account {0}) pp where pp.n>@p0 and pp.n<=@p1", strWhere);
                count = conn.ExecuteScalar<int>(sql_count);
                return conn.Query<Account>(sql, new { p0 = (skip - 1) * take, p1 = take * skip });
            }
        }

        public Account SelectAccountByMobile(string mobile)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "select * from account where [Mobile]=@p0";
                return conn.Query<Account>(sql, new { p0 = mobile }).SingleOrDefault<Account>();
            }
        }

        public Account SelectAccountByMobile(string mobile, string password)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "select * from account where [Mobile]=@p0 and [Password]=@p1";
                return conn.Query<Account>(sql, new { p0 = mobile, p1 = password }).SingleOrDefault<Account>();
            }
        }

        public Account SelectAccountByName(string name, string password)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "select * from account where [Name]=@p0 and [Password]=@p1";
                return conn.Query<Account>(sql, new { p0 = name, p1 = password }).SingleOrDefault<Account>();
            }
        }

        public Account SelectAccountByName(string name)
        {
            using (var conn=Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "select * from account where [Name]=@p0";
                return conn.Query<Account>(sql, new { p0 = name }).SingleOrDefault<Account>();
            }
        }

        public Account SelectAccountById(int id)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "select * from account where Id=@p0";
                return conn.Query<Account>(sql, new { p0 = id }).SingleOrDefault<Account>();
            }
        }

        public int UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public int UpdateState(int id, int state)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "update account set CurrState=@p0 where Id=@p1";
                return conn.Execute(sql, new { p0 = state, p1 = id });
            }
        }

        public int UpdatePassword(int id, string password)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "update account set [Password]=@p0 where Id=@p1";
                return conn.Execute(sql, new { p0 = password, p1 = id });
            }
        }

        public int DeleteAccount(int id)
        {
            using (var conn = Kernel.Get<IBaseRepo>().OpenConnection())
            {
                const string sql = "update account set State=1 where Id=@p0";
                return conn.Execute(sql, new { p0 = id });
            }
        }

        #region 私有方法
        private string SqlWhere(AccountQuery query)
        {
            var strSql = new StringBuilder();
            strSql.Append("where 1=1 ");
            if (query.Name != string.Empty)
                strSql.Append(string.Format(" and [Name] like '%{0}%'", query.Name));
            if (query.Mobile != string.Empty)
                strSql.Append(string.Format(" and [Mobile] like '%{0}%'", query.Mobile));
            return strSql.ToString();
        }
        #endregion
    }
}

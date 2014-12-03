using System.Data;
using System.Data.SqlClient;

// ReSharper disable once CheckNamespace
namespace CLZDoctor.Domain
{
    public class SqlBaseRepo : IBaseRepo
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public readonly string Sqlconnection = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString().Trim();
        //获取Sql Server的连接数据库对象。SqlConnection
        public IDbConnection OpenConnection()
        {
            //var sqlconnection = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            var connection = new SqlConnection(Sqlconnection);
            connection.Open();
            return connection;
        }
    }
}

using System.Collections.Generic;
using CLZDoctor.Entities;

namespace CLZDoctor.Domain
{
    public interface IAccountCore
    {
        /// <summary>
        /// 创建帐号
        /// </summary>
        /// <param name="account">帐号实例</param>
        /// <returns></returns>
        int CreateAccount(Account account);

        /// <summary>
        /// 分页查询用户
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="take">大小</param>
        /// <param name="skip">当前索引</param>
        /// <param name="count">总数</param>
        /// <returns></returns>
        IEnumerable<Account> GetAccounts(AccountQuery query,int take,int skip,out int count);
        /// <summary>
        /// 根据用户名和密码查询用户信息
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        Account GetAccount(string mobile,string password);
        /// <summary>
        /// 修改用户状态，如冻结用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="currState">用户状态</param>
        /// <returns></returns>
        bool ModifyState(int id, int currState);
        /// <summary>
        /// 用户修改密码
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="password">用户新密码</param>
        /// <returns></returns>
        bool ModifyPassword(int id, string password);
        /// <summary>
        /// 删除用户，此处为逻辑删除，只修改state字段状态
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        bool DeleteAccount(int id);

    }
}

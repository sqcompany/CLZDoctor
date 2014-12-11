using System.Collections.Generic;
using CLZDoctor.Entities;

namespace CLZDoctor.Domain
{
    internal interface IAccountRepo
    {
        int InsertAccount(Account account);
        IEnumerable<Account> SelectAccounts(AccountQuery query, int take, int skip, out int count);
        Account SelectAccountByMobile(string mobile);
        Account SelectAccountByMobile(string mobile, string password);
        Account SelectAccountByName(string name, string password);
        Account SelectAccountByName(string name);
        Account SelectAccountById(int id);
        int UpdateAccount(Account account);
        int UpdateState(int id, int state);
        int UpdatePassword(int id, string password);
        int DeleteAccount(int id);
        
    }
}

using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLZDoctor.Entities;

namespace CLZDoctor.Domain
{
    public class AccountCore : IAccountCore
    {
        private readonly static IKernel Kernel = new StandardKernel(new DomainModule());
        public int CreateAccount(Account account)
        {
            return Kernel.Get<IAccountRepo>().InsertAccount(account);
        }

        public IEnumerable<Account> GetAccounts(AccountQuery query, int take, int skip, out int count)
        {
            return Kernel.Get<IAccountRepo>().SelectAccounts(query, take, skip, out count);
        }

        public Account GetAccount(string mobile, string password)
        {
            return Kernel.Get<IAccountRepo>().SelectAccountByMobile(mobile, password);
        }

        public bool ModifyState(int id, int currState)
        {
            return Kernel.Get<IAccountRepo>().UpdateState(id, currState) > 0;
        }

        public bool ModifyPassword(int id, string password)
        {
            return Kernel.Get<IAccountRepo>().UpdatePassword(id, password) > 0;
        }

        public bool DeleteAccount(int id)
        {
            return Kernel.Get<IAccountRepo>().DeleteAccount(id) > 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLZDoctor.Domain
{
    public class AccountCore : IAccountCore
    {
        public int CreateAccount(Entities.Account account)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.Account> GetAccounts(Entities.AccountQuery query, int take, int skip, out int count)
        {
            throw new NotImplementedException();
        }

        public Entities.Account GetAccount(string mobile, string password)
        {
            throw new NotImplementedException();
        }

        public bool ModifyState(int id, int currState)
        {
            throw new NotImplementedException();
        }

        public bool ModifyPassword(int id, string password)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }
    }
}

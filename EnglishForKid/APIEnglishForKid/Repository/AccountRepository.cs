using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using APIEnglishForKid.Models;

namespace APIEnglishForKid.Repository
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(EnglishDatabase englishDatabse) : base(englishDatabse)
        {
        }

        public Account GetAccountByUserName(string username)
        {
            return _database.Accounts.Where(x => x.UserName == username).First();
        }
    }
}
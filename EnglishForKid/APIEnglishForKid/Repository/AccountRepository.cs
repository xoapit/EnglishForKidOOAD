using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using APIEnglishForKid.Models;

namespace APIEnglishForKid.Repository
{
    public class AccountRepository : GenericRepository<ApplicationUser>, IAccountRepository
    {
        public AccountRepository(EnglishDatabase englishDatabse) : base(englishDatabse)
        {
        }

        public ApplicationUser GetAccountByUserName(string username)
        {
            return _database.Users.Where(x => x.UserName == username).First();
        }
    }
}
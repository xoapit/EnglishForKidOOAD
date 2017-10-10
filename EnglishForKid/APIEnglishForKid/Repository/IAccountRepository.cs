using APIEnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEnglishForKid.Repository
{
    interface IAccountRepository
    {
        ApplicationUser GetAccountByUserName(string username);
    }
}

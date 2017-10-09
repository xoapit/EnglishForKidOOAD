using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using APIEnglishForKid.Models;

namespace APIEnglishForKid.Repository
{
    public class AuthorityRepository : GenericRepository<Business>
    {
        public AuthorityRepository(EnglishDatabase englishDatabse) : base(englishDatabse)
        {
        }
    }
}
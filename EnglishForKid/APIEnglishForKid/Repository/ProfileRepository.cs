using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using APIEnglishForKid.Models;

namespace APIEnglishForKid.Repository
{
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(EnglishDatabase englishDatabse) : base(englishDatabse)
        {
        }

        public Profile GetProfileByUserName(string username)
        {
            return _database.Profiles.Where(x => x.Account.UserName == username).First();
        }
    }
}
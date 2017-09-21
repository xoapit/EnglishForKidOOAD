using APIEnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIEnglishForKid.Repository
{
    public class UnitOfWork
    {
        private static UnitOfWork _unitOfWork = null;

        private EnglishDatabase _englishDatabase = null;

        private AccountRepository _accountRepository = null;
        private ProfileRepository _profileRepository = null;
        private AuthorityRepository _authorityRepository = null;

        private UnitOfWork()
        {
            _englishDatabase = new EnglishDatabase();
        }

        public static UnitOfWork GetInstance()
        {
            if (_unitOfWork == null)
            {
                if (_unitOfWork == null)
                {
                    _unitOfWork = new UnitOfWork();
                }
            }
            return _unitOfWork;
        }

        public AccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new AccountRepository(_englishDatabase);
                }
                return _accountRepository;
            }
        }

        public ProfileRepository ProfileRepository
        {
            get
            {
                if (_profileRepository == null)
                {
                    _profileRepository = new ProfileRepository(_englishDatabase);
                }
                return _profileRepository;
            }
        }

        public AuthorityRepository AuthorityRepository
        {
            get
            {
                if (_authorityRepository == null)
                {
                    _authorityRepository = new AuthorityRepository(_englishDatabase);
                }
                return _authorityRepository;
            }
        }
    }
}
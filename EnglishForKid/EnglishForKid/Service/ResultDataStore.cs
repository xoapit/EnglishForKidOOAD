using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace EnglishForKid.Service
{
    public class ResultDataStore : BaseDataStore, IDataStore<Result>
    {
        public Task<bool> AddItemAsync(Result item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Result>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Result item)
        {
            throw new NotImplementedException();
        }
    }
}
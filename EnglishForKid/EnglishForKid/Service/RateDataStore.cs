using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EnglishForKid.Service
{
    public class RateDataStore : BaseDataStore, IDataStore<Rate>
    {
        public Task<bool> AddItemAsync(Rate item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Rate> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Rate>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Rate item)
        {
            throw new NotImplementedException();
        }
    }
}
using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EnglishForKid.Service
{
    public class FeedbackDataStore : BaseDataStore, IDataStore<Feedback>
    {
        public Task<bool> AddItemAsync(Feedback item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Feedback> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Feedback>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Feedback item)
        {
            throw new NotImplementedException();
        }
    }
}
using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace EnglishForKid.Service
{
    public class CommentDataStore : BaseDataStore, IDataStore<Comment>
    {
        public Task<bool> AddItemAsync(Comment item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Comment item)
        {
            throw new NotImplementedException();
        }
    }
}
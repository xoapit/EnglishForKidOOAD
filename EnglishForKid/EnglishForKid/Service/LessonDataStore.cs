using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace EnglishForKid.Service
{
    public class LessonDataStore : BaseDataStore, IDataStore<Lesson>
    {
        public Task<bool> AddItemAsync(Lesson item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Lesson> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Lesson>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Lesson item)
        {
            throw new NotImplementedException();
        }
    }
}
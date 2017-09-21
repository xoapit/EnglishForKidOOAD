using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EnglishForKid.Service
{
    public interface IDataStore<T> where T : class
    {
        Task<T> GetItemAsync(Guid id);
        Task<List<T>> GetItemsAsync();
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(Guid id);
        Task InitializeAsync();
    }
}
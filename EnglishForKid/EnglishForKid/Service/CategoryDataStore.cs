using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace EnglishForKid.Service
{
    public class CategoryDataStore : BaseDataStore, IDataStore<Category>
    {
        public Task<bool> AddItemAsync(Category item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetItemAsync(Guid id)
        {
            Category category = null;
            String path = "/api/categories" + id.ToString();
            HttpResponseMessage respone = await client.GetAsync(path).ConfigureAwait(false);
            if (respone.IsSuccessStatusCode)
            {
                category = await respone.Content.ReadAsAsync<Category>();
            }

            return category;
        }

        public async Task<List<Category>> GetItemsAsync()
        {
            List<Category> listCategories = null;

            String path = "/api/categories";
            HttpResponseMessage respone = await client.GetAsync(path).ConfigureAwait(false);
            if (respone.IsSuccessStatusCode)
            {
                listCategories = await respone.Content.ReadAsAsync<List<Category>>();
            }

            return listCategories;
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
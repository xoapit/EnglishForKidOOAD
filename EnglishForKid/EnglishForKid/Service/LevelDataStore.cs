using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace EnglishForKid.Service
{
    public class LevelDataStore : BaseDataStore, IDataStore<Level>
    {
        public Task<bool> AddItemAsync(Level item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Level> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Level>> GetItemsAsync()
        {
            List<Level> listLevel = null;
            String path = "api/levels";
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                listLevel = await response.Content.ReadAsAsync<List<Level>>();
            }
            return listLevel;
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Level item)
        {
            throw new NotImplementedException();
        }
    }
}
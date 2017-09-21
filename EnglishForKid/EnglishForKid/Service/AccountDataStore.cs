using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EnglishForKid.Service
{
    public class AccountDataStore : BaseDataStore, IDataStore<Account>
    {
        private List<Account> accounts;

        public AccountDataStore()
        {
            InitializeAsync();
        }

        public Task<bool> AddItemAsync(Account item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Account>> GetItemsAsync()
        {
            string apiUrl = "api/accounts";
            var response = await client.GetAsync(apiUrl).ConfigureAwait(false);
            string jsonString = null;
            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content?.ReadAsStringAsync();
            }

            accounts = JsonConvert.DeserializeObject<List<Account>>(jsonString);
            return await Task.FromResult<List<Account>>(accounts);
        }

        public Task InitializeAsync()
        {
            accounts = new List<Account>();
            return Task.FromResult(accounts);
        }

        public Task<bool> UpdateItemAsync(Account item)
        {
            throw new NotImplementedException();
        }
    }
}
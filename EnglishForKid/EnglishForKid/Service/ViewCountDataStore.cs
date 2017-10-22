using EnglishForKid.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;

namespace EnglishForKid.Service
{
    public class ViewCountDataStore : BaseDataStore, IDataStore<ViewCountViewModel>
    {
        public Task<bool> AddItemAsync(ViewCountViewModel item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ViewCountViewModel> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ViewCountViewModel>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(ViewCountViewModel item)
        {
            throw new NotImplementedException();
        }
        public async Task<string> GetCountAsync() {
            string path = "api/Views/SetViewCount";
            string viewCountViewModel="";
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode) {
                viewCountViewModel = await response.Content.ReadAsStringAsync();
            }
            return viewCountViewModel;

        }
    }
}
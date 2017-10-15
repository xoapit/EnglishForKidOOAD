using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;

namespace EnglishForKid.Service
{
    public class ResultDataStore : BaseDataStore, IDataStore<Result>
    {
        public async Task<bool> AddItemAsync(Result item)
        {
            String path = "/api/AnswerSurveys";
            HttpResponseMessage response = await client.PostAsJsonAsync(path, item);
            return await Task.FromResult(response.IsSuccessStatusCode);

        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            String path = "/api/AnswerSurveys" +id.ToString();
            HttpResponseMessage response = await client.DeleteAsync(path);
            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<Result> GetItemAsync(Guid id)
        {
            Result result = null;
            String path = "/api/AnswerSurveys" + id.ToString();
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<Result>();
            }
            return result;
        }

        public async Task<List<Result>> GetItemsAsync()
        {
            List<Result> ListResult = null;
            String path = "/api/AnswerSurveys";
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                ListResult = await response.Content.ReadAsAsync<List<Result>>();
            }
            return ListResult;
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
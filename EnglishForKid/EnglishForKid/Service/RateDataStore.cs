using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace EnglishForKid.Service
{
    public class RateDataStore : BaseDataStore, IDataStore<Rate>
    {
        public async Task<bool> AddItemAsync(Rate item)
        {
            String path = "/api/Rates";
            HttpResponseMessage response = await client.PostAsJsonAsync(path, item).ConfigureAwait(false);

            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            String path = "/api/Rates" + id.ToString();

            HttpResponseMessage response = await client.DeleteAsync(path).ConfigureAwait(false);

            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<Rate> GetItemAsync(Guid id)
        {
            Rate rate = null;

            string path = "/api/Rates" + id.ToString();
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                rate = await response.Content.ReadAsAsync<Rate>();
            }
            return rate;
        }

        public async Task<Rate> GetRateByLessonAndUserAsync(Guid lessonID, string userID)
        {
            Rate rate = null;

            string path = "/api/Rates?lessonID=" + lessonID.ToString() + "&userID=" + userID;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                rate = await response.Content.ReadAsAsync<Rate>();
            }
            return rate;
        }

        public async Task<float> GetAverageRateByLessonIDAsync(Guid id)
        {
            string rate = "0";

            string path = "/api/Rates?lessonID=" + id.ToString();
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                rate = await response.Content.ReadAsStringAsync();
            }
            return float.Parse(rate);
        }

        public async Task<List<Rate>> GetItemsAsync()
        {
            List<Rate> rate = null;
            String path = "/api/Rates";
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                rate = await response.Content.ReadAsAsync<List<Rate>>();
            }
            return rate;
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
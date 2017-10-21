using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


namespace EnglishForKid.Service
{
    public class FeedbackDataStore : BaseDataStore, IDataStore<Feedback>
    {
        public async Task<bool> AddItemAsync(Feedback item)
        {
            string path = "/api/feedbacks";
            HttpResponseMessage response = await client.PostAsJsonAsync(path, item).ConfigureAwait(false);

            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            string path = "/api/feedbacks/" + id.ToString();
            HttpResponseMessage response = await client.DeleteAsync(path);

            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<Feedback> GetItemAsync(Guid id)
        {
            string path = "/api/feedbacks/" + id.ToString();
            Feedback feedback = null;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                feedback = await response.Content.ReadAsAsync<Feedback>();
            }
            return feedback;
        }

        public async Task<List<Feedback>> GetItemsAsync()
        {
            string path = "/api/feedbacks";
            List<Feedback> feedbacks = null;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                feedbacks = await response.Content.ReadAsAsync<List<Feedback>>();
            }
            return feedbacks;
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(Feedback item)
        {
            string path = "/api/feedbacks/" + item.ID;
            HttpResponseMessage response = await client.PutAsJsonAsync(path, item).ConfigureAwait(false);

            return await Task.FromResult(response.IsSuccessStatusCode);
        }
    }
}
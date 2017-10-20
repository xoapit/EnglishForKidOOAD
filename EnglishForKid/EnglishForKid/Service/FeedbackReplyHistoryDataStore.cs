using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


namespace EnglishForKid.Service
{
    public class FeedbackReplyHistoryDataStore : BaseDataStore, IDataStore<FeedbackReplyHistory>
    {
        public async Task<bool> AddItemAsync(FeedbackReplyHistory item)
        {
            string path = "/api/FeedbackReplyHistories";
            HttpResponseMessage response = await client.PostAsJsonAsync(path, item).ConfigureAwait(false);

            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            string path = "/api/FeedbackReplyHistories/" + id.ToString();
            HttpResponseMessage response = await client.DeleteAsync(path).ConfigureAwait(false);

            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<FeedbackReplyHistory> GetItemAsync(Guid id)
        {
            string path = "/api/FeedbackReplyHistories/" + id.ToString();
            FeedbackReplyHistory feedbackReplyHistory = null;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                feedbackReplyHistory = await response.Content.ReadAsAsync<FeedbackReplyHistory>();
            }
            return feedbackReplyHistory;
        }

        public async Task<List<FeedbackReplyHistory>> GetItemsAsync()
        {
            string path = "/api/FeedbackReplyHistories";
            List<FeedbackReplyHistory> feedbackHistories = new List<FeedbackReplyHistory>();
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                feedbackHistories = await response.Content.ReadAsAsync<List<FeedbackReplyHistory>>();
            }
            return feedbackHistories;
        }

        public async Task<List<FeedbackReplyHistory>> GetFeedbackReplyHistoriesByFeedbackIDAsync(Guid id)
        {
            string path = "/api/FeedbackReplyHistories/"+id.ToString();
            List<FeedbackReplyHistory> feedbackHistories = new List<FeedbackReplyHistory>();
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                feedbackHistories = await response.Content.ReadAsAsync<List<FeedbackReplyHistory>>();
            }
            return feedbackHistories;
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(FeedbackReplyHistory item)
        {
            string path = "/api/FeedbackReplyHistories/" + item.ID;
            HttpResponseMessage response = await client.PutAsJsonAsync(path, item).ConfigureAwait(false);

            return await Task.FromResult(response.IsSuccessStatusCode);
        }
    }
}
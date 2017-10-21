using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;

namespace EnglishForKid.Service
{
    public class LessonDataStore : BaseDataStore, IDataStore<Lesson>
    {
        public async Task<bool> AddItemAsync(Lesson item)
        {
            String path = "/api/Lessons";
            HttpResponseMessage response = await client.PostAsJsonAsync(path, item);

            return await Task.FromResult(response.IsSuccessStatusCode);

        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            String path = "/api/Lessons" + id.ToString();
            HttpResponseMessage response = await client.DeleteAsync(path);

            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<Lesson> GetItemAsync(Guid id)
        {
            Lesson lesson = null;

            String path = "/api/Lessons/" +id.ToString();
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                lesson = await response.Content.ReadAsAsync<Lesson>();
            }
            return lesson;
        }

        public async Task<List<Lesson>> GetItemsAsync()
        {
            List<Lesson> listLesson = null;
            String path = "/api/Lessons";
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                listLesson = await response.Content.ReadAsAsync<List<Lesson>>();
            }

            return listLesson;
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
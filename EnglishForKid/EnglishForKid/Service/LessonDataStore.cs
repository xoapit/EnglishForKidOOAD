using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using EnglishForKid.Models.ViewModels;

namespace EnglishForKid.Service
{
    public class LessonDataStore : BaseDataStore
    {
        public async Task<bool> AddItemAsync(Lesson item)
        {
            String path = "/api/Lessons";
            HttpResponseMessage response = await client.PostAsJsonAsync(path, item).ConfigureAwait(false);

            return await Task.FromResult(response.IsSuccessStatusCode);

        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            String path = "/api/Lessons/" + id.ToString();
            HttpResponseMessage response = await client.DeleteAsync(path).ConfigureAwait(false);

            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<Lesson> GetItemAsync(String id)
        {
            Lesson lesson = null;

            String path = "/api/Lessons/" + id.ToString();
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                lesson = await response.Content.ReadAsAsync<Lesson>();
            }
            return lesson;
        }

        public async Task<List<Lesson>> GetItemsAsync()
        {
            List<Lesson> listLesson = new List<Lesson>();
            String path = "/api/Lessons";
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                listLesson = await response.Content.ReadAsAsync<List<Lesson>>();
            }

            return listLesson;
        }

        public async Task<List<BaseLessonInfoViewModel>> GetBaseLessonInfoViewModelsByCategoryNameAsync(string categoryName, int start = 0, int take = 10)
        {
            List<BaseLessonInfoViewModel> listLesson = new List<BaseLessonInfoViewModel>();
            String path = "/api/Lessons?categoryName=" + categoryName + "&start=" + start + "&take=" + take;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                listLesson = await response.Content.ReadAsAsync<List<BaseLessonInfoViewModel>>();
            }

            return listLesson;
        }

        public async Task<int> GetNumberOfLessonsByCategoryNameAsync(string categoryName)
        {
            int numberOfLessons = 0;
            String path = "/api/Lessons/numberOfLessons?categoryName=" + categoryName;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                numberOfLessons = Int32.Parse(await response.Content.ReadAsStringAsync());
            }
            return numberOfLessons;
        }

        public async Task<List<BaseLessonInfoViewModel>> GetBaseLessonInfoViewModelsAsync(int limit)
        {
            List<BaseLessonInfoViewModel> listLesson = new List<BaseLessonInfoViewModel>();
            String path = "/api/Lessons?limit=" + limit;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                listLesson = await response.Content.ReadAsAsync<List<BaseLessonInfoViewModel>>();
            }
            return listLesson;
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(Lesson lesson)
        {
            string path = "/api/Lessons/" + lesson.ID;
            HttpResponseMessage response = await client.PutAsJsonAsync(path, lesson).ConfigureAwait(false);
            return await Task.FromResult(response.IsSuccessStatusCode);
        }

    }
}
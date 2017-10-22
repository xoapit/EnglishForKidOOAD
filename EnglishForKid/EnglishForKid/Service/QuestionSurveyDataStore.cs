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
    public class QuestionSurveyDataStore : BaseDataStore, IDataStore<QuestionSurvey>
    {
        public async Task<bool> AddItemAsync(QuestionSurvey item)
        {
            string path = "/api/questionsurveys";
            HttpResponseMessage response = await client.PostAsJsonAsync(path, item).ConfigureAwait(false);

            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            string path = "/api/questionsurveys/" + id.ToString();
            HttpResponseMessage response = await client.DeleteAsync(path).ConfigureAwait(false);

            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<QuestionSurvey> GetItemAsync(Guid id)
        {
            string path = "/api/questionsurveys/" + id.ToString();
            QuestionSurvey questionSurvey = null;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                questionSurvey = await response.Content.ReadAsAsync<QuestionSurvey>();
            }
            return questionSurvey;
        }

        public async Task<List<QuestionSurvey>> GetItemsAsync()
        {
            string path = "/api/questionsurveys";
            List<QuestionSurvey> questionSurveys = new List<QuestionSurvey>();
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                questionSurveys = await response.Content.ReadAsAsync<List<QuestionSurvey>>();
            }
            return questionSurveys;
        }

        public async Task<List<BaseQuestionSurveyViewModel>> GetBaseQuestionSurveysAsync()
        {
            string path = "/api/QuestionSurveys/base";
            List<BaseQuestionSurveyViewModel> baseQuestionSurveys = new List<BaseQuestionSurveyViewModel>();
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                baseQuestionSurveys = await response.Content.ReadAsAsync<List<BaseQuestionSurveyViewModel>>();
            }
            return baseQuestionSurveys;
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(QuestionSurvey item)
        {
            string path = "/api/questionsurveys/" + item.ID;
            HttpResponseMessage response = await client.PutAsJsonAsync(path, item).ConfigureAwait(false);

            return await Task.FromResult(response.IsSuccessStatusCode);
        }
    }
}
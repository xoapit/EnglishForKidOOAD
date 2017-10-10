using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace EnglishForKid.Service
{
    public class QuestionSurveyDataStore : BaseDataStore, IDataStore<QuestionSurvey>
    {
        public Task<bool> AddItemAsync(QuestionSurvey item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionSurvey> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<QuestionSurvey>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(QuestionSurvey item)
        {
            throw new NotImplementedException();
        }
    }
}
using EnglishForKid.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using EnglishForKid.Models.ViewModels;

namespace EnglishForKid.Service
{
    public class StatisticDataStore : BaseDataStore, IDataStore<StatisticViewModel>
    {
        public Task<bool> AddItemAsync(StatisticViewModel item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<StatisticViewModel> GetStatisticAsync() {
            string path = "api/statistics";
            StatisticViewModel statisticViewModel = null;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode) {
                statisticViewModel = await response.Content.ReadAsAsync<StatisticViewModel>();
            }
            return statisticViewModel;

        }

        public async Task<ChartStatisticViewModel> GetChartStatisticAsync(int days)
        {
            string path = "api/statistics?days="+days;
            ChartStatisticViewModel statisticViewModel = null;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                statisticViewModel = await response.Content.ReadAsAsync<ChartStatisticViewModel>();
            }
            return statisticViewModel;

        }

        public Task<StatisticViewModel> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StatisticViewModel>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(StatisticViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}
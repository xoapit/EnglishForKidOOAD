using EnglishForKid.Models.Error;
using EnglishForKid.Models.ViewModel;
using EnglishForKid.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace EnglishForKid.Service
{
    public class AccountDataStore: BaseDataStore
    {
        public async Task<LoginResult> Login(LoginViewModel loginViewModel)
        {
            string path = "/oauth/token";
            LoginResult loginResult = null;
            ErrorDescription errorDescription = null;
            HttpResponseMessage response = await client.PostAsJsonAsync(path, loginViewModel).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                loginResult = await response.Content.ReadAsAsync<LoginResult>();
            }
            else
            {
                errorDescription = await response.Content.ReadAsAsync<ErrorDescription>();
                return errorDescription;
            }
            return loginResult;
        }

        public async Task<UserReturnModel> GetAccountByUserNameAsync(string username)
        {
            string path = "/api/accounts?username=" + username;
            UserReturnModel userReturnModel = null;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                userReturnModel = await response.Content.ReadAsAsync<UserReturnModel>();
            }
            return userReturnModel;
        }
    }
}
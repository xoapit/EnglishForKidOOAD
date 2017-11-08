using EnglishForKid.Models.Error;
using EnglishForKid.Models.ViewModel;
using EnglishForKid.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace EnglishForKid.Service
{
    public class AccountDataStore : BaseDataStore
    {
        public async Task<LoginResult> Login(LoginViewModel loginViewModel)
        {
            string path = "oauth/token";
            LoginResult loginResult = null;
            ErrorDescription errorDescription = null;

            var body = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("UserName", loginViewModel.UserName),
                new KeyValuePair<string, string>("Password", loginViewModel.Password),
                new KeyValuePair<string, string>("grant_type", loginViewModel.grant_type)
            };

            HttpContent content = new FormUrlEncodedContent(body);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            HttpClient client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000,
                BaseAddress = new Uri(baseApiUrl),
                Timeout = TimeSpan.FromMilliseconds(4000)
            };

            HttpResponseMessage response = await client.PostAsync(path, content).ConfigureAwait(false);

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

        public async Task<bool> ResetPasswordAsync(ResetPasswordViewModel item)
        {
            string path = "/api/accounts/ResetPassword";
            HttpResponseMessage response = await client.PostAsJsonAsync(path, item).ConfigureAwait(false);
            return await Task.FromResult(response.IsSuccessStatusCode);
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

        public async Task<bool> UsernameAlreadyExistAsync(string username)
        {
            string path = "/api/accounts/UsernameAlreadyExists?username=" + username;
            HttpResponseMessage response = await client.PostAsJsonAsync(path, true).ConfigureAwait(false);
            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<bool> EmailAlreadyExistAsync(string email)
        {
            string path = "/api/accounts/EmailAlreadyExists?email=" + email;
            HttpResponseMessage response = await client.PostAsJsonAsync(path, true).ConfigureAwait(false);
            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<bool> AddItemAsync(CreateUserBindingModel item)
        {
            string path = "/api/accounts/register";
            HttpResponseMessage response = await client.PostAsJsonAsync(path, item).ConfigureAwait(false);
            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<bool> UpdateRoleAsync(RoleViewModel item)
        {
            string path = "/api/accounts/UpdateRole";
            HttpResponseMessage response = await client.PostAsJsonAsync(path, item).ConfigureAwait(false);
            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<UserReturnModel> GetAccountByIDAsync(string id)
        {
            string path = "/api/accounts/" + id.ToString();
            UserReturnModel userReturnModel = null;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                userReturnModel = await response.Content.ReadAsAsync<UserReturnModel>();
            }
            return userReturnModel;
        }

        public async Task<List<UserReturnModel>> GetAccountsByRoleNameAsync(string roleName)
        {
            string path = "/api/accounts?rolename=" + roleName;
            List<UserReturnModel> userReturnModels = new List<UserReturnModel>();
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                userReturnModels = await response.Content.ReadAsAsync<List<UserReturnModel>>();
            }
            return userReturnModels;
        }

        public async Task<bool> UpdateAccountAsync(UserReturnModel userReturnModel)
        {
            string path = "/api/accounts/" + userReturnModel.Id;
            HttpResponseMessage response = await client.PutAsJsonAsync(path, userReturnModel).ConfigureAwait(false);

            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<bool> LockAccountAsync(string id, bool status)
        {
            string path = "/api/accounts/" + id + "?status=" + status;
            HttpResponseMessage response = await client.PutAsJsonAsync(path, true).ConfigureAwait(false);

            return await Task.FromResult(response.IsSuccessStatusCode);
        }
    }
}
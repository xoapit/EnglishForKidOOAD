using APIEnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace APIEnglishForKid.Controllers
{
    public class ValuesController : ApiController
    {
        //// GET api/values
        //public async Task<Account> GetAsync()
        //{
        //    return await GetProductAsync("");
        //}

        //// GET api/values/5
        //public Account Get(int id)
        //{
        //    Account acount = new Account()
        //    {
        //        ApiAuthenication = Guid.NewGuid().ToString(),
        //        Password = "123456",
        //        ID = Guid.NewGuid(),
        //        Profile = new Profile()
        //        {
        //            Avatar = "my.avatar.png",
        //            FullName="Quy Ho"
        //        }
        //    };
        //    return acount;
        //}

        //static async Task<Account> GetProductAsync(string path)
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:50959/Api/values/1");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    Account product = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        product = await response.Content.ReadAsAsync<Account>();
        //    }
        //    return product;
        //}

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

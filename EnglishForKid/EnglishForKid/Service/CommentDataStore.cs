using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;

namespace EnglishForKid.Service
{
    public class CommentDataStore : BaseDataStore, IDataStore<Comment>
    {
        public async Task<bool> AddItemAsync(Comment item)
        {
            String path = "/api/Comments";
            HttpResponseMessage response = await client.PostAsJsonAsync(path, item);
            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async  Task<bool> DeleteItemAsync(Guid id)
        {
            String path = "/api/Comments" + id.ToString();
            HttpResponseMessage response = await client.DeleteAsync(path).ConfigureAwait(false);

            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<Comment> GetItemAsync(Guid id)
        {
            Comment comment = null;
            String path = "/api/Comments" + id.ToString();
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
             if (response.IsSuccessStatusCode)
            {
                comment = await response.Content.ReadAsAsync<Comment>();
            }

            return comment;
        }

        public async Task<List<Comment>> GetItemsAsync()
        {
            List<Comment> listComment = null;
            String path = "/api/Comments";
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                listComment = await response.Content.ReadAsAsync<List<Comment>>();
            }


            return listComment;
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Comment item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetCommentsAcyncByLessonIdAsync(Guid id)
        {
            List<Comment> ListCommentOfLesson = null;
            String path = "/api/comments/Lesson" + id.ToString();
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                ListCommentOfLesson = await response.Content.ReadAsAsync<List<Comment>>();
            }

            return ListCommentOfLesson;
        }
    }
}
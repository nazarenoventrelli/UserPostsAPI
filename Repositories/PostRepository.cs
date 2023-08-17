using UserPostsAPI.Clients;
using UserPostsAPI.Entities;
using System.Text.Json;
using System.Text;

namespace UserPostsAPI.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IHttpClient _httpClient;
        private const string PostsEndpoint = "/posts";
        private const string CommentsEndpoint = "/comments?postId=";

        public PostRepository(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {

            HttpResponseMessage response = await _httpClient.Get(PostsEndpoint);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                IEnumerable<Post> posts = JsonSerializer.Deserialize<IEnumerable<Post>>(content);

                return posts;
            }

            return new List<Post>();
        }

        public async Task<IEnumerable<Comment>> GetCommentsByPostId(int postId)
        {
            string fullEndpoint = CommentsEndpoint + postId;

            HttpResponseMessage response = await _httpClient.Get(fullEndpoint);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                IEnumerable<Comment> comments = JsonSerializer.Deserialize<IEnumerable<Comment>>(content);

                return comments;
            }

            return new List<Comment>();
        }

        public async Task<bool> DeletePost(int postId)
        {

            string fullEndpoint = PostsEndpoint + postId;

            HttpResponseMessage response = await _httpClient.Delete(fullEndpoint);

            var result = response.IsSuccessStatusCode;


            return result;
        }

        public Task DeleteCommentByPostId(int postId)
        {
            // to implement


            return Task.CompletedTask;
        }

        public Task AddCommentToPost(int postId, Comment comment)
        {
            // to implement


            return Task.CompletedTask;
        }
    }
}

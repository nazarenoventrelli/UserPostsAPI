using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace UserPostsAPI.Clients
{
    public class HttpClient : IHttpClient
    {
        private System.Net.Http.HttpClient _client;

        public HttpClient()
        {
            _client = new System.Net.Http.HttpClient();
        }

        public async Task<HttpResponseMessage> Post(HttpContent httpContent, string url = "")
        {
            var response = await _client.PostAsync(url, httpContent);

            return response;
        }
    }
}

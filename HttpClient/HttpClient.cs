using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using UserPostsAPI.Configuration;

namespace UserPostsAPI.Clients
{
    public class HttpClient : IHttpClient
    {
        private readonly System.Net.Http.HttpClient _client;
        private readonly string _baseUrl;

        public HttpClient(IOptions<ApiSettings> apiSettings)
        {
            _baseUrl = apiSettings.Value.BaseUrl;
            _client = new System.Net.Http.HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };
        }

        public async Task<HttpResponseMessage> Get(string endpoint = "")
        {
            var response = await _client.GetAsync(_baseUrl + endpoint);

            return response;
        }

        public async Task<HttpResponseMessage> Post(HttpContent httpContent, string endpoint = "")
        {
            var response = await _client.PostAsync(_baseUrl + endpoint, httpContent);

            return response;
        }

        public async Task<HttpResponseMessage> Delete(string endpoint = "")
        {
            var response = await _client.DeleteAsync(_baseUrl + endpoint);

            return response;
        }

    }
}

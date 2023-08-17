using System.Net.Http;
using System.Threading.Tasks;

namespace UserPostsAPI.Clients
{
    public interface IHttpClient
    {
        public Task<HttpResponseMessage> Post(HttpContent httpContent, string endpoint = "");
        public Task<HttpResponseMessage> Get(string endpoint = "");
        public Task<HttpResponseMessage> Delete(string endpoint = "");
    }
}
    
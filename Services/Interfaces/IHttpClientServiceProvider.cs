using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Test.API.Services
{
    public interface IHttpClientServiceProvider
    {
        Task<string> Get(string requestUri, Dictionary<string, string> headers);
        HttpResponseMessage Post(string requestUri, Dictionary<string, string> requestPayload, Dictionary<string, string> headers);
    }
}
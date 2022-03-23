using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Test.API.Services
{
    public class HttpClientServiceProvider : IHttpClientServiceProvider
    {       
        private readonly IHttpClientFactory _clientFactory;
        public HttpClientServiceProvider(IHttpClientFactory clientFactory)
        {            
            _clientFactory = clientFactory;
        }

        public async Task<string> Get(string requestUri, Dictionary<string, string> headers)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, requestUri))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (headers != null && headers.Count != 0)              
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                } 
                
                var client = _clientFactory.CreateClient();
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {                   
                    string content = await response.Content.ReadAsStringAsync();                   
                    return content;
                }

                return null;
            }
        }       

        public HttpResponseMessage Post(string requestUri, Dictionary<string, string> requestPayload, Dictionary<string, string> headers)
        {
            throw new NotImplementedException();           
        }
    }
}

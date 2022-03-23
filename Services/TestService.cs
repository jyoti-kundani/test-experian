using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Test.API.Models;

namespace Test.API.Services
{
    public class TestService : ITestService
    {
        private readonly IHttpClientServiceProvider _httpServiceProvider;

        public TestService(IHttpClientServiceProvider httpServiceProvider)
        {
            _httpServiceProvider = httpServiceProvider;
        }

        public async Task<IEnumerable<Album>> GetAlbums()
        {
            const string requestUri_albums = "http://jsonplaceholder.typicode.com/albums";

            var responseString = await _httpServiceProvider.Get(requestUri_albums, headers: null);

            if (responseString != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                IEnumerable<Album> albums = JsonSerializer.Deserialize<IEnumerable<Album>>(responseString, options);
                return albums;
            }
            return null;
        }

        public async Task<IEnumerable<Photo>> GetPhotos()
        {
            const string requestUri_photos = "http://jsonplaceholder.typicode.com/photos";

            var responseString = await _httpServiceProvider.Get(requestUri_photos, headers: null);

            if (responseString != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                IEnumerable<Photo> photos = JsonSerializer.Deserialize<IEnumerable<Photo>>(responseString, options);
                return photos;
            }
            return null;
        }
    }
}

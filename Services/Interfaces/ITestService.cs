using System.Collections.Generic;
using System.Threading.Tasks;
using Test.API.Models;

namespace Test.API.Services
{
    public interface ITestService
    {
        Task<IEnumerable<Album>> GetAlbums();
        Task<IEnumerable<Photo>> GetPhotos();
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Test.API.DTOs;
using Test.API.Services;

namespace Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;        

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        /// <summary>
        /// This method returns combined collection so that each Album contains a collection of its Photos
        /// </summary>
        /// <returns></returns>
        [HttpGet("getData")]
        public async Task<ActionResult> GetData()
        {           
            //Get Albums using service
            var albums = await _testService.GetAlbums();

            //Get Photos using service
            var photos = await _testService.GetPhotos();
           
            var result = from album in albums
                         select new ResponseDTO
                         {
                             Id = album.Id,
                             Title = album.Title,
                             UserId = album.UserId,
                             Photos = photos.Where(x => x.AlbumId == album.Id).ToList()
                         };

            return Ok(result);
        }

        [HttpGet("getDataByUserId/{userId}")]
        public async Task<ActionResult> GetDataByUserId(int userId)
        {
            //Get Albums using service
            var albums = await _testService.GetAlbums();

            //Get Photos using service
            var photos = await _testService.GetPhotos();
          
            var result = from album in albums.Where(x => x.UserId == userId)
                         select new ResponseDTO
                         {
                             Id = album.Id,
                             Title = album.Title,
                             UserId = album.UserId,
                             Photos = photos.Where(x => x.AlbumId == album.Id).ToList()
                         };                        

            return Ok(result);
        }
    }
}

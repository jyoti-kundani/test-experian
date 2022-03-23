using System.Collections.Generic;
using Test.API.Models;

namespace Test.API.DTOs
{
    public class ResponseDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public List<Photo> Photos { get; set; }
    }
}

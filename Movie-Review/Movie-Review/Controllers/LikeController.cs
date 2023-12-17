using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie_Review.Data;
using Movie_Review.Data.Dtos;
using Movie_Review.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movie_Review.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private UserContext _context;
        private IMapper _mapper;

        public LikeController(UserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // POST api/<LikeController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateLikeDto dto)
        {
            Like like = _mapper.Map<Like>(dto);
            _context.Likes.Add(like);
            _context.SaveChanges();
            return Ok("Like Registrado");
        }

        // DELETE api/<LikeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

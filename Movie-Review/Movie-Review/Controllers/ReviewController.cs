using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie_Review.Data;
using Movie_Review.Data.Dtos;
using Movie_Review.Models;
using System.Collections;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movie_Review.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private UserContext _context;
        private IMapper _mapper;

        public ReviewController(UserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // POST api/<ReviewController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateReviewDto _review)
        {
            Review review = _mapper.Map<Review>(_review);
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return Ok("Review Registrada");
        }

        // DELETE api/<ReviewController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

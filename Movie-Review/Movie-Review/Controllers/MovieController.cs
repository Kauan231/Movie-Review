using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Movie_Review.Data;
using Movie_Review.Models;
using Movie_Review.Services;
using System;
using Movie_Review.Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movie_Review.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private UserContext _context;
        private IMapper _mapper;

        public MovieController(UserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet("search")]
        //[Authorize]
        // GET /Movie/search?Title=
        public async Task<ActionResult<SearchResult>> GetByName([FromQuery] [Required(ErrorMessage = "O Titulo é obrigatorio")] string Title)
        {
            SearchResult MoviesFound = await MovieService.RequestMovieByName(_context, Title);     

            if(MoviesFound.Search.Length == 0)
            {
                return NotFound("Filme não encontrado");
            } 
            return Ok(MoviesFound);                         
        }

        // GET /Movie/:id/reviews
        [HttpGet("{id}/reviews")]
        public ActionResult<List<ReadReviewDto>> GetMovieReviews([Required(ErrorMessage = "O Id é obrigatorio")] string id)
        {
            var response = _context.Reviews.Skip(0).Take(5).Where(review => review.Movies.Reviews.Any(movie => movie.imdbID == id)).ToList();

            var toRead = _mapper.Map<List<ReadReviewDto>>(response);

            toRead.ForEach(review =>
            {
                var getLikes = _context.Likes.Skip(0).Take(5).Where(x => x.ReviewId == review.Id);
                review.LikeCount = getLikes.Count(x => x.isLike == true);
                review.DislikeCount = getLikes.Count(x => x.isLike == false);
            });


            return Ok(toRead);
        }

        // GET /Movie/:id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([Required(ErrorMessage = "O Id é obrigatorio")] string id)
        {
            Movie movie = await MovieService.RequestMovieById(_context, id);

            if (movie.Equals(null))
            {
                return NotFound("Filme com ID Solicitado não encontrado");
            }

            return Ok(movie);
        }

        [HttpGet("AddMovie")]
        // TEST
        public async Task<ActionResult<Movie>> AddByName([FromQuery][Required(ErrorMessage = "O Titulo é obrigatorio")] string Title)
        {
            Movie MovieAdded = await MovieService.AddByName(_context, Title);
            return Ok(MovieAdded);
        }


    }
}

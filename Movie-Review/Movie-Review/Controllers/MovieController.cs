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


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movie_Review.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public MovieController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: /<MovieController>
        [HttpGet]
        public async Task<Movie> GetByName([FromQuery] string Title)
        {
            Movie movie = new Movie();
            if (Title != null)
            {
                movie =  await MovieService.RequestMovieByName(_context, Title);
            }
            return movie;
            //return await MovieApi.RequestMovieByName("John+Wick"); ;
        }

        // GET: /<MovieController>
        [HttpGet("/teste/")]
        public async Task<Movie> GetById([FromQuery] string Id)
        {
            Movie movie = new Movie();
            if (Id != null)
            {
                movie = await MovieService.RequestMovieById(_context, Id);
            }

            return movie;
            //return await MovieApi.RequestMovieByName("John+Wick"); ;
        }

        // GET /<MovieController>/5
        [HttpGet("{id}")]
        public IActionResult GetMoviesById(string id)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.imdbID == id);
            if (movie != null)
            {
                ReadMovieDto movieDto = _mapper.Map<ReadMovieDto>(movie);
                return Ok(movieDto);
            }
            return NotFound();
        }

        // POST /<MovieController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateMovieDto movieDto)
        {
            Movie _movie = _mapper.Map<Movie>(movieDto);
            _context.Movies.Add(_movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMoviesById), new { Id = _movie.Id }, movieDto);
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

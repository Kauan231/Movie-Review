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

        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Movie>> GetByName([FromQuery] string Title)
        {
            Movie movie = new Movie();
            if (Title != null)
            {
                try
                {
                    movie = await MovieService.RequestMovieByName(_context, Title);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }     
            }

            if(movie.Title != null)
            {
                return movie;
            }

            return NotFound("Filme não encontrado");   
        }


        // GET /Movie/:id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            Movie movie = new Movie();
            if (id != null)
            {
                movie = await MovieService.RequestMovieById(_context, id);
                return Ok(movie);
            }

            return NotFound();
        }


    }
}

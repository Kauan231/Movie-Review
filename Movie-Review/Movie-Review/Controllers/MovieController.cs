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
        private MovieContext _context;
        private IMapper _mapper;

        public MovieController(MovieContext context, IMapper mapper)
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


    }
}

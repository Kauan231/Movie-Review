using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Review.Data;
using Movie_Review.Models;

//SearchResult (Deprecated)
/*
if (movie.Title == null)
{
    movie = await MovieApi.RequestMovieByName(Movie_Name);
    //_context.Movies.Add(movie);
    //_context.SaveChanges();
}
*/

namespace Movie_Review.Services
{
    public class MovieService
    {
        public static async Task<SearchResult> RequestMovieByName(UserContext _context, string Movie_Name)
        {
            SearchResult Movies = MovieSql.RequestMovieByName(_context, Movie_Name);

            if(Movies.Search.Length == 0)
            {
                Movies = await MovieApi.RequestMovieByName(Movie_Name);
            }

            return Movies;
        }

        public static async Task<Movie> RequestMovieById(UserContext _context, string IMDb_ID)
        {
            Movie movie = MovieSql.RequestMovieById(_context, IMDb_ID);

            if (movie.Equals(null))
            {
                movie = await MovieApi.RequestMovieById(IMDb_ID);
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }

            return movie;
        }

        //TEST
        public static async Task<Movie> AddByName(UserContext _context, string Title)
        {
            Movie movie = await MovieApi.AddMovieByName(Title);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return movie;
        }
    }
}

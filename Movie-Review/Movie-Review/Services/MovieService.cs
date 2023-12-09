using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie_Review.Data;
using Movie_Review.Models;

namespace Movie_Review.Services
{
    public class MovieService
    {
        public static async Task<Movie> RequestMovieByName(MovieContext _context, string Movie_Name)
        {
            Movie movie = MovieSql.RequestMovieByName(_context, Movie_Name);

            if(movie == null)
            {
                movie = await MovieApi.RequestMovieByName(Movie_Name);
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }

            return movie;
        }

        public static async Task<Movie> RequestMovieById(MovieContext _context, string IMDb_ID)
        {
            Movie movie = MovieSql.RequestMovieById(_context, IMDb_ID);

            if (movie == null)
            {
                movie = await MovieApi.RequestMovieById(IMDb_ID);
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }

            return movie;
        }
    }
}

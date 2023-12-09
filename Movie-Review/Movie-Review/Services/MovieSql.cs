using Movie_Review.Data;
using Movie_Review.Models;

namespace Movie_Review.Services
{
    public class MovieSql
    {
        public static Movie RequestMovieByName(MovieContext _context, string Movie_Name)
        {
            Movie movie = _context.Movies.FirstOrDefault(_movie => _movie.Title == Movie_Name);
            Console.WriteLine("Found: ");
            Console.WriteLine(movie);
            return movie;
        }

        public static Movie RequestMovieById(MovieContext _context, string IMDb_ID)
        {
            Movie movie = _context.Movies.FirstOrDefault(_movie => _movie.imdbID == IMDb_ID);
            return movie;
        }
    }
}

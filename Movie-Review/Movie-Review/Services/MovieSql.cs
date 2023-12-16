using Movie_Review.Data;
using Movie_Review.Models;

namespace Movie_Review.Services
{
    public class MovieSql
    {
        public static SearchResult RequestMovieByName(MovieContext _context, string Movie_Name)
        {
            Movie[] movies = _context.Movies.Where(p => p.Title.StartsWith(Movie_Name)).ToArray<Movie>();
            SearchResult searchResult = new SearchResult(movies);
            return searchResult;
        }

        public static Movie RequestMovieById(MovieContext _context, string IMDb_ID)
        {
            Movie movie = _context.Movies.FirstOrDefault(_movie => _movie.imdbID == IMDb_ID);
            return movie;
        }
    }
}

namespace Movie_Review.Models
{
    public class SearchResult
    {
        public Movie[] Search { get; set; }

        public SearchResult(Movie[] search)
        {
            Search = search;
        }
    }
}

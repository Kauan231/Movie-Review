using System.Net.Http;
using Movie_Review.Models;
using Newtonsoft.Json;

namespace Movie_Review.Services
{
    public class MovieApi
    {
        private static readonly HttpClient client = new HttpClient();

        private static SearchResult JsonDeserializeList(string serializedContent)
        {
            SearchResult DeserializedMovie = JsonConvert.DeserializeObject<SearchResult>(serializedContent);
            return DeserializedMovie;
        }

        private static Movie JsonDeserializeItem(string serializedContent)
        {
            Movie DeserializedMovie = JsonConvert.DeserializeObject<Movie>(serializedContent);
            return DeserializedMovie;
        }

        public static async Task<SearchResult> RequestMovieByName(string Movie_Name)
        {
            //var response = await client.GetAsync("http://localhost:3000/"); // MOCK
            //var response = await client.GetAsync("https://www.omdbapi.com/?apikey=e60a475c&t=" + Movie_Name); // ( DEPRECATED )
            var response = await client.GetAsync("https://www.omdbapi.com/?apikey=e60a475c&s=" + Movie_Name);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonDeserializeList(responseString);
        }

        public static async Task<Movie> RequestMovieById(string IMDb_ID)
        {
            var response = await client.GetAsync("https://www.omdbapi.com/?apikey=e60a475c&i=" + IMDb_ID);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonDeserializeItem(responseString);
        }

        // TEST
        public static async Task<Movie> AddMovieByName(string Movie_Name)
        {
            var response = await client.GetAsync("https://www.omdbapi.com/?apikey=e60a475c&t=" + Movie_Name); // ( DEPRECATED )
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonDeserializeItem(responseString);
        }
    }
}

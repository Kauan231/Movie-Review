using System.Text.Json;
using System.Net.Http;
using Movie_Review.Models;

namespace Movie_Review.Services
{
    public class MovieApi
    {
        private static readonly HttpClient client = new HttpClient();

        private static Movie JsonDeserialize(string serializedContent)
        {
            Movie DeserializedMovie = JsonSerializer.Deserialize<Movie>(serializedContent);
            return DeserializedMovie;
        }

        public static async Task<Movie> RequestMovieByName(string Movie_Name)
        {
            //var response = await client.GetAsync("http://localhost:3000/"); // MOCK

            var response = await client.GetAsync("https://www.omdbapi.com/?apikey=e60a475c&t=" + Movie_Name);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonDeserialize(responseString);
        }

        public static async Task<Movie> RequestMovieById(string IMDb_ID)
        {
            var response = await client.GetAsync("https://www.omdbapi.com/?apikey=e60a475c&i=" + IMDb_ID);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonDeserialize(responseString);
        }
    }
}

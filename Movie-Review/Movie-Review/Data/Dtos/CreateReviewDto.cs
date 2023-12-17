using System.ComponentModel.DataAnnotations;

namespace Movie_Review.Data.Dtos
{
    public class CreateReviewDto
    {
        [Required]
        public string UserId { get; set; }
        public string imdbID { get; set; }
        public string Comment { get; set;}
        public float Rating { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Movie_Review.Data.Dtos
{
    public class CreateLikeDto
    {
        [Required]
        public string UserId { get; set; }
        public int ReviewId { get; set; }
        public bool isLike { get; set;}
    }
}

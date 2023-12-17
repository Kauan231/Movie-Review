using System.ComponentModel.DataAnnotations;

namespace Movie_Review.Models
{
    public class Like
    {
        [Key]
        [Required]
        public int Id { get; set; } 
        public bool isLike { get; set; }
        public int? ReviewId { get; set; }
        public virtual Review Review { get; set; }
        public string? UserId { get; set; }
        public virtual User User { get; set; }
    }
}

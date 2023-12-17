using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Review.Models
{
    public class Review
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? imdbID { get; set; }
        public virtual Movie Movies { get; set; }
        public string? UserId { get; set; }
        public virtual User User { get; set; }
        public string Comment { get; set; }
        public float Rating { get; set; }
        public virtual ICollection<Like> Likes { get; set; }    
    }
}

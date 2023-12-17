using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Review.Models
{
    [NotMapped]
    public class Rating
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using Movie_Review.Models;

namespace Movie_Review.Data.Dtos
{
    public class ReadLikeDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string imdbID { get; set; }
        public string Comment { get; set;}
        public float Rating { get; set; }
        public int? LikeCount { get; set; }
        public int? DislikeCount { get; set; }
        public bool? isLike { get; set; }
    }
}

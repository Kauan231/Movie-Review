using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Review.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<Like>? Likes { get; set; }
        public User() : base() { }
    }
}

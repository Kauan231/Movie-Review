using System.ComponentModel.DataAnnotations;

namespace Movie_Review.Data.Dtos
{
    public class RemoveUserDto
    {
        [Required]
        public string UserIdentityId { get; set; }

    }
}

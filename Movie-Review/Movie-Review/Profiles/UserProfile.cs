using AutoMapper;
using Movie_Review.Data.Dtos;
using Movie_Review.Models;

namespace Movie_Review.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
        }
    }
}

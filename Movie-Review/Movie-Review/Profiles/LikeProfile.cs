using AutoMapper;
using Movie_Review.Data.Dtos;
using Movie_Review.Models;

namespace Movie_Like.Profiles
{
    public class LikeProfile : Profile
    {
        public LikeProfile() {
            CreateMap<CreateLikeDto, Like>();
            CreateMap<ReadLikeDto, Like>();
            CreateMap<Like, ReadLikeDto>();
            CreateMap<Review, ReadLikeDto>();
        }  
       
    }
}

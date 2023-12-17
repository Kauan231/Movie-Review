using AutoMapper;
using Movie_Review.Data.Dtos;
using Movie_Review.Models;

namespace Movie_Review.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile() {
            CreateMap<CreateReviewDto, Review>();
            CreateMap<Review, ReadReviewDto >();
            CreateMap<ReadReviewDto, Review>();
        }  
    }
}

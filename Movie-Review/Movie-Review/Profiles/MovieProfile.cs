using AutoMapper;
using Movie_Review.Data.Dtos;
using Movie_Review.Models;

namespace Movie_Review.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<ReadMovieDto, Movie>();
            CreateMap<Movie, ReadMovieDto>();
        }
    }
}

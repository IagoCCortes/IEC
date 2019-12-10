using System.Linq;
using AutoMapper;
using IEC.API.Dtos;
using IEC.API.Core.Domain;

namespace IEC.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() {
            CreateMap<MovieForCreationDto, Movie>()
            .ForSourceMember(m => m.GenreIds, opt => opt.DoNotValidate());

            CreateMap<Movie, MovieToReturnDto>()
            .ForMember(m => m.Genres, 
                       opt => opt.MapFrom(ps => ps.MovieMovieGenres
                                 .Select(mg => mg.MovieGenre.Genre)));
                                 
            CreateMap<MovieForUpdateDto, Movie>();
        }
    }
}
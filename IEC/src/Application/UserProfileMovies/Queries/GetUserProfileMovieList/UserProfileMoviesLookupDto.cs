using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.UserProfileMovies.Queries.GetUserProfileMovieList
{
    public class UserProfileMovieLookupDto : IMapFrom<UserProfileMovie>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public string Status { get; set; }
        public int Rating { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserProfileMovie, UserProfileMovieLookupDto>()
                .ForMember(u => u.Id, opt => opt.MapFrom(u => u.MovieId))
                .ForMember(u => u.Title, opt => opt.MapFrom(u => u.Movie.Name))
                .ForMember(u => u.PosterUrl, opt => opt.MapFrom(u => u.Movie.ImageUrl))
                .ForMember(u => u.Status, opt => opt.MapFrom(u => u.UserProfileMovieStatusId))
                .ForMember(u => u.Rating, opt => opt.MapFrom(u => u.Rating));
        }
    }
}
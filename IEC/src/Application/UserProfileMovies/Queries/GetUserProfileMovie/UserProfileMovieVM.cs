using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.UserProfileMovies.Queries.GetUserProfileMovie
{
    public class UserProfileMovieVM : IMapFrom<UserProfileMovie>
    {
        public string UserProfileMovieStatusId { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public bool Favorited { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserProfileMovie, UserProfileMovieVM>();
        }
    }
}
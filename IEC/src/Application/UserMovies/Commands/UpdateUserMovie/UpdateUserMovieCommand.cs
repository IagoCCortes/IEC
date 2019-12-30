using Domain.Enums;
using MediatR;

namespace Application.UserMovies.Commands.UpdateUserMovie
{
    public class UpdateUserMovieCommand : IRequest
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string Review { get; set; }  
        public int? Rating { get; set; }
        public bool Favorited { get; set; }
        public int UserMovieStatusId { get; set; }
    }
}
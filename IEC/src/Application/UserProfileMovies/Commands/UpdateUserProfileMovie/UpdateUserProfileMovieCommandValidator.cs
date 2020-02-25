using System.Linq;
using Domain.Enums;
using FluentValidation;

namespace Application.UserProfileMovies.Commands.UpdateUserProfileMovie
{
    public class UpdateUserProfileMovieCommandValidator : AbstractValidator<UpdateUserProfileMovieCommand>
    {
        public UpdateUserProfileMovieCommandValidator()
        {
            var validUserMovieStatusIds = new[] {(int)UserProfileMovieStatusEnum.ToWatch, (int)UserProfileMovieStatusEnum.Watching, 
                                                 (int)UserProfileMovieStatusEnum.Watched, (int)UserProfileMovieStatusEnum.Dropped};
            RuleFor(u => u.UserProfileMovieStatusId).Must(u => validUserMovieStatusIds.Contains(u))
                .WithMessage("Choose a valid status value");
            RuleFor(u => u.UserProfileMovieStatusId).Equal((int)UserProfileMovieStatusEnum.Watched).When(u => u.Review != null || u.Rating != null)
                .WithMessage("You can only rate or review the movie if you already watched it");
            RuleFor(u => u.Rating).InclusiveBetween(0, 100)
                .WithMessage("Rating must be between 0 and 100");
        }
    }
}
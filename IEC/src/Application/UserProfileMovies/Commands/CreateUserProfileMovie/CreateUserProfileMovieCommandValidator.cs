using System.Linq;
using Domain.Enums;
using FluentValidation;

namespace Application.UserProfileMovies.Commands.CreateUserProfileMovie
{
    public class CreateUserProfileMovieCommandValidator : AbstractValidator<CreateUserProfileMovieCommand>
    {
        public CreateUserProfileMovieCommandValidator()
        {
            var validUserProfileMovieStatusIds = new[] {(int)UserProfileMovieStatusEnum.ToWatch, (int)UserProfileMovieStatusEnum.Watching, 
                                                 (int)UserProfileMovieStatusEnum.Watched, (int)UserProfileMovieStatusEnum.Dropped};
            RuleFor(u => u.UserProfileMovieStatusId).Must(u => validUserProfileMovieStatusIds.Contains(u))
                .WithMessage("Choose a valid status value");
        }
    }
}
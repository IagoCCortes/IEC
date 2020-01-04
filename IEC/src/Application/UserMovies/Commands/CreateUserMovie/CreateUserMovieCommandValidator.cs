using System.Linq;
using Domain.Enums;
using FluentValidation;

namespace Application.UserMovies.Commands.CreateUserMovie
{
    public class CreateUserMovieCommandValidator : AbstractValidator<CreateUserMovieCommand>
    {
        public CreateUserMovieCommandValidator()
        {
            var validUserMovieStatusIds = new[] {(int)UserMovieStatusEnum.ToWatch, (int)UserMovieStatusEnum.Watching, 
                                                 (int)UserMovieStatusEnum.Watched, (int)UserMovieStatusEnum.Dropped};
            RuleFor(u => u.UserMovieStatusId).Must(u => validUserMovieStatusIds.Contains(u))
                .WithMessage("Choose a valid status value");
        }
    }
}
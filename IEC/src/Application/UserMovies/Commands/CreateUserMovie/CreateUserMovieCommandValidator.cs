using FluentValidation;

namespace Application.UserMovies.Commands.CreateUserMovie
{
    public class CreateUserMovieCommandValidator : AbstractValidator<CreateUserMovieCommand>
    {
        public CreateUserMovieCommandValidator()
        {
            RuleFor(um => um.MovieId).NotEmpty().WithMessage("Required Field.");
            RuleFor(um => um.UserMovieStatusId).NotEmpty().WithMessage("Required Field.");
        }
    }
}
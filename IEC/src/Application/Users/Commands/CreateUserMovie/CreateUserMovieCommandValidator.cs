using FluentValidation;

namespace Application.Users.Commands.CreateUserMovie
{
    public class CreateUserMovieCommandValidator : AbstractValidator<CreateUserMovieCommand>
    {
        public CreateUserMovieCommandValidator()
        {
            RuleFor(um => um.UserId).NotEmpty().WithMessage("Required Field.");
            RuleFor(um => um.MovieId).NotEmpty().WithMessage("Required Field.");
        }
    }
}
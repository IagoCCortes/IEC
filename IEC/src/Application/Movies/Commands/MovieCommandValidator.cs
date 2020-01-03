using FluentValidation;

namespace Application.Movies.Commands
{
    public class MovieCommandValidator : AbstractValidator<MovieCommand>
    {
        public MovieCommandValidator()
        {
            RuleFor(m => m.Title).NotEmpty().WithMessage("Required Field.");
        }
    }
}
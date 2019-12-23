using FluentValidation;
using MediatR;

namespace Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandsValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandsValidator()
        {
            RuleFor(m => m.Title).NotEmpty().WithMessage("Required Field.");
            RuleFor(m => m.Plot).NotEmpty().WithMessage("Required Field.");
            RuleFor(m => m.Runtime).NotEmpty().WithMessage("Required Field.");
            RuleFor(m => m.ReleaseDate).NotEmpty().WithMessage("Required Field.");
        }
    }
}
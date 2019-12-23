using FluentValidation;

namespace Application.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(m => m.Title).NotEmpty().WithMessage("Required Field.");
            RuleFor(m => m.Plot).NotEmpty().WithMessage("Required Field.");
            RuleFor(m => m.Runtime).NotEmpty().WithMessage("Required Field.");
            RuleFor(m => m.ReleaseDate).NotEmpty().WithMessage("Required Field.");
        }
    }
}
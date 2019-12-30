using System.Linq;
using FluentValidation;

namespace Application.UserMovies.Commands.UpdateUserMovie
{
    public class UpdateUserMovieCommandValidator : AbstractValidator<UpdateUserMovieCommand>
    {
        public UpdateUserMovieCommandValidator()
        {
            RuleFor(u => u.UserMovieStatusId).NotEmpty().WithMessage("Required Field.")
            .Must(u => (new[] {1, 2, 3, 4}).Contains(u)).WithMessage("Choose a valid status value");
            RuleFor(u => u.Rating).InclusiveBetween(0, 100).WithMessage("Rating must be between 0 and 100");
        }
    }
}
using System.Linq;
using Domain.Enums;
using FluentValidation;

namespace Application.UserMovies.Commands.UpdateUserMovie
{
    public class UpdateUserMovieCommandValidator : AbstractValidator<UpdateUserMovieCommand>
    {
        public UpdateUserMovieCommandValidator()
        {
            var validUserMovieStatusIds = new[] {(int)UserMovieStatusEnum.ToWatch, (int)UserMovieStatusEnum.Watching, 
                                                 (int)UserMovieStatusEnum.Watched, (int)UserMovieStatusEnum.Dropped};
            RuleFor(u => u.UserMovieStatusId).Must(u => validUserMovieStatusIds.Contains(u))
                .WithMessage("Choose a valid status value");
            RuleFor(u => u.UserMovieStatusId).Equal((int)UserMovieStatusEnum.Watched).When(u => u.Review != null || u.Rating != null)
                .WithMessage("You can only rate or review the movie if you already watched it");
            RuleFor(u => u.Rating).InclusiveBetween(0, 100)
                .WithMessage("Rating must be between 0 and 100");
        }
    }
}
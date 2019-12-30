using FluentValidation;

namespace Application.UserMovies.Commands.DeleteUserMovie
{
    public class DeleteUserMovieCommandValidator : AbstractValidator<DeleteUserMovieCommand>
    {
        public DeleteUserMovieCommandValidator()
        {
            RuleFor(um => um.UserId).NotEmpty().WithMessage("Required Field.");
            RuleFor(um => um.MovieId).NotEmpty().WithMessage("Required Field.");
        }
    }
}
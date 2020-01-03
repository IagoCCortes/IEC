using FluentValidation;

namespace Application.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            Include(new MovieCommandValidator());
        }
    }
}
using FluentValidation;

namespace Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandsValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandsValidator()
        {
            Include(new MovieCommandValidator());
        }
    }
}
using FluentValidation;

namespace Application.Artists.Commands
{
    public class ArtistCommandValidator : AbstractValidator<ArtistCommand>
    {
        public ArtistCommandValidator()
        {
            RuleFor(a => a.ArtistName).NotEmpty().WithMessage("Required Field.");
        }
    }
}
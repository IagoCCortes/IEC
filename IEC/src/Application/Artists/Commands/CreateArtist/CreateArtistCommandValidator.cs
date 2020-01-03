using System;
using FluentValidation;

namespace Application.Artists.Commands.CreateArtist
{
    public class CreateArtistCommandValidator : AbstractValidator<CreateArtistCommand>
    {
        public CreateArtistCommandValidator()
        {
            RuleFor(a => a.ArtistName).NotEmpty().WithMessage("Required Field.");
        }
    }
}
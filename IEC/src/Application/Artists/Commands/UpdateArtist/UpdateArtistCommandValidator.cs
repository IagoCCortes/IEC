using System;
using FluentValidation;

namespace Application.Artists.Commands.UpdateArtist
{
    public class UpdateArtistCommandValidator : AbstractValidator<UpdateArtistCommand>
    {
        public UpdateArtistCommandValidator()
        {
            RuleFor(a => a.ArtistName).NotEmpty().WithMessage("Required Field.");
        }
    }
}
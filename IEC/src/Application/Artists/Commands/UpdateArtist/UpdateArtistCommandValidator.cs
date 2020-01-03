using System;
using FluentValidation;

namespace Application.Artists.Commands.UpdateArtist
{
    public class UpdateArtistCommandValidator : AbstractValidator<UpdateArtistCommand>
    {
        public UpdateArtistCommandValidator()
        {
            Include(new ArtistCommandValidator());
        }
    }
}
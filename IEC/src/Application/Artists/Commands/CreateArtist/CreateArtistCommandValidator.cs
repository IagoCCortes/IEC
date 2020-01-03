using System;
using FluentValidation;

namespace Application.Artists.Commands.CreateArtist
{
    public class CreateArtistCommandValidator : AbstractValidator<CreateArtistCommand>
    {
        public CreateArtistCommandValidator()
        {
            Include(new ArtistCommandValidator());
        }
    }
}
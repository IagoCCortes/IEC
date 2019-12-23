using System;
using FluentValidation;

namespace Application.Artists.Commands.CreateArtist
{
    public class CreateArtistCommandValidator : AbstractValidator<CreateArtistCommand>
    {
        public CreateArtistCommandValidator()
        {
            RuleFor(a => a.ArtistName).NotEmpty().WithMessage("Required Field.").MaximumLength(100).WithMessage("Artist name should be at most 100 characters.");
            RuleFor(a => a.Birthdate).Must((a, r) => a.Birthdate is DateTime?).WithMessage("Birthdate must be a valid date.");
        }
    }
}
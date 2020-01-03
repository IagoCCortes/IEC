using System;
using Domain.Enums;
using FluentValidation;

namespace Application.MovieArtists.Commands.CreateMovieArtist
{
    public class CreateMovieArtistCommandValidator : AbstractValidator<CreateMovieArtistCommand>
    {
        public CreateMovieArtistCommandValidator()
        {
            // RuleFor(ma => ma.MovieId).NotEmpty().WithMessage("Required Field.");
            RuleFor(ma => ma.ArtistIds).NotEmpty().WithMessage("Required Field.");
            RuleFor(ma => ma.RoleIds).NotEmpty().WithMessage("Required Field.")
            .Must((cma, m) => m.Count == cma.ArtistIds.Count).WithMessage("Every artist must have a role and vice versa.")
            .Must(mr => { 
                    foreach (var role in mr){
                        if(!Enum.IsDefined(typeof(MovieRoleEnum), role))
                            return false;
                    } 
                    return true;
                }).WithMessage("You must select a valid role.");
        }
    }
}
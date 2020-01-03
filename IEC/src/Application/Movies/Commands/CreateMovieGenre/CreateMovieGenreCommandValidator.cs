using System;
using Domain.Enums;
using FluentValidation;

namespace Application.Movies.Commands.CreateMovieGenre
{
    public class CreateMovieGenreCommandValidator : AbstractValidator<CreateMovieGenreCommand>
    {
        public CreateMovieGenreCommandValidator()
        {
            // RuleFor(ma => ma.MovieId).NotEmpty().WithMessage("Required Field.");
            RuleFor(ma => ma.GenreIds).NotEmpty().WithMessage("Required Field.")
            .Must(g => { 
                    foreach (var genre in g){
                        if(!Enum.IsDefined(typeof(MovieGenreEnum), genre))
                            return false;
                    } 
                    return true;
                }).WithMessage("You must select a valid genre.");
        }
    }
}
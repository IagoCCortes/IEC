using System.Collections.Generic;
using Application.MovieArtists.Commands;
using FluentValidation.TestHelper;
using Xunit;

namespace Application.UnitTests.MovieArtists.Commands
{
    public class MovieArtistCommandValidatorTests
    {
        private MovieArtistCommandValidator validator;

        public MovieArtistCommandValidatorTests() {
            validator = new MovieArtistCommandValidator();
        }

        [Fact]
        public void Should_have_error_when_ArtistIds_or_RoleIds_is_empty() {
            var MovieArtist = new MovieArtistCommand{MovieId = 1, ArtistIds = new List<int>(), RoleIds = new List<int>()};
            validator.ShouldHaveValidationErrorFor(ma => ma.ArtistIds, MovieArtist); 
            validator.ShouldHaveValidationErrorFor(ma => ma.RoleIds, MovieArtist); 
        }

        [Fact]
        public void Should_have_error_when_ArtistIds_and_RoleIds_are_of_different_sizes() {
            var MovieArtist = new MovieArtistCommand{MovieId = 1, ArtistIds = new List<int>{1, 2}, RoleIds = new List<int>{1}};
            validator.ShouldHaveValidationErrorFor(ma => ma.RoleIds, MovieArtist); 
        }

        [Fact]
        public void Should_have_error_when_RoleIds_contains_invalid_genreId() {
            var MovieArtist = new MovieArtistCommand{MovieId = 1, ArtistIds = new List<int>{1, 2}, RoleIds = new List<int>{1,99}};
            validator.ShouldHaveValidationErrorFor(ma => ma.RoleIds, MovieArtist); 
        }
        
        [Fact]
        public void Should_not_have_error_when_ArtistIds_and_RoleIds_are_not_empty_and_of_same_size() {
            var MovieArtist = new MovieArtistCommand{MovieId = 1, ArtistIds = new List<int>{1, 2}, RoleIds = new List<int>{1,2}};
            validator.ShouldNotHaveValidationErrorFor(ma => ma.ArtistIds, MovieArtist);
        }
    }
}
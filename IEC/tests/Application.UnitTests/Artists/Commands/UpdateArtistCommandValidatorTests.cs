using System;
using Application.Artists.Commands.UpdateArtist;
using FluentValidation.TestHelper;
using Xunit;

namespace Application.UnitTests.Artists.Commands
{
    public class UpdateArtistCommandValidatorTests
    {
        private UpdateArtistCommandValidator validator;

        public UpdateArtistCommandValidatorTests() {
            validator = new UpdateArtistCommandValidator();
        }

        [Fact]
        public void Should_have_error_when_Name_is_null() {
            validator.ShouldHaveValidationErrorFor(ca => ca.ArtistName, null as string); 
        }
        
        [Fact]
        public void Should_not_have_error_when_name_is_specified() {
            validator.ShouldNotHaveValidationErrorFor(ca => ca.ArtistName, "Jeremy");
        }
    }
}
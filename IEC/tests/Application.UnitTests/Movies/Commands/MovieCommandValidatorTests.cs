using Application.Movies.Commands;
using FluentValidation.TestHelper;
using Xunit;

namespace Application.UnitTests.Movies.Commands
{
    public class MovieCommandValidatorTests
    {
        private MovieCommandValidator validator;

        public MovieCommandValidatorTests() {
            validator = new MovieCommandValidator();
        }

        [Fact]
        public void Should_have_error_when_Title_is_null() {
            validator.ShouldHaveValidationErrorFor(m => m.Title, null as string); 
        }

        [Fact]
        public void Should_succeed_when_Title_is_not_null() {
            validator.ShouldNotHaveValidationErrorFor(m => m.Title, "300"); 
        }
    }
}
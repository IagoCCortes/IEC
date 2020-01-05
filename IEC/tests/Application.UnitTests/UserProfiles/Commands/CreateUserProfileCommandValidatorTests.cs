using Application.UserProfiles.Commands.CreateUserProfile;
using FluentValidation.TestHelper;
using Xunit;

namespace Application.UnitTests.UserProfiles.Commands
{
    public class CreateUserCommandValidatorTests
    {
        private CreateUserProfileCommandValidator validator;

        public CreateUserCommandValidatorTests() {
            validator = new CreateUserProfileCommandValidator();
        }

        [Fact]
        public void Should_have_error_when_Email_is_null() {
            validator.ShouldHaveValidationErrorFor(u => u.Email, null as string); 
        }

        [Fact]
        public void Should_have_error_when_Email_is_invalid() {
            validator.ShouldHaveValidationErrorFor(u => u.Email, "test"); 
        }

        [Fact]
        public void Should_succeed_when_Email_is_valid() {
            validator.ShouldNotHaveValidationErrorFor(u => u.Email, "test@test.com"); 
        }
    }
}
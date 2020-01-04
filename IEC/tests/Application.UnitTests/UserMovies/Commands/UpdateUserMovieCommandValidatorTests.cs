using Application.UserMovies.Commands.UpdateUserMovie;
using Domain.Enums;
using FluentValidation.TestHelper;
using Xunit;

namespace Application.UnitTests.UserMovies.Commands
{
    public class UpdateUserMovieCommandValidatorTests
    {
        private UpdateUserMovieCommandValidator validator;

        public UpdateUserMovieCommandValidatorTests() {
            validator = new UpdateUserMovieCommandValidator();
        }

        [Fact]
        public void Should_have_error_when_UserMovieStatusId_is_invalid() {
            var invalidUserMovieStatusId = 5;
            validator.ShouldHaveValidationErrorFor(u => u.UserMovieStatusId, invalidUserMovieStatusId); 
        }

        [Fact]
        public void Should_succeed_when_UserMovieStatusId_is_valid() {
            validator.ShouldNotHaveValidationErrorFor(u => u.UserMovieStatusId, (int)UserMovieStatusEnum.Watched); 
        }

        [Fact]
        public void Should_have_error_when_UserMovieStatusId_is_not_Watched_and_user_tries_to_rate_movie() {
            var updateUserMovieCommand = new UpdateUserMovieCommand {MovieId = 2, UserId = 2, UserMovieStatusId = (int)UserMovieStatusEnum.ToWatch, Rating = 77};
            validator.ShouldHaveValidationErrorFor(u => u.UserMovieStatusId, updateUserMovieCommand); 
        }

        [Fact]
        public void Should_have_error_when_UserMovieStatusId_is_not_Watched_and_user_tries_to_review_movie() {
            var updateUserMovieCommand = new UpdateUserMovieCommand {MovieId = 2, UserId = 2, UserMovieStatusId = (int)UserMovieStatusEnum.ToWatch, Review = "bad"};
            validator.ShouldHaveValidationErrorFor(u => u.UserMovieStatusId, updateUserMovieCommand); 
        }

        [Fact]
        public void Should_pass_when_UserMovieStatusId_is_Watched_and_user_reviews_and_rates_movie() {
            var updateUserMovieCommand = new UpdateUserMovieCommand {MovieId = 2, UserId = 2, UserMovieStatusId = (int)UserMovieStatusEnum.ToWatch, Review = "cool", Rating = 88};
            validator.ShouldHaveValidationErrorFor(u => u.UserMovieStatusId, updateUserMovieCommand); 
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        public void Should_fail_when_user_tries_to_rate_invalid_values(int invalidValue) {
            validator.ShouldHaveValidationErrorFor(u => u.Rating, invalidValue); 
        }
        
        [Fact]
        public void Should_pass_when_user_tries_to_rate_valid_value() {
            var validValue = 50;
            validator.ShouldNotHaveValidationErrorFor(u => u.Rating, validValue); 
        }
    }
}
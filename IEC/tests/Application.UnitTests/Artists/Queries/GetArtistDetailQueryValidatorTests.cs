using Application.Artists.Queries.GetArtistDetail;
using FluentValidation.TestHelper;
using Xunit;

namespace Application.UnitTests.Artists.Queries
{
    public class GetArtistDetailQueryValidatorTests
    {
        private GetArtistDetailQueryValidator validator;

        public GetArtistDetailQueryValidatorTests() {
            validator = new GetArtistDetailQueryValidator();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_have_error_when_Id_is_not_greater_than_zero(int testValue) {
            validator.ShouldHaveValidationErrorFor(a => a.Id, testValue); 
        }
        
        [Fact]
        public void Should_not_have_error_when_Id_is_greater_than_zero() {
            validator.ShouldNotHaveValidationErrorFor(a => a.Id, 1);
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.UserProfileMovies.Commands.DeleteUserProfileMovie;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Application.UnitTests.UserProfileMovies.Commands
{
    public class DeleteUserMovieCommandTests : CommandTestBase
    {
        private readonly DeleteUserProfileMovieCommandHandler _sut;

        public DeleteUserMovieCommandTests()
            : base()
        {       
            _sut = new DeleteUserProfileMovieCommandHandler(Context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldDeleteUserMovie()
        {
            // Arrange
            var command = new DeleteUserProfileMovieCommand { MovieId = 2, UserProfileId = 2};

            // Act
            await _sut.Handle(command, CancellationToken.None);
            var userMovie = await Context.UserProfileMovies.FirstOrDefaultAsync(um => um.MovieId == 2 && um.UserProfileId == 2);

            // Assert
            Assert.Null(userMovie);
        }

        [Fact]
        public async Task Handle_GivenInvalidRequest_ThrowsNotFoundException()
        {
            // Arrange
            var command = new DeleteUserProfileMovieCommand { MovieId = 99, UserProfileId = 1};

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));            
        }
    }
}
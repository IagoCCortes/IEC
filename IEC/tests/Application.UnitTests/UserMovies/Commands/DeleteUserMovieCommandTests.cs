using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.UnitTests.Common;
using Application.UserMovies.Commands.DeleteUserMovie;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace Application.UnitTests.UserMovies.Commands
{
    public class DeleteUserMovieCommandTests : CommandTestBase
    {
        private readonly DeleteUserMovieCommandHandler _sut;

        public DeleteUserMovieCommandTests()
            : base()
        {       
            _sut = new DeleteUserMovieCommandHandler(Context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldDeleteUserMovie()
        {
            // Arrange
            var command = new DeleteUserMovieCommand { MovieId = 2, UserId = 2};

            // Act
            await _sut.Handle(command, CancellationToken.None);
            var userMovie = await Context.UserMovies.FirstOrDefaultAsync(um => um.MovieId == 2 && um.UserId == 2);

            // Assert
            Assert.Null(userMovie);
        }

        [Fact]
        public async Task Handle_GivenInvalidRequest_ThrowsNotFoundException()
        {
            // Arrange
            var command = new DeleteUserMovieCommand { MovieId = 99, UserId = 1};

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));            
        }
    }
}
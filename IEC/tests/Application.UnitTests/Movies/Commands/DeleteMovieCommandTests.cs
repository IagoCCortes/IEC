using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Movies.Commands.DeleteMovie;
using Application.UnitTests.Common;
using Xunit;

namespace Application.UnitTests.Movies.Commands
{
    public class DeleteMovieCommandTests : CommandTestBase
    {
        private readonly DeleteMovieCommandHandler _sut;

        public DeleteMovieCommandTests()
            : base()
        {
            _sut = new DeleteMovieCommandHandler(Context);
        }

        [Fact]
        public async Task Handle_GivenValidId_ShouldDeleteMovie()
        {
            // Arrange
            var validId = 1;
            var command = new DeleteMovieCommand { Id = validId };

            // Act
            await _sut.Handle(command, CancellationToken.None);
            var result = await Context.Movies.FindAsync(validId);

            // // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Handle_GivenInvalidId_ThrowsNotFoundException()
        {
            // Arrange
            var InvalidId = 99;
            var command = new DeleteMovieCommand { Id = InvalidId };

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_GivenValidIdAndHasArtists_ThrowsDeleteFailureException()
        {
            var validId = 2;

            var command = new DeleteMovieCommand { Id = validId };

            await Assert.ThrowsAsync<DeleteFailureException>(() => _sut.Handle(command, CancellationToken.None));
        }
    }
}
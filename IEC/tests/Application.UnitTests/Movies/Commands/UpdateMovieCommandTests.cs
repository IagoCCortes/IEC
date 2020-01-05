using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Movies.Commands.UpdateMovie;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Movies.Commands
{
    public class UpdateMovieCommandTests : CommandTestBase
    {
        private readonly UpdateMovieCommandHandler _sut;

        public UpdateMovieCommandTests()
            : base()
        {            
            _sut = new UpdateMovieCommandHandler(Context, Mapper);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldUpdateMovie()
        {
            // Arrange
            var command = new UpdateMovieCommand { Id = 1, Title = "test" };

            // Act
            await _sut.Handle(command, CancellationToken.None);
            var movie = await Context.Movies.FindAsync(command.Id);

            // Assert
            movie.Title.ShouldBe(command.Title);
        }

        [Fact]
        public async Task Handle_GivenInvalidId_ThrowsNotFoundException()
        {
            // Arrange
            var command = new UpdateMovieCommand { Id = 99, Title = "test" };

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));            
        }
    }
}
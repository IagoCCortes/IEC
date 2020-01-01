using System.Threading;
using System.Threading.Tasks;
using Application.Artists.Commands.UpdateArtist;
using Application.Common.Exceptions;
using Application.UnitTests.Common;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Artists.Commands.UpdateArtist
{
    public class UpdateArtistCommandTests : CommandTestBase
    {
        private readonly UpdateArtistCommandHandler _sut;

        public UpdateArtistCommandTests()
            : base()
        {            
            _sut = new UpdateArtistCommandHandler(Context, Mapper);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldUpdateArtistAsync()
        {
            // Arrange
            var command = new UpdateArtistCommand { Id = 1, ArtistName = "test" };

            // Act
            await _sut.Handle(command, CancellationToken.None);
            var artist = await Context.Artists.FindAsync(command.Id);

            // Assert
            artist.ArtistName.ShouldBe(command.ArtistName);
        }

        [Fact]
        public async Task Handle_GivenInvalidId_ThrowsNotFoundException()
        {
            // Arrange
            var command = new UpdateArtistCommand { Id = 99, ArtistName = "test" };

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));            
        }
    }
}
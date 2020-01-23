using System.Threading;
using System.Threading.Tasks;
using Application.Artists.Commands.CreateArtist;
using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Artists.Commands
{
    public class CreateArtistCommandTest : CommandTestBase
    {
        private readonly CreateArtistCommandHandler _sut;
        private readonly Mock<IMediator> _mediatorMock;

        public CreateArtistCommandTest()
            : base()
        {
            _mediatorMock = new Mock<IMediator>();
            _sut = new CreateArtistCommandHandler(Context, _mediatorMock.Object, Mapper);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldCreateArtist()
        {
            // Arrange
            var command = new CreateArtistCommand { ArtistName = "test" };

            // Act
            var artist = await _sut.Handle(command, CancellationToken.None);
            var result = await Context.Artists.FindAsync(artist.Id);

            // Assert
            result.Name.ShouldBe(command.ArtistName);
        }

        [Fact]
        public void Handle_GivenValidRequest_ShouldRaiseCustomerCreatedNotification()
        {
            // Arrange
            var command = new CreateArtistCommand { ArtistName = "test" };

            // Act
            var result = _sut.Handle(command, CancellationToken.None);

            // Assert
            _mediatorMock.Verify(m => m.Publish(It.Is<ArtistCreated>(ac => ac.Id != 0), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
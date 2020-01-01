using System.Threading;
using System.Threading.Tasks;
using Application.Artists.Commands.DeleteArtist;
using Application.Common.Exceptions;
using Application.UnitTests.Common;
using Xunit;

namespace Application.UnitTests.Artists.Commands.DeleteArtist
{
    public class DeleteArtistCommandTests : CommandTestBase
    {
        private readonly DeleteArtistCommandHandler _sut;

        public DeleteArtistCommandTests()
            : base()
        {
            _sut = new DeleteArtistCommandHandler(Context);
        }

        [Fact]
        public async Task Handle_GivenValidId_DeletesArtist()
        {
            var validId = 1;

            var command = new DeleteArtistCommand { Id = validId };

            await _sut.Handle(command, CancellationToken.None);

            var customer = await Context.Artists.FindAsync(validId);

            Assert.Null(customer);
        }

        [Fact]
        public async Task Handle_GivenInvalidId_ThrowsNotFoundException()
        {
            var invalidId = 99;

            var command = new DeleteArtistCommand { Id = invalidId };

            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));
        }
    }
}
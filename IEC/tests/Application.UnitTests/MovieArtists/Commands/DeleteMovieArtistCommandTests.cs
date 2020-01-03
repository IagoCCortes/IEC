using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.MovieArtists.Commands.DeleteMovieArtist;
using Application.UnitTests.Common;
using Xunit;

namespace Application.UnitTests.MovieArtists.Commands
{
    public class DeleteMovieArtistCommandTests : CommandTestBase
    {
        private readonly DeleteMovieArtistCommandHandler _sut;

        public DeleteMovieArtistCommandTests()
            : base()
        {            
            _sut = new DeleteMovieArtistCommandHandler(Context);
        }

        [Fact]
        public async Task Handle_GivenValidIds_ShouldDeleteMovieArtists()
        {
            // Arrange
            var MovieValidId = 2;
            var ArtistValidId = new List<int> {1};
            var RoleValidId = new List<int> {1};
            var command = new DeleteMovieArtistCommand { MovieId = MovieValidId, ArtistIds = ArtistValidId, RoleIds = RoleValidId};

            // Act
            await _sut.Handle(command, CancellationToken.None);
            var result = await Context.MovieArtists.FindAsync(2, 1, 1);

            // // Assert
            Assert.Null(result);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Handle_GivenInvalidRequest_ThrowsNotFoundException(int movieId, List<int> artistIds, List<int> roleIds)
        {
            // Arrange
            var command = new DeleteMovieArtistCommand { MovieId = movieId, ArtistIds = artistIds, RoleIds = roleIds };

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));            
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 99, new List<int> {1}, new List<int> {1} },
            new object[] { 1, new List<int> { 1, 2 },  new List<int> { 1, 2 } },
        };
    }
}
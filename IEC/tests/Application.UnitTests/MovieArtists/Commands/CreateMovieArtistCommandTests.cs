using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.MovieArtists.Commands.CreateMovieArtist;
using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Application.UnitTests.MovieArtists.Commands
{
    public class CreateMovieArtistCommandTests : CommandTestBase
    {
        private readonly CreateMovieArtistCommandHandler _sut;

        public CreateMovieArtistCommandTests()
            : base()
        {            
            _sut = new CreateMovieArtistCommandHandler(Context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldCreateMovieArtists()
        {
            // Arrange
            var command = new CreateMovieArtistCommand { MovieId = 1, ArtistIds = new List<int> {1, 2}, RoleIds = new List<int> {1, 2} };

            // Act
            await _sut.Handle(command, CancellationToken.None);
            var movieArtist = await Context.MovieArtists.Where(ma => ma.MovieId == 1).ToListAsync();

            // Assert
            Assert.Equal(2, movieArtist.Count);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Handle_GivenInvalidRequest_ThrowsNotFoundException(int movieId, List<int> artistIds, List<int> roleIds)
        {
            // Arrange
            var command = new CreateMovieArtistCommand { MovieId = movieId, ArtistIds = artistIds, RoleIds = roleIds };

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));            
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 99, new List<int> {2}, new List<int> {2} },
            new object[] { 1, new List<int> { 99, 2 },  new List<int> { 1, 2 } },
        };
    }
}
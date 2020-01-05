using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Movies.Commands.CreateMovieGenre;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Application.UnitTests.Movies.Commands
{
    public class CreateMovieGenreCommandTests : CommandTestBase
    {
        private readonly CreateMovieGenreCommandHandler _sut;

        public CreateMovieGenreCommandTests()
            : base()
        {
            _sut = new CreateMovieGenreCommandHandler(Context);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Handle_GivenValidRequest_ShouldCreateMovieMovieGenre(int movieId, List<int> genreIds, int expected)
        {
            // Arrange
            var command = new CreateMovieGenreCommand { MovieId = movieId, GenreIds = genreIds };

            // Act
            await _sut.Handle(command, CancellationToken.None);
            var result = await Context.MovieMovieGenres.Where(g => g.MovieId == movieId).ToListAsync();

            // // Assert
            Assert.Equal(expected, result.Count);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 1, new List<int> {3}, 1},
            new object[] { 1, new List<int> { 1, 2 }, 2},
        };
    }
}
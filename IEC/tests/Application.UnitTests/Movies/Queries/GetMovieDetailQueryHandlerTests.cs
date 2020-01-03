using System.Threading;
using System.Threading.Tasks;
using Application.Movies.Queries.GetMovieDetail;
using Application.Common.Exceptions;
using Application.UnitTests.Common;
using AutoMapper;
using Persistence;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Movies.Queries
{

    [Collection("QueryCollection")]
    public class GetMovieDetailQueryHandlerTests
    {
        private readonly IECDbContext _context;
        private readonly IMapper _mapper;
        private readonly GetMovieDetailQueryHandler _sut;

        public GetMovieDetailQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _sut = new GetMovieDetailQueryHandler(_context, _mapper);
        }

        [Fact]
        public async Task GetMovieDetail_ValidId_ReturnsMovieDetails()
        {
            var result = await _sut.Handle(new GetMovieDetailQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<MovieDetailVM>();
            result.Title.ShouldBe("Gone Girl");
        }

        [Fact]
        public async Task GetMovieDetail_InvalidId_ThrowsNotFoundException()
        {
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(new GetMovieDetailQuery { Id = 99 }, CancellationToken.None));
        }
    }
}
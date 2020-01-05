using System.Threading;
using System.Threading.Tasks;
using Application.Movies.Queries.GetMovieList;
using AutoMapper;
using Infrastructure.Persistence;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Movies.Queries
{
    [Collection("QueryCollection")]
    public class GetMovieListQueryHandlerTests
    {
        private readonly IECDbContext _context;
        private readonly IMapper _mapper;
        private readonly GetMovieListQueryHandler _sut;

        public GetMovieListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _sut = new GetMovieListQueryHandler(_context, _mapper);
        }

        [Fact]
        public async Task GetMovieList_ValidId_ReturnsMovieDetails()
        {
            var result = await _sut.Handle(new GetMovieListQuery(), CancellationToken.None);

            result.ShouldBeOfType<MovieListVM>();
            result.Movies.Count.ShouldBe(3);
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using Application.Artists.Queries.GetArtistList;
using Application.UnitTests.Common;
using AutoMapper;
using Persistence;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Artists.Queries
{
    [Collection("QueryCollection")]
    public class GetArtistListQueryHandlerTests
    {
        private readonly IECDbContext _context;
        private readonly IMapper _mapper;
        private readonly GetArtistListQueryHandler _sut;

        public GetArtistListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _sut = new GetArtistListQueryHandler(_context, _mapper);
        }

        [Fact]
        public async Task GetArtistList_ValidId_ReturnsArtistDetails()
        {
            var result = await _sut.Handle(new GetArtistListQuery(), CancellationToken.None);

            result.ShouldBeOfType<ArtistListVM>();
            result.Artists.Count.ShouldBe(3);
        }
    }
}
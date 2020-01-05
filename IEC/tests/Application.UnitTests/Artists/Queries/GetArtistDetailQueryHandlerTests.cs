using System.Threading;
using System.Threading.Tasks;
using Application.Artists.Queries.GetArtistDetail;
using Application.Common.Exceptions;
using AutoMapper;
using Infrastructure.Persistence;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Artists.Queries
{

    [Collection("QueryCollection")]
    public class GetArtistDetailQueryHandlerTests
    {
        private readonly IECDbContext _context;
        private readonly IMapper _mapper;
        private readonly GetArtistDetailQueryHandler _sut;

        public GetArtistDetailQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _sut = new GetArtistDetailQueryHandler(_context, _mapper);
        }

        [Fact]
        public async Task GetArtistDetail_ValidId_ReturnsArtistDetails()
        {
            var result = await _sut.Handle(new GetArtistDetailQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<ArtistDetailVM>();
            result.ArtistName.ShouldBe("Tim Robbins");
        }

        [Fact]
        public async Task GetArtistDetail_InvalidId_ThrowsNotFoundException()
        {
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(new GetArtistDetailQuery { Id = 99 }, CancellationToken.None));
        }
    }
}
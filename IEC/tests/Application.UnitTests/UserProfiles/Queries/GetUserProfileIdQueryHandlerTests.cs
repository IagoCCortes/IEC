using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.UserProfiles.Queries.GetUserProfileId;
using AutoMapper;
using Infrastructure.Persistence;
using Shouldly;
using Xunit;

namespace Application.UnitTests.UserProfiles.Queries
{
    [Collection("QueryCollection")]
    public class GetUserIdQueryHandlerTests
    {
        private readonly IECDbContext _context;
        private readonly IMapper _mapper;
        private readonly GetUserProfileIdQueryHandler _sut;

        public GetUserIdQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _sut = new GetUserProfileIdQueryHandler(_context, _mapper);
        }

        [Fact]
        public async Task GetUserId_ValidId_ReturnsUserIds()
        {
            var result = await _sut.Handle(new GetUserProfileIdQuery { Id = "test-1" }, CancellationToken.None);

            result.ShouldBeOfType<UserProfileIdVM>();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task GetUserId_InvalidId_ThrowsNotFoundException()
        {
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(new GetUserProfileIdQuery { Id = "invalid" }, CancellationToken.None));
        }
    }
}
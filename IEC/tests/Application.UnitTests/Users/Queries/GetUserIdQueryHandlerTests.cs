using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.UnitTests.Common;
using Application.Users.Queries.GetUserId;
using AutoMapper;
using Persistence;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Users.Queries
{
    [Collection("QueryCollection")]
    public class GetUserIdQueryHandlerTests
    {
        private readonly IECDbContext _context;
        private readonly IMapper _mapper;
        private readonly GetUserIdQueryHandler _sut;

        public GetUserIdQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _sut = new GetUserIdQueryHandler(_context, _mapper);
        }

        [Fact]
        public async Task GetUserId_ValidId_ReturnsUserIds()
        {
            var result = await _sut.Handle(new GetUserIdQuery { Id = "test-1" }, CancellationToken.None);

            result.ShouldBeOfType<UserIdVM>();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task GetUserId_InvalidId_ThrowsNotFoundException()
        {
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(new GetUserIdQuery { Id = "invalid" }, CancellationToken.None));
        }
    }
}
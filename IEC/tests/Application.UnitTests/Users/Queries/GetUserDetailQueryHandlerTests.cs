using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.UnitTests.Common;
using Application.Users.Queries.GetUserDetail;
using AutoMapper;
using Persistence;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Users.Queries
{
    [Collection("QueryCollection")]
    public class GetUserDetailQueryHandlerTests
    {
        private readonly IECDbContext _context;
        private readonly IMapper _mapper;
        private readonly GetUserDetailQueryHandler _sut;

        public GetUserDetailQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _sut = new GetUserDetailQueryHandler(_context, _mapper);
        }

        [Fact]
        public async Task GetUserDetail_ValidId_ReturnsUserDetails()
        {
            var result = await _sut.Handle(new GetUserDetailQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<UserDetailVM>();
            result.UserName.ShouldBe("test1");
        }

        [Fact]
        public async Task GetUserDetail_InvalidId_ThrowsNotFoundException()
        {
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(new GetUserDetailQuery { Id = 99 }, CancellationToken.None));
        }
    }
}
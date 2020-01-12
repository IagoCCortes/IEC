using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.UserProfiles.Queries.GetUserProfileDetail;
using AutoMapper;
using Infrastructure.Persistence;
using Shouldly;
using Xunit;

namespace Application.UnitTests.UserProfiles.Queries
{
    [Collection("QueryCollection")]
    public class GetUserDetailQueryHandlerTests
    {
        private readonly IECDbContext _context;
        private readonly IMapper _mapper;
        private readonly GetUserProfileDetailQueryHandler _sut;

        public GetUserDetailQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _sut = new GetUserProfileDetailQueryHandler(_context, _mapper);
        }

        [Fact]
        public async Task GetUserDetail_ValidUserName_ReturnsUserDetails()
        {
            var result = await _sut.Handle(new GetUserProfileDetailQuery { UserName = "test1" }, CancellationToken.None);

            result.ShouldBeOfType<UserProfileDetailVM>();
            result.UserName.ShouldBe("test1");
        }

        [Fact]
        public async Task GetUserDetail_InvalidUserName_ThrowsNotFoundException()
        {
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(new GetUserProfileDetailQuery { UserName = "invalidUsername" }, CancellationToken.None));
        }
    }
}
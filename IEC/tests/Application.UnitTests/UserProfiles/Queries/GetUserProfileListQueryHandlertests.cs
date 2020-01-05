using System.Threading;
using System.Threading.Tasks;
using Application.UserProfiles.Queries.GetUserProfileList;
using AutoMapper;
using Infrastructure.Persistence;
using Shouldly;
using Xunit;

namespace Application.UnitTests.UserProfiles.Queries
{
    [Collection("QueryCollection")]
    public class GetUserListQueryHandlertests
    {
        private readonly IECDbContext _context;
        private readonly IMapper _mapper;
        private readonly GetUserProfileListQueryHandler _sut;

        public GetUserListQueryHandlertests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _sut = new GetUserProfileListQueryHandler(_context, _mapper);
        }

        [Fact]
        public async Task GetUserList_ValidId_ReturnsUserDetails()
        {
            var result = await _sut.Handle(new GetUserProfileListQuery(), CancellationToken.None);

            result.ShouldBeOfType<UserProfileListVM>();
            result.UserProfiles.Count.ShouldBe(3);
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using Application.UnitTests.Common;
using Application.Users.Queries.GetUserList;
using AutoMapper;
using Persistence;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Users.Queries
{
    [Collection("QueryCollection")]
    public class GetUserListQueryHandlertests
    {
        private readonly IECDbContext _context;
        private readonly IMapper _mapper;
        private readonly GetUserListQueryHandler _sut;

        public GetUserListQueryHandlertests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _sut = new GetUserListQueryHandler(_context, _mapper);
        }

        [Fact]
        public async Task GetUserList_ValidId_ReturnsUserDetails()
        {
            var result = await _sut.Handle(new GetUserListQuery(), CancellationToken.None);

            result.ShouldBeOfType<UserListVM>();
            result.Users.Count.ShouldBe(3);
        }
    }
}
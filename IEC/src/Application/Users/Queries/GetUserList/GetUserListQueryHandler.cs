using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListVM>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;
        public GetUserListQueryHandler(IIECDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<UserListVM> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = new UserListVM { Users = await _mapper.ProjectTo<UserLookupDto>(_context.Users)
                                       .ToListAsync(cancellationToken)};

            return users;
        }
    }
}
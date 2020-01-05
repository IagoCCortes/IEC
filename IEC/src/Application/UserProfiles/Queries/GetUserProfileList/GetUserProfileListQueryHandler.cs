using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UserProfiles.Queries.GetUserProfileList
{
    public class GetUserProfileListQueryHandler : IRequestHandler<GetUserProfileListQuery, UserProfileListVM>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;
        public GetUserProfileListQueryHandler(IIECDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<UserProfileListVM> Handle(GetUserProfileListQuery request, CancellationToken cancellationToken)
        {
            var users = new UserProfileListVM { UserProfiles = await _mapper.ProjectTo<UserProfileLookupDto>(_context.UserProfiles)
                                       .ToListAsync(cancellationToken)};

            return users;
        }
    }
}
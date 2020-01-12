using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UserProfiles.Queries.GetUserProfileDetail
{
    public class GetUserProfileDetailQueryHandler : IRequestHandler<GetUserProfileDetailQuery, UserProfileDetailVM>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;
        public GetUserProfileDetailQueryHandler(IIECDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<UserProfileDetailVM> Handle(GetUserProfileDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.UserProfiles.FirstOrDefaultAsync(u => u.UserName == request.UserName);

            if (entity == null)
                throw new NotFoundException(nameof(UserProfile), request.UserName);

            var userProfileDetail = _mapper.Map<UserProfileDetailVM>(entity);

            return userProfileDetail;
        }
    }
}
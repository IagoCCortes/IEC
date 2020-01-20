using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UserProfiles.Queries.GetUserProfileId
{
    public class GetUserProfileIdQueryHandler : IRequestHandler<GetUserProfileIdQuery, UserProfileIdVM>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;

        public GetUserProfileIdQueryHandler(IIECDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserProfileIdVM> Handle(GetUserProfileIdQuery request, CancellationToken cancellationToken)
        {
            var userProfileId = await _context.UserProfiles.FirstOrDefaultAsync(u => u.UserId == request.Id)
                ?? throw new NotFoundException(nameof(UserProfile), request.Id);

            var userProfileVm = new UserProfileIdVM { Id = userProfileId.Id };

            return userProfileVm;
        }
    }
}
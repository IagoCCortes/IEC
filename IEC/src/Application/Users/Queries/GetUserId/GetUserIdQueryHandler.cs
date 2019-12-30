using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetUserId
{
    public class GetUserIdQueryHandler : IRequestHandler<GetUserIdQuery, UserIdVM>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;

        public GetUserIdQueryHandler(IIECDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserIdVM> Handle(GetUserIdQuery request, CancellationToken cancellationToken)
        {
            var userId = await _context.Users.FirstOrDefaultAsync(u => u.UserId == request.Id);

            if (userId == null)
                throw new NotFoundException(nameof(User), request.Id);

            var userVm = new UserIdVM { Id = userId.Id };

            return userVm;
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailVM>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;
        public GetUserDetailQueryHandler(IIECDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<UserDetailVM> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(User), request.Id);

            var userDetail = _mapper.Map<UserDetailVM>(entity);

            return userDetail;
        }
    }
}
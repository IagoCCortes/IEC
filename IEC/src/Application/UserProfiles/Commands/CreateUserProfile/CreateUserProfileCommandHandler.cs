using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UserProfiles.Commands.CreateUserProfile
{
    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, CreateUserProfileReturnDto>
    {
        private readonly IIECDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateUserProfileCommandHandler(IIECDbContext context, IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
        }
        public async Task<CreateUserProfileReturnDto> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserProfile>(request);

            _context.UserProfiles.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new UserProfileCreated { Id = user.Id, Email = request.Email }, cancellationToken);

            return _mapper.Map<CreateUserProfileReturnDto>(user);
        }
    }
}
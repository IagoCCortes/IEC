using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserReturnDto>
    {
        private readonly IIECDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IIECDbContext context, IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
        }
        public async Task<CreateUserReturnDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new UserCreated { Id = user.Id, Email = request.Email }, cancellationToken);

            return _mapper.Map<CreateUserReturnDto>(user);
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IIECDbContext _context;
        private readonly IMediator _mediator;
        public CreateUserCommandHandler(IIECDbContext context, IMediator mediator)
        {
            _mediator = mediator;
            _context = context;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { UserId = request.UserId };
            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new UserCreated { Id = user.UserId, Email = request.Email }, cancellationToken);

            return Unit.Value;
        }
    }
}
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string UserId { get; set; }
        public string Email { get; set; }
    }
}
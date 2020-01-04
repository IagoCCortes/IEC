using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserReturnDto>, IMapTo<User>
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserCommand, User>();
        }
    }
}
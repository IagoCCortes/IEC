using AutoMapper;
using Domain.Entities;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandMapping : Profile
    {
        public CreateUserCommandMapping()
        {
            CreateMap<User, CreateUserReturnDto>();
        }
    }
}
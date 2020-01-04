using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserReturnDto : IMapFrom<User>
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, CreateUserReturnDto>();
        }
    }
}
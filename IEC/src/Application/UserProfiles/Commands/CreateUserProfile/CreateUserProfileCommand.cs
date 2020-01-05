using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UserProfiles.Commands.CreateUserProfile
{
    public class CreateUserProfileCommand : IRequest<CreateUserProfileReturnDto>, IMapTo<UserProfile>
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserProfileCommand, UserProfile>();
        }
    }
}
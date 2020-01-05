using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.UserProfiles.Commands.CreateUserProfile
{
    public class CreateUserProfileReturnDto : IMapFrom<UserProfile>
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserProfile, CreateUserProfileReturnDto>();
        }
    }
}
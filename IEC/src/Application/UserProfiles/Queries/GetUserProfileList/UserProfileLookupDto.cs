using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.UserProfiles.Queries.GetUserProfileList
{
    public class UserProfileLookupDto : IMapFrom<UserProfile>
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserProfile, UserProfileLookupDto>();
        }
    }
}
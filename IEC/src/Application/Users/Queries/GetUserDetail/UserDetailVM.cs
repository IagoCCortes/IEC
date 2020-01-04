using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Users.Queries.GetUserDetail
{
    public class UserDetailVM : IMapFrom<User>
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailVM>();
        }
    }
}
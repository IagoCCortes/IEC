using AutoMapper;
using Domain.Entities;

namespace Application.Users.Queries.GetUserList
{
    public class UserListMapping : Profile
    {
        public UserListMapping()
        {
            CreateMap<User, UserLookupDto>();
        }
    }
}
using AutoMapper;
using Domain.Entities;

namespace Application.Users.Queries.GetUserDetail
{
    public class UserDetailQueryMapping : Profile
    {
        public UserDetailQueryMapping()
        {
            CreateMap<User, UserDetailVM>();
        }
    }
}
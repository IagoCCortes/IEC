using MediatR;

namespace Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailQuery : IRequest<UserDetailVM>
    {
        public int Id { get; set; }
    }
}
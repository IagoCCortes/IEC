using MediatR;

namespace Application.Users.Queries.GetUserId
{
    public class GetUserIdQuery : IRequest<UserIdVM>
    {
        public string Id { get; set; }
    }
}
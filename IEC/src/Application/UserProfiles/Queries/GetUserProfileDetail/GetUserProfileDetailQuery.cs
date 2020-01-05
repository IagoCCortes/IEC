using MediatR;

namespace Application.UserProfiles.Queries.GetUserProfileDetail
{
    public class GetUserProfileDetailQuery : IRequest<UserProfileDetailVM>
    {
        public int Id { get; set; }
    }
}
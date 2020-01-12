using MediatR;

namespace Application.UserProfiles.Queries.GetUserProfileDetail
{
    public class GetUserProfileDetailQuery : IRequest<UserProfileDetailVM>
    {
        public string UserName { get; set; }
    }
}
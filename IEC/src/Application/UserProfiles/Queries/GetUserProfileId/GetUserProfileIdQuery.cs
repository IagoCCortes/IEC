using MediatR;

namespace Application.UserProfiles.Queries.GetUserProfileId
{
    public class GetUserProfileIdQuery : IRequest<UserProfileIdVM>
    {
        public string Id { get; set; }
    }
}
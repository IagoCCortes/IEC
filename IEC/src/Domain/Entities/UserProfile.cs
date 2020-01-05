using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class UserProfile : AuditableEntity
    {
        public UserProfile()
        {
            UserProfileMovies = new HashSet<UserProfileMovie>();
        }
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<UserProfileMovie> UserProfileMovies { get; set; }
    }
}
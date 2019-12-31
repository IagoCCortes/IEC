using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class User : AuditableEntity
    {
        public User()
        {
            UserMovies = new HashSet<UserMovie>();
        }
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<UserMovie> UserMovies { get; set; }
    }
}
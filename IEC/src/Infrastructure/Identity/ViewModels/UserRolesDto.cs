using System.Collections.Generic;

namespace Infrastructure.Identity.ViewModels
{
    public class UserRolesDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
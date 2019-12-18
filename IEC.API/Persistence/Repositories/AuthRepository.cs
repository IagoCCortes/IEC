using System.Threading.Tasks;
using IEC.API.Core.Domain;
using IEC.API.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IEC.API.Persistence.Repositories
{
    public class AuthRepository : GenericRepository<User>, IAuthRepository
    {
        public AuthRepository(DataContext context) : base(context) {}

        public async Task<bool> UserExistis(string username)
        {
            if(await Context.Users.AnyAsync(u => u.Username == username))
                return true;
                
            return false;
        }
    }
}
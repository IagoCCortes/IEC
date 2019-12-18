using System.Threading.Tasks;
using IEC.API.Core.Domain;
using IEC.API.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IEC.API.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context){}

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
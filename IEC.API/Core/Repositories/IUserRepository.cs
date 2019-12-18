using System.Threading.Tasks;
using IEC.API.Core.Domain;

namespace IEC.API.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
         Task<User> GetUserByUsernameAsync(string username);
    }
}
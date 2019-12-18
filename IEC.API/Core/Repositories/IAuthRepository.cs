using System.Threading.Tasks;
using IEC.API.Core.Domain;

namespace IEC.API.Core.Repositories
{
    public interface IAuthRepository : IGenericRepository<User>
    {
         Task<bool> UserExistis(string username);
    }
}
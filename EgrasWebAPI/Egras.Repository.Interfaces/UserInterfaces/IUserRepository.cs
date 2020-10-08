using Egras.Entities;
using System.Threading.Tasks;

namespace Egras.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
       Task <Authenticate> Authenticate(Authenticate objAuthenticate);
        Task<int> GetUserId(string loginid);
    }
}

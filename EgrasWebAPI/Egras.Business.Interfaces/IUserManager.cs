using Egras.Entities;
using Egras.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Egras.Business.Interfaces
{
    public interface IUserManager:IRepository<User>
    {
        //Task<bool> AddUser(User user);

        //Task<bool> UpdateUser(User user);

        //Task<bool> DeleteUser(int userId);

        //Task<IList<User>> GetAllUser();

        //Task<User> GetUserById(int userId);
        Task<Authenticate> Authenticate(Authenticate objAuthenticate);
        Task<int> GetUserId(string loginid);


    }
}

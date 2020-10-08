using Egras.Business.Interfaces;
using Egras.Entities;
using Egras.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Egras.Business
{
    public class UserManager : IUserManager
    {
        IUserRepository _userRepository;
        //IRepository<User> _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Add(User user)
        {
            return await _userRepository.Add(user);
        }



        public async Task<int> Delete(int userId)
        {
            return await _userRepository.Delete(userId);
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _userRepository.Get();
        }

        public async Task<IEnumerable<User>> Get(int userId)
        {
            return await _userRepository.Get(userId);
        }

        public Task<IEnumerable<User>> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetUserId(string loginid)
        {
            return await _userRepository.GetUserId(loginid);
        }

        public async Task<int> Update(User user)
        {
            return await _userRepository.Update(user);
        }
        public async Task<Authenticate> Authenticate(Authenticate objAuthenticate)
        {
            return await _userRepository.Authenticate(objAuthenticate);
        }
        //public async Task<Authenticate> Authenticate(Authenticate objAuthenticate)
        //{
        //    return await _userRepository.Authenticate(objAuthenticate);
        //}
        //public UserManager(IUserRepository userRepository)
        //{
        //    _userRepository = userRepository;
        //}
        //public bool AddUser(User user)
        //{
        //    return _userRepository.AddUser(user);
        //}

        //public bool DeleteUser(int userId)
        //{
        //    return _userRepository.DeleteUser(userId);
        //}

        //public IList<User> GetAllUser()
        //{
        //    return _userRepository.GetAllUser();
        //}

        //public User GetUserById(int userId)
        //{
        //    return _userRepository.GetUserById(userId);
        //}

        //public bool UpdateUser(User user)
        //{
        //    return _userRepository.UpdateUser(user);
        //}
    }
}

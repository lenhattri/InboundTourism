using BLL.Interfaces;
using Core.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(Guid userId)
        {
            return _userRepository.GetById(userId);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(Guid userId)
        {
            _userRepository.Delete(userId);
        }

        public IEnumerable<User> FindUsers(string fullName = null, string email = null, string phoneNumber = null)
        {
            return _userRepository.Find(fullName, email, phoneNumber);
        }
    }
}

using Base.Utils.Hash;
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
            var existingPhoneUser = _userRepository.GetByPhoneNumber(user.PhoneNumber);
            if (existingPhoneUser != null && existingPhoneUser.UserID != user.UserID)
            {
                throw new Exception("Số điện thoại đã được sử dụng bởi một người dùng khác.");
            }

            var existingEmailUser = _userRepository.GetByEmail(user.Email);
            if (existingEmailUser != null && existingEmailUser.UserID != user.UserID)
            {
                throw new Exception("Email đã được sử dụng bởi một người dùng khác.");
            }

            var usersWithSameName = _userRepository.Find(fullName: user.FullName).Where(u => u.UserID != user.UserID);
            if (usersWithSameName.Any())
            {
                throw new Exception("Tên người dùng đã tồn tại.");
            }
            user.Password = HashPassword.Hash(user.Password);
            _userRepository.Add(user);
        }

        public void UpdateUser(User user)
        {
            
            var existingPhoneUser = _userRepository.GetByPhoneNumber(user.PhoneNumber);
            if (existingPhoneUser != null && existingPhoneUser.UserID != user.UserID)
            {
                throw new Exception("Số điện thoại đã được sử dụng bởi một người dùng khác.");
            }

            var existingEmailUser = _userRepository.GetByEmail(user.Email);
            if (existingEmailUser != null && existingEmailUser.UserID != user.UserID)
            {
                throw new Exception("Email đã được sử dụng bởi một người dùng khác.");
            }

            var usersWithSameName = _userRepository.Find(fullName: user.FullName).Where(u => u.UserID != user.UserID);
            if (usersWithSameName.Any())
            {
                throw new Exception("Tên người dùng đã tồn tại.");
            }

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

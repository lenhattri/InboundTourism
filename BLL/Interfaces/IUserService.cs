using Core.Entities;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserById(Guid userId);
        User GetUserByEmail(string email);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid userId);
        IEnumerable<User> FindUsers(string fullName = null, string email = null, string phoneNumber = null);
    }
}

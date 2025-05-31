using System;
using System.Collections.Generic;
using Core.Entities;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(Guid userId);
        void Add(User user);
        void Update(User user);
        void Delete(Guid userId);
        User GetByEmail(string email);
        IEnumerable<User> Find(string fullName = null, string email = null, string phoneNumber = null);
        User GetByPhoneNumber(string phoneNumber);
    }
}

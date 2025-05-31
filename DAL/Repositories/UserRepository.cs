using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(Guid userId)
        {
            return _context.Users.Find(userId);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            // Lấy bản thể đang được EF theo dõi
            var tracked = _context.Users.Find(user.UserID);
            if (tracked == null) throw new Exception("User không tồn tại");

            // Cập nhật giá trị từ user bên ngoài vào bản thể tracked
            _context.Entry(tracked).CurrentValues.SetValues(user);

            // Lưu thay đổi
            _context.SaveChanges();
        }


        public void Delete(Guid userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetByPhoneNumber(string phoneNumber)
        {
            return _context.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
        }

        public IEnumerable<User> Find(string fullName = null, string email = null, string phoneNumber = null)
        {
            var query = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(fullName))
                query = query.Where(u => u.FullName.Contains(fullName));
            if (!string.IsNullOrEmpty(email))
                query = query.Where(u => u.Email.Contains(email));
            if (!string.IsNullOrEmpty(phoneNumber))
                query = query.Where(u => u.PhoneNumber.Contains(phoneNumber));
            return query.ToList();
        }

    }
}

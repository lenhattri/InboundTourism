using BLL.Interfaces;
using Core.Entities;
using System.Security.Cryptography;
using System.Text;
using Base.Utils.Hash;
namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;

        public AuthService(IUserService userService)
        {
            _userService = userService;
        }

        public User Login(string email, string password)
        {
            var user = _userService.GetUserByEmail(email);

            if (user == null || user.Password != HashPassword.Hash(password))
            {
                return null;
            }

            return user;
        }

        public bool Register(User newUser)
        {
            if (_userService.GetUserByEmail(newUser.Email) != null)
            {
                return false;
            }

            newUser.Password = HashPassword.Hash(newUser.Password);
            _userService.AddUser(newUser);
            return true;
        }

        
    }
}

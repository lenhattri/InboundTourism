using Core.Entities;

namespace BLL.Interfaces
{
    public interface IAuthService
    {
        User Login(string email, string password);
        bool Register(User newUser);
    }
}

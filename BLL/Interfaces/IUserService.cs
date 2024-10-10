using Core.Entities;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void UpdateUser(User user);
        void DeleteUser(int id);
        void AddUser(User user);
    }
}

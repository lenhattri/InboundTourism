using Core.Entities;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(Guid id);
        void UpdateUser(User user);
        void DeleteUser(Guid id);
        void AddUser(User user);
    }
}

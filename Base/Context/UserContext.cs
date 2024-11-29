

using Core.Enums;

namespace Base.Context
{
    public class UserContext
    {

        private static UserContext _instance;


        public string? Username { get; private set; } = "";
        public Role? Role { get; private set; } = null;
        public string? Email { get; private set; } = null;


        private UserContext() { }


        public static UserContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserContext();
                }
                return _instance;
            }
        }


        public void SetUserData(string username, Role role, string email)
        {
            Username = username;
            Role = role;
            Email = email;
        }


        public void ClearUserData()
        {
            Username = "";
            Role = null;
            Email = null;
        }
    }

}

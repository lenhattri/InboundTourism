using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Context
{
    public class UserContext
    {

        private static UserContext _instance;


        public string Username { get; private set; }
        public string Role { get; private set; }
        public string Email { get; private set; }


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


        public void SetUserData(string username, string role, string email)
        {
            Username = username;
            Role = role;
            Email = email;
        }


        public void ClearUserData()
        {
            Username = null;
            Role = null;
            Email = null;
        }
    }

}

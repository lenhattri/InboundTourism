using Core.Entities;

namespace Utils.Auth
{
    public class Auth
    {
        
        public static readonly Auth Instance = new Auth();
        private Auth(){}
        public void Login(string Username, string Password)
        {


        }
        public void SignIn(User user)
        {

        }
        public void Logout() { }
    }
}

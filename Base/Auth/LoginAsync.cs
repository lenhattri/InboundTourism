using Core.Entities;

namespace Base.Auth
{
    public class Auth
    {

        private static Auth _instance; 
        
        
        private Auth(){}

        public static Auth Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Auth();
                }
                return _instance;
            }
        }
        public void SignIn(string Username, string Password)
        {


        }
        public void SignUp(User user)
        {

        }
        public void Logout() { }
    }
}

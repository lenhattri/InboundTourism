using Core.Entities;

namespace Base.Auth
{
    public class Authentication
    {

        private static Authentication _instance; 
        
        
        private Authentication(){}

        public static Authentication Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Authentication();
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

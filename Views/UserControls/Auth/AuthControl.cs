
using Views.Interfaces;

namespace Views.UserControls.Auth
{

    public partial class AuthControl : UserControl
    {
        private readonly INavigationService _navigationService;
        public AuthControl(INavigationService navigationService)
        {

            _navigationService = navigationService;
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            _navigationService.NavigateTo("Register");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _navigationService.NavigateTo("Login");
        }
    }
}

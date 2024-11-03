
using Views.Forms;
using Views.Interfaces;

using Views.UserControls.Admin;
namespace Views.UserControls.Navigation
{
    public partial class DashboardControl : UserControl
    {
        private readonly INavigationService _navigationService;

        public DashboardControl(INavigationService navigationService)
        {
            InitializeComponent();
            _navigationService = navigationService;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            _navigationService.NavigateTo("TableUser");
        }
    }
}

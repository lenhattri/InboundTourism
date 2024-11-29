
using Views.Interfaces;

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

        private void button1_Click(object sender, EventArgs e)
        {
            _navigationService.NavigateTo("TableTour");
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            _navigationService.NavigateTo("TableLocation");
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {

        }

        private void btnTrip_Click(object sender, EventArgs e)
        {
            _navigationService.NavigateTo("TableTrip");
        }
    }
}




using Views.UserControls.Navigation;
using Views.Navigation;
using Views.UserControls.Admin;
using Views.Interfaces;
using System.Drawing.Drawing2D;

namespace Views.Forms
{
    public partial class MainForm : Form
    {
        private readonly INavigationService _navigationService;

        public MainForm()
        {
            InitializeComponent();

            _navigationService = new NavigationService(panelContainer);

           
            Router router = new Router(_navigationService);
            router.RegisterViews();

            _navigationService.NavigateTo("Loading");

        }

        

       
        private void btnTables_Click(object sender, EventArgs e)
        {
            _navigationService.NavigateTo("Dashboard");
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

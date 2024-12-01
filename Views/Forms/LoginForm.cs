using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Views.Interfaces;
using Views.Navigation;

namespace Views.Forms
{
    public partial class Login : Form
    {
        private readonly INavigationService _navigationService;

        public Login()
        {
            InitializeComponent();
            _navigationService = new NavigationService(panelContainer);


            Router router = new Router(_navigationService);
            router.RegisterViews();

            _navigationService.NavigateTo("Auth");
        }

      

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

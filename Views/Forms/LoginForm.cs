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
    public partial class LoginForm : Form
    {
        private readonly INavigationService _navigationService;

        public LoginForm()
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

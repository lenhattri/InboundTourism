using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views.Interfaces;
using Views.UserControls.Admin;
using Views.UserControls.Navigation;
namespace Views.Navigation
{
    public class Router
    {
        private readonly INavigationService _navigationService;

        public Router(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void RegisterViews()
        {
            _navigationService.RegisterView("Dashboard", () => new DashboardControl(_navigationService));
            _navigationService.RegisterView("TableUser", () => new UserListControl());  
        }
    }


}

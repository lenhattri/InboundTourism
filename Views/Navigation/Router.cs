
using Views.Interfaces;
using Views.UserControls.Admin;
using Views.UserControls.Navigation;
using Views.UserControls.Changing;
using Views.UserControls.Loading;
using Views.UserControls.Auth;

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
            //CRUD ADMIN
            _navigationService.RegisterView("Dashboard", () => new DashboardControl(_navigationService));
            _navigationService.RegisterView("TableLocation", () => new LocationListControl(_navigationService));
            _navigationService.RegisterView("ChangeLocation", () => new ChangeLocationControl());
            _navigationService.RegisterView("TableTour", () => new TourListControl(_navigationService));
            _navigationService.RegisterView("ChangeTour", () => new ChangeTourControl());
            _navigationService.RegisterView("TableTrip", () => new TripListControl(_navigationService));
            _navigationService.RegisterView("ChangeTrip", () => new ChangeTripControl());
            _navigationService.RegisterView("TableUser", () => new UserListControl(_navigationService));
            _navigationService.RegisterView("ChangeUser",() => new ChangeUserControl());
            _navigationService.RegisterView("TableBooking", () => new BookingListControl(_navigationService));
            _navigationService.RegisterView("ChangeBooking", () => new ChangeBookingControl());
            //Authentication
            _navigationService.RegisterView("Auth", () => new AuthControl(_navigationService));
            _navigationService.RegisterView("Loading", () => new LoadingControl());
            _navigationService.RegisterView("Register",() => new RegisterControl());
            _navigationService.RegisterView("Login", () => new LoginControl());

        }
    }


}

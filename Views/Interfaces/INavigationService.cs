

namespace Views.Interfaces
{
    public interface INavigationService
    {
        void NavigateTo(string viewKey, object parameter = null);
        void RegisterView(string key, Func<UserControl> viewFactory);
    }

}

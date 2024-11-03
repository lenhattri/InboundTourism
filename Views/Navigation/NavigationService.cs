
using Views.Interfaces;

namespace Views.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly Panel _panelContainer;
        private readonly Dictionary<string, Func<UserControl>> _views;

        public NavigationService(Panel panelContainer)
        {
            _panelContainer = panelContainer;
            _views = new Dictionary<string, Func<UserControl>>();
        }

        public void RegisterView(string key, Func<UserControl> viewFactory)
        {
            if (!_views.ContainsKey(key))
            {
                _views[key] = viewFactory;
            }
        }

        public void NavigateTo(string viewKey)
        {
            if (_views.TryGetValue(viewKey, out var viewFactory))
            {
                var view = viewFactory();
                _panelContainer.Controls.Clear();
                view.Dock = DockStyle.Fill;
                _panelContainer.Controls.Add(view);
                view.BringToFront();
            }
            else
            {
                throw new ArgumentException($"Trang '{viewKey}' Không tồn tại.");
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Views.Interfaces
{
    public interface INavigationService
    {
        void NavigateTo(string viewKey);
        void RegisterView(string key, Func<UserControl> viewFactory);
    }

}

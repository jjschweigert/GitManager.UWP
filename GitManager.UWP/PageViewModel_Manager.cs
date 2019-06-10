using GitManager.UWP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace GitManager.UWP
{
    [Bindable]
    public static class PageViewModel_Manager
    {
        public static LocalViewModel LocalView { get; set; } = new LocalViewModel();
    }
}

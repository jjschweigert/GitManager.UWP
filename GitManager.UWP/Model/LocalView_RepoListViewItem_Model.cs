using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace GitManager.UWP.Model
{
    [Bindable]
    public class LocalView_RepoListViewItem_Model
    {
        public string Title { get; set; }
        public string Detail { get; set; }
    }
}

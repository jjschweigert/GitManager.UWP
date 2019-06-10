using GitManager.UWP.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace GitManager.UWP.ViewModel
{
    [Bindable]
    public class LocalViewModel
    {
        private Action _OpenSelectedRepos { get; set; }
        public Action OpenSelectedRepos
        {
            get
            {
                return _OpenSelectedRepos;
            }
            set
            {
                Debug.WriteLine("Updated OpenSelectedRepos Action");
                _OpenSelectedRepos = value;
            }
        }
        private List<LocalView_RepoListViewItem_Model> _RepoListViewItems { get; set; }
        public List<LocalView_RepoListViewItem_Model> RepoListViewItems
        {
            get
            {
                return _RepoListViewItems;
            }
            set
            {
                Debug.WriteLine("Updated RepoListViewItems");
                _RepoListViewItems.Clear();

                foreach(LocalView_RepoListViewItem_Model item in value)
                {
                    _RepoListViewItems.Add(item);
                }
            }
        }

        private GridLength _RepoListView_Width { get; set; }
        public GridLength RepoListView_Width
        {
            get
            {
                return _RepoListView_Width;
            }
            set
            {
                Debug.WriteLine(string.Format("Updated RepoListView_Width From {0} to {1}", _RepoListView_Width, value));
                _RepoListView_Width = value;
            }
        }

        private GridLength _RepoDetailView_Width { get; set; }
        public GridLength RepoDetailView_Width
        {
            get
            {
                return _RepoDetailView_Width;
            }
            set
            {
                Debug.WriteLine(string.Format("Updated RepoDetailView_Width From {0} to {1}", _RepoDetailView_Width, value));
                _RepoDetailView_Width = value;
            }
        }

        public LocalViewModel()
        {
            _RepoListViewItems = new List<LocalView_RepoListViewItem_Model>();
            _RepoListView_Width = new GridLength(1, GridUnitType.Star);
            _RepoDetailView_Width = new GridLength(1, GridUnitType.Star);

            for (int i = 0; i < 30; i++)
            {
                _RepoListViewItems.Add(new LocalView_RepoListViewItem_Model
                {
                    Title = "Current Index Is " + i.ToString(),
                    Detail = "Next Index Is " + (i + 1).ToString()
                });
            }
        }
    }
}

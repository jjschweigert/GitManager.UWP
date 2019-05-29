using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GitManager.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Local : Page
    {
        public List<RepoListViewItem> RepoListViewItems { get; set;}
        public Local()
        {
            RepoListViewItems = new List<RepoListViewItem>();

            for(int i = 0; i < 30; i++)
            {
                RepoListViewItems.Add(new RepoListViewItem
                {
                    Title = "Current Index Is " + i.ToString(),
                    Text = "Next Index Is " + (i + 1).ToString()
                });
            }

            this.InitializeComponent();
            this.DataContext = this;
        }
    }

    [Bindable]
    public class RepoListViewItem
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}

using GitManager.UWP.Model;
using GitManager.UWP.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
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
        public Action OpenSelectedRepos { get; set; }

        public Local()
        {
            this.InitializeComponent();
            //this.DataContext = PageViewModel_Manager.LocalView;
        }

        private void Grid_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            //PageViewModel_Manager.LocalView.RepoListView_Width = ViewRoot.ColumnDefinitions[0].Width;
            //PageViewModel_Manager.LocalView.RepoDetailView_Width = ViewRoot.ColumnDefinitions[2].Width;
        }

        private async void Show_Message(string title, string content)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"
            };

            await dialog.ShowAsync();
        }

        private void Open_Button_Click(object sender, RoutedEventArgs e)
        {
            string temp = string.Empty;

            foreach(LocalView_RepoListViewItem_Model item in RepoListView.SelectedItems)
            {
                temp += item.Title + "\n";
            }

            Show_Message("Open Clicked", temp);
        }
    }
}

using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();

            string AppData = ApplicationData.Current.RoamingFolder.Path;
            string AppName = Assembly.GetExecutingAssembly().GetName().Name;
            string AppVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            string DatabasePath = AppData + @"\" + AppName + @"\" + AppVersion;
            DatabasePathLabel.Text = DatabasePath + @"\Stores.db";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var folderpicker = new Windows.Storage.Pickers.FolderPicker();
            folderpicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.ComputerFolder;
            folderpicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFolder folder = await folderpicker.PickSingleFolderAsync();

            string pathstr = folder.Path;

            Windows.Storage.StorageFile file = await folder.CreateFileAsync("sample.txt", CreationCollisionOption.GenerateUniqueName);

            List<string> output = new List<string>();

            foreach(StorageFile sfile in await folder.GetFilesAsync())
            {
                output.Add(sfile.Name + "\n");
            }

            stores.ItemsSource = output;

            if (!string.IsNullOrEmpty(path.Text) && !string.IsNullOrWhiteSpace(path.Text))
            {
                //string Path = path.Text;
                //DataAccess.AddData(Path);
                //StoreDirectories.Stores = await DataAccess.GetStores();
                //stores.ItemsSource = StoreDirectories.Stores;
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(path.Text) && !string.IsNullOrWhiteSpace(path.Text))
            //{
            //    string Path = path.Text;
            //    await DataAccess.DeleteStores(new List<string> { Path });
            //    StoreDirectories.Stores = await DataAccess.GetStores();
            //    stores.ItemsSource = StoreDirectories.Stores;
            //}
            //else
            //{
            //    await DataAccess.DeleteStores(null);
            //    StoreDirectories.Stores = await DataAccess.GetStores();
            //    stores.ItemsSource = StoreDirectories.Stores;
            //}
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //string AppData = ApplicationData.Current.RoamingFolder.Path;
            //string AppName = Assembly.GetExecutingAssembly().GetName().Name;
            //string AppVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            //string DatabasePath = AppData + @"\" + AppName + @"\" + AppVersion;

            //StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(DatabasePath);
            //await Windows.System.Launcher.LaunchFolderAsync(folder);
        }
    }
}

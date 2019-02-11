using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GitManager.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<NavigationViewItem> NavigationViewItems { get; set; } = new List<NavigationViewItem>();
        public Dictionary<NavigationViewItem, Action> NavigationViewItemMapping { get; set; } = new Dictionary<NavigationViewItem, Action>();

        public MainPage()
        {
            this.InitializeComponent();

            var query = from NavigationViewItem obj in MainView_NavigationView.MenuItems
                        where obj.Name == "SettingsNavPaneItem"
                        where obj.Content.ToString().ToLower() == "settings"
                        select obj;

            NavigationViewItem settings = query.FirstOrDefault(null);

        }

        private void MainView_NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItem item = args.InvokedItemContainer as NavigationViewItem;
            NavigationViewItemMapping[item]();
        }

        Action NavigationViewItemMapper(NavigationViewItem item)
        {
            if(item.Name == Login_NavViewItem.Name)
            {
                return Login_Clicked;
            }

            else if(item.Name == Remote_NavViewItem.Name)
            {
                return Remote_Clicked;
            }

            else if(item.Name == Local_NavViewItem.Name)
            {
                return Local_Clicked;
            }

            else if(item.Name == ScheduleSync_NavViewItem.Name)
            {
                return ScheduleSync_Clicked;
            }

            else if(item.Name == "SettingsNavPaneItem")
            {
                return Settings_Clicked;
            }

            return null;
        }

        private void NavViewItem_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationViewItem item = sender as NavigationViewItem;

                Action action = NavigationViewItemMapper(item);

                if (action != null)
                {
                    NavigationViewItemMapping.Add(item, action);
                }
                else
                {
                    NavigationViewItemMapping.Add(item, new Action(async () =>
                    {
                        ContentDialog temp = new ContentDialog
                        {
                            Content = item.Content,
                            CloseButtonText = "Ok"
                        };

                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                        {
                            await temp.ShowAsync();
                        });
                    }));
                }
            }
            catch
            { }
        }

        private async void Login_Clicked()
        {
            ContentDialog temp = new ContentDialog
            {
                Content = "Login d",
                CloseButtonText = "Ok"
            };

            await temp.ShowAsync();
        }

        private async void Remote_Clicked()
        {
            ContentDialog temp = new ContentDialog
            {
                Content = "Remote Repo",
                CloseButtonText = "Ok"
            };

            await temp.ShowAsync();
        }

        private async void Local_Clicked()
        {
            ContentDialog temp = new ContentDialog
            {
                Content = "Local Repo",
                CloseButtonText = "Ok"
            };

            await temp.ShowAsync();
        }

        private async void ScheduleSync_Clicked()
        {
            ContentDialog temp = new ContentDialog
            {
                Content = "Schedule Sync",
                CloseButtonText = "Ok"
            };

            await temp.ShowAsync();
        }

        private async void Settings_Clicked()
        {
            ContentDialog temp = new ContentDialog
            {
                Content = "Settings",
                CloseButtonText = "Ok"
            };

            await temp.ShowAsync();
        }
    }
}

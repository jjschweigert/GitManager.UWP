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
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainView_NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if(args.IsSettingsInvoked)
            {
                
            }
            else
            {
                NavigationViewItem item = args.InvokedItemContainer as NavigationViewItem;

                switch(item.Content)
                {
                    case "Login":
                        ContentFrame.Navigate(typeof(Views.Login));
                        break;
                    case "Remote":
                        ContentFrame.Navigate(typeof(Views.Remote));
                        break;

                    case "Local":
                        ContentFrame.Navigate(typeof(Views.Local));
                        break;

                    case "Schedule":
                        ContentFrame.Navigate(typeof(Views.Schedule));
                        break;
                }
            }
        }

        private async void MainView_NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            var contentBox = new ContentDialog();
            contentBox.Content = "Back clicked";

            await contentBox.ShowAsync();
        }
    }
}

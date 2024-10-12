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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Menu_app
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Method that creates a custom dialog box
        public async void Showmessage(string msg)
        {
            var dialog = new ContentDialog()
            {
                Title = "COMMAND TYPES",
                Content = msg,
                CloseButtonText = "OK"
            };
            await dialog.ShowAsync();
            Frame.Navigate(typeof(Home));
        }

        // Method dialog to show welcome page
        public async void ShowHome(string message)
        {
            var homedialog = new ContentDialog()
            {
                Title = "Welcome Dialog",
                Content = message,
                CloseButtonText = "OK"
            };
            await homedialog.ShowAsync();
        }

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void view_output_click(object sender, RoutedEventArgs e)
        {
            //Showmessage("Displaying available commands, Please wait.");
            Showmessage("This is navigating you to the home page.");

            // Navigate to another page
            //Frame.Navigate(typeof(Home));
        }

        private void home_appbar_clcik(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Home));
            ShowHome("Hello, You're welcom to your home page.");
        }
    }
}

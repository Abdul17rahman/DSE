using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DataMgt
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        // Mathod for displaying name in a dialog box
        public async void Showmessage(string title, string message)
        {
            var dialogmsg = new ContentDialog()
            {
                Title = title,
                Content = message,
                CloseButtonText = "OK",
            };
            await dialogmsg.ShowAsync();
        }

        public MainPage()
        {
            this.InitializeComponent();
        }

        // Paste button click functionality to paste name in a text block
        private void btn_paste_click(object sender, RoutedEventArgs e)
        {
            var name = username.Text;

            Showmessage("Name Pasted", $"You have entered {name}");

            placeholder.Text = name;

            username.Text = "";
        }

        // Toggle Power on and off - changes the background color of the stackpanel as well
        private void toggle_to_change_power(object sender, RoutedEventArgs e)
        {
            bool isOn = toggle.IsOn;

            if (isOn)
            {
                Showmessage("Display State","Dark Mode is now ON");
                container.Background = new SolidColorBrush(Color.FromArgb(255, 11, 25, 44));
            }
            else
            {
                Showmessage("Display State", "Dark Mode is now OFF");
                container.Background = new SolidColorBrush(Color.FromArgb(255, 24,77,89));
            }
        }

        // Method for the button to navigate to the home page
        private void next_btn_click(object sender, RoutedEventArgs e)
        {
            Showmessage("Navigation", "Navigating to the Home Page");
            Frame.Navigate(typeof(Home));
        }

        // Method for copying data
        private void copy_btn_click(object sender, RoutedEventArgs e)
        {
            Showmessage("Copy Action", "Data Copied Successfully");
        }

        // Method for pasting data
        private void paste_btn_click(object sender, RoutedEventArgs e)
        {
            Showmessage("Paste Action", "Data Pasted Successfully");
        }
    }
}

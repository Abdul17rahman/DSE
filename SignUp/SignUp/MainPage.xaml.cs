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
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SignUp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        // On click, the method retrives the name from the name textbox and interpolates it in the message dialog popup to be displayed.
        private async void btnregister_Click(object sender, RoutedEventArgs e)
        {
            var username = name.Text;
            var messageinterface = new MessageDialog($"{username} has been succesfully registered");
            await messageinterface.ShowAsync();
        }

        // On Click, the method sets the textBox Values to an empty string and displays a popup that notify you about the clearance
        private async void btnreset_Click(object sender, RoutedEventArgs e)
        {
            name.Text = "";
            email.Text = "";
            password.Text = "";
            confirmpass.Text = "";

            var messageinterface = new MessageDialog("The fields have been cleared.!");
            await messageinterface.ShowAsync();
        }
    }
}

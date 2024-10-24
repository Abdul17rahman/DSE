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

namespace NavApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            NavView.SelectedItem = NavView.MenuItems[0];
        }

        private void navigate_pages(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                Viewcontent.Navigate(typeof(Home));
            }
            else if (args.SelectedItem is NavigationViewItem actualbuttonnavigationitem)
            {
                string selectedItem = actualbuttonnavigationitem.Content as string;

                switch (selectedItem)
                {
                    case "Home":
                        Viewcontent.Navigate(typeof(Home));
                        break;

                    case "Contact":
                        Viewcontent.Navigate(typeof(Contact));
                        break;

                    case "Setting":
                        Viewcontent.Navigate(typeof(Setting));
                        break;
                }
            }
        }
    }
}

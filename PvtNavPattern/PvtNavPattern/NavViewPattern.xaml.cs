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

namespace PvtNavPattern
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavViewPattern : Page
    {
        public NavViewPattern()
        {
            this.InitializeComponent();
            mainnavview.SelectedItem = mainnavview.MenuItems[0];
        }

        private void navigate(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if(args.IsSettingsSelected)
            {
                viewcontent.Navigate(typeof(Home));
            }
            else if(args.SelectedItem is NavigationViewItem actualbuttonnavigationitem)
            {
                string declarednavitem = (string)actualbuttonnavigationitem.Content;

                switch(declarednavitem)
                {
                    case "Home":
                        viewcontent.Navigate(typeof(Home));
                        break;

                    case "Contact":
                        viewcontent.Navigate(typeof(Contact));
                        break;

                    case "Setting":
                        viewcontent.Navigate(typeof(Setting));
                        break;
                }
            }
        }
    }
}

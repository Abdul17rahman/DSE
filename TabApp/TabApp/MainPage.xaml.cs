using Microsoft.UI.Xaml.Controls;
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

namespace TabApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        int tabCount = 0;        
        public MainPage()
        {
            this.InitializeComponent();
            createTab();
        }

        // Method for creating a tab
        public void createTab()
        {
            tabCount++;
            var newTab = new TabViewItem
            {
                Header = $"Tab {tabCount} - Abdul Rahman",
                Content = "Welcome."
            };

            tabview.TabItems.Add(newTab);
        }

        // Method to add tab button
        private void add_tab_click(object sender, RoutedEventArgs e)
        {
            createTab();
        }

        private void close_tab_click(TabView sender, TabViewTabCloseRequestedEventArgs args)
        {
            sender.TabItems.Remove(args.Tab);
        }

        // Go forward to the next tab
        private void forward_tab_clcik(object sender, RoutedEventArgs e)
        {
            if (tabCount > 0)
            {
                tabview.SelectedIndex++;
            }
        }

        // Return back to the previous tab
        private void prev_tab_click(object sender, RoutedEventArgs e)
        {
            if (tabCount > 0)
            {
                tabview.SelectedIndex--;
            }
        }
    }
}

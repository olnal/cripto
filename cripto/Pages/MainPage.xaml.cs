using crypto.Model;
using crypto.Pages;
using crypto.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace crypto.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private async void buttonGetExchange(object sender, RoutedEventArgs e)
        {
            
        }

        private async void buttonGetAsset(object sender, RoutedEventArgs e)
        {
            DataView.Content = new AssetView();
        }

        private async void buttonGetMarket(object sender, RoutedEventArgs e)
        {
            DataView.Content = new MarketView();
        }
    }
}

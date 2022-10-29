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
        private readonly IClient _client;

        public MainPage(IClient client)
        {
            InitializeComponent();
            _client = client;
            
        }

        private async void buttonGetExchange(object sender, RoutedEventArgs e)
        {
            ExchangeView page = new ExchangeView(_client);
            await page.Get();
            DataView.Content = page;
        }

        private async void buttonGetAsset(object sender, RoutedEventArgs e)
        {
            AssetView page = new AssetView(_client);
            await page.Get();
            DataView.Content = page;
        }

        private async void buttonGetMarket(object sender, RoutedEventArgs e)
        {
            MarketView page = new MarketView(_client);
            await page.Get();
            DataView.Content = page;
        }
    }
}

using crypto.Services;
using crypto.Model;
using crypto.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace crypto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IApiClient _apiClient;
        private readonly ISearchClient _searchClient;
        public MainWindow()
        {
            _apiClient = new ApiClient();
            _searchClient = new SearchClient(_apiClient);
            InitializeComponent();
            MainFrame.Content = new MainPage(_apiClient);
        }

        private void btnMainPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MainPage(_apiClient);

        }

        private async  void btnDetailsAsset(object sender, RoutedEventArgs e)
        {
            DetailsAsser page = new DetailsAsser(_searchClient, _apiClient);
            await page.Get();
            MainFrame.Content = page;            
        }

        private async void btnDateilsExchange(object sender, RoutedEventArgs e)
        {
            DetailsExchange page = new DetailsExchange(_searchClient,_apiClient);
            await page.Get();
            MainFrame.Content = page;
        }
        private async void btnConvertation(object sender, RoutedEventArgs e)
        {
            Convertation page = new Convertation(_apiClient);
            await page.Get();
            MainFrame.Content = page;
        }        
    }
}

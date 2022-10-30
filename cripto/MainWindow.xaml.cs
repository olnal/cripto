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

namespace crypto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IApiClient _client;
        private readonly ISearchClient _searchClient;
        public MainWindow()
        {
            _client = new ApiClient();
            _searchClient = new SearchClient(_client);
            InitializeComponent();
            MainFrame.Content = new MainPage(_client);
        }

        private void btnMainPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MainPage(_client);

        }

        private void btnDetailsAsset(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DetailsAsser(_searchClient);
        }

        private void btnDateilsExchange(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DetailsExchange(_searchClient);
        }

        private void btnConvertation(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Convertation(_searchClient);
        }
    }
}

using crypto.Services;
using crypto.Model;
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
using System.Xml.Serialization;
using System.Linq;
using System.Threading.Tasks;

namespace crypto.Pages
{
    /// <summary>
    /// Interaction logic for DetailsAsser.xaml
    /// </summary>
    public partial class DetailsAsser : Page
    {

        private readonly ISearchClient _searchClient;
        private readonly IApiClient _apiClient;
        private List<Asset> _exchangeData;
        public DetailsAsser(ISearchClient searchClient, IApiClient apiClient)
        {
            _apiClient = apiClient;
            _searchClient = searchClient;
            InitializeComponent();
        }

        public async Task Get()
        {
            _exchangeData = await _apiClient.GetAsset();
            var currencies = _exchangeData.Select(n => n.name).ToList();
            List.ItemsSource = currencies;
        }
        
        private async void buttonGetAsset(object sender, RoutedEventArgs e)
        {
            Asset ass = await _searchClient.GetAssetSearch(List.Text);
            if (ass != null) 
            { 
                AssetIDValue.Content = ass.assetId;
                AssetNameValue.Content = ass.name;
                Volume24Value.Content = ass.volume_24h;
                Change1hValue.Content = ass.change_1h;
                Change24hValue.Content = ass.change_24h;
                Change7dValue.Content = ass.change_7d;
                StatusValue.Content = ass.status;
                CreatedValue.Content = ass.created_at;
                UpdatedValue.Content = ass.updated_at;
            }
            else
            {
                MessageBox.Show("Not found","!!!");
            }
        }
    }
}

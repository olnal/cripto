using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using crypto.Services;

namespace crypto.Pages
{
    /// <summary>
    /// Interaction logic for AssetView.xaml
    /// </summary>
    public partial class AssetView : Page
    {
        private readonly IApiClient _client;
        public AssetView(IApiClient client)
        {
            _client = client;
            InitializeComponent();
        }

        public async Task Get()
        {
            CurrencyListAsset.ItemsSource = await _client.GetAsset();
        }
       
    }
}

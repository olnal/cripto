using crypto.Data;
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

namespace crypto.Pages
{
    /// <summary>
    /// Interaction logic for Detail.xaml
    /// </summary>
    public partial class Detail : Page
    {
        private readonly IClient _client;
        public Detail(IClient client)
        {
            _client = client;
            InitializeComponent();
        }
        private void buttonGetAsset(object sender, RoutedEventArgs e)
        {
            Asset ass = _client.GetAssetSearch(AssetIdInput.Text);

            AssetIDValue.Content = ass.assetId;
            //CurrencyNameValue.Content = _currencyDetailViewModel.Asset.Name;
            //Change1hValue.Content = _currencyDetailViewModel.Asset.Change_1h;
            //Change24hValue.Content = _currencyDetailViewModel.Asset.Change_24h;
            //Change7dValue.Content = _currencyDetailViewModel.Asset.Change_7d;
            //Volume24Value.Content = _currencyDetailViewModel.Asset.Volume_24h;
            //CurrencyDescription.Text = _currencyDetailViewModel.Asset.Description;
        }
    }
}

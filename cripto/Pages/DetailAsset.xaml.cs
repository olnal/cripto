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
using System.Xml.Serialization;

namespace crypto.Pages
{
    /// <summary>
    /// Interaction logic for DetailAsser.xaml
    /// </summary>
    public partial class DetailAsser : Page
    {
        private readonly IClient _client;
        public DetailAsser(IClient client)
        {
            _client = client;
            InitializeComponent();
        }
        private async void buttonGetAsset(object sender, RoutedEventArgs e)
        {
            Asset ass = await _client.GetAssetSearch(AssetIdInput.Text);
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

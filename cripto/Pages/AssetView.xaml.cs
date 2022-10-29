using System;
using System.Collections.Generic;
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
using crypto.Data;

namespace crypto.Pages
{
    /// <summary>
    /// Interaction logic for AssetView.xaml
    /// </summary>
    public partial class AssetView : Page
    {
        private readonly IClient _client;
        public AssetView(IClient client)
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

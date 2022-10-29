using crypto.Data;
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

namespace crypto.Pages
{
    /// <summary>
    /// Interaction logic for MarketView.xaml
    /// </summary>
    public partial class MarketView : Page
    {
        private readonly IClient _client;

        public MarketView(IClient client)
        {
            _client = client;
            InitializeComponent();
        }

        public async Task Get()
        {
            CurrencyListMarket.ItemsSource = await _client.GetMarket();
        }
    }
}

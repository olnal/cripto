using crypto.Services;
using crypto.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Linq;
using System.Threading.Tasks;

namespace crypto.Pages
{
    /// <summary>
    /// Interaction logic for DetailExchange.xaml
    /// </summary>
    public partial class DetailsExchange : Page
    {
        private readonly ISearchClient _searchClient;
        private readonly IApiClient _apiClient;
        private List<Exchange> _exchangeData;
        public DetailsExchange(ISearchClient searchClient, IApiClient apiClient)
        {
            _apiClient=apiClient;
            _searchClient = searchClient;
            InitializeComponent();
        }

        public async Task Get()
        {
            _exchangeData = await _apiClient.GetExchange();
            var currencies = _exchangeData.Select(n => n.exchange_id).ToList();
            List.ItemsSource = currencies;
        }
        

        private void hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {Website.Content}") { CreateNoWindow = true });
        }

        private string LinkToMarket(Exchange exchange)
        {
            string url = String.Empty;
            switch (exchange.exchange_id)
            {
                case "BINANCE":
                    url = $"https://www.binance.com/";
                    break;
                case "KRAKEN":
                    url = $"https://www.kraken.com/";
                    break;
                case "COINBASE":
                    url = $"https://www.coinbase.com/";
                    break;
                case "HUOBIGLOBAL":
                    url = $"https://www.huobi.com/en-us/";
                    break;
                case "BITFINEX":
                    url = $"https://trading.bitfinex.com/";
                    break;
                case "POLONIEX":
                    url = $"https://poloniex.com/spot/";
                    break;
            }
            return url;

        }

       

        private async void buttonDetailExchanges(object sender, RoutedEventArgs e)
        {
            Exchange ex = await _searchClient.GetExchangeSearch(List.Text);
            if (ex != null)
            {
                ExchangeIDValue.Content = ex.exchange_id;
                ExchangeNameValue.Content = ex.name;
                Volume24Value.Content = ex.volume_24h;
                var temporary = LinkToMarket(ex);
                if (temporary == "")
                {
                    Website.Content = ex.website;
                }
                else
                {
                    Website.Content = temporary;
                }
            }
            else
            {
                MessageBox.Show("Not found", "!!!");
            }
        }
    }
}

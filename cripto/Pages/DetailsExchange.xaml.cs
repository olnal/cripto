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

namespace crypto.Pages
{
    /// <summary>
    /// Interaction logic for DetailExchange.xaml
    /// </summary>
    public partial class DetailsExchange : Page
    {
        private readonly ISearchClient _client;
        public DetailsExchange(ISearchClient client)
        {
            _client = client;
            InitializeComponent();
        }
        private async void buttonGetExchange(object sender, RoutedEventArgs e)
        {
            Exchange ex = await _client.GetExchangeSearch(ExchangeIdInput.Text);
            if (ex != null)
            {
                ExchangeIDValue.Content = ex.exchange_id;
                ExchangeNameValue.Content = ex.name;
                Volume24Value.Content = ex.volume_24h;
                Website.Content = ex.website;
                Hyperlink hyperlink = new Hyperlink();
                Run run = new Run();
                run.Text = ex.website;
                hyperlink.NavigateUri = new Uri(ex.website);
                hyperlink.Inlines.Add(run);
                Website.Content = hyperlink;
            }
            else
            {
                MessageBox.Show("Not found", "!!!");
            }
        }

        private async void hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Exchange ex = await _client.GetExchangeSearch(ExchangeIdInput.Text);
            Process.Start(ex.website);
        }
    }
}

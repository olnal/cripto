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
using System.Threading.Tasks;

namespace crypto.Pages
{
    /// <summary>
    /// Interaction logic for ExchangeView.xaml
    /// </summary>
    public partial class ExchangeView : Page
    {
        private readonly IClient _client;

        public ExchangeView(IClient client)
        {
            _client = client;
            InitializeComponent();           
        }

        public async Task Get()
        {
            CurrencyListExchange.ItemsSource = await _client.GetExchange();
        }
    }
}

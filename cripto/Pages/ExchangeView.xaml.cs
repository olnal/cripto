using crypto.Data;
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
    /// Interaction logic for ExchangeView.xaml
    /// </summary>
    public partial class ExchangeView : Page
    {
        public ExchangeView()
        {
            DataExchanges dataExchanges = new DataExchanges();
            dataExchanges.FillData();
            CurrencyListExchange.ItemsSource = dataExchanges.exchangeList;
            InitializeComponent();
        }
    }
}

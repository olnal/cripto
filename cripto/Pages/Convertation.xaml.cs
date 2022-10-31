using crypto.Services;
using crypto.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Convertation.xaml
    /// </summary>
    public partial class Convertation : Page
    {
        private readonly IApiClient _client;
        private List<Market> _marketData;
        public Convertation(IApiClient client)
        {
            _client = client;
            InitializeComponent();
        }
        public async Task Get()
        {
            _marketData = await _client.GetMarket();
            var currencies = _marketData.Select(n => n.symbol).ToList();
            FirstCurrency.ItemsSource = currencies;
            SecondCurrency.ItemsSource = currencies;
        }

        private void buttonConvert(object sender, RoutedEventArgs e)
        {
            
            Market marketFirst = _marketData.Where(n => n.symbol == FirstCurrency.Text).FirstOrDefault();
            Market marketSecond = _marketData.Where(n =>  n.symbol == SecondCurrency.Text).FirstOrDefault();
            if (marketFirst != null && marketSecond != null)
            {
                double result = ConvertToDouble(ExchangeCount1.Text) * marketSecond.price / marketFirst.price;
                ExchangeCount2.Content = result.ToString();
            }
            else
            {
                MessageBox.Show("Not found currency", "!!!");
            }
        }
        private double ConvertToDouble(string s)
        {
            char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            double result = 0;
            try
            {
                if (s != null)
                    if (!s.Contains(","))
                        result = double.Parse(s, CultureInfo.InvariantCulture);
                    else
                        result = Convert.ToDouble(s.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
            }
            catch (Exception e)
            {
                try
                {
                    result = Convert.ToDouble(s);
                }
                catch
                {
                    try
                    {
                        result = Convert.ToDouble(s.Replace(",", ";").Replace(".", ",").Replace(";", "."));
                    }
                    catch
                    {
                        MessageBox.Show("Wrong number");
                    }
                }
            }
            return result;
        }

    }
}

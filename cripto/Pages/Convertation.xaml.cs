using crypto.Data;
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

namespace crypto.Pages
{
    /// <summary>
    /// Interaction logic for Convertation.xaml
    /// </summary>
    public partial class Convertation : Page
    {
        private readonly IClient _client;
        public Convertation(IClient client)
        {
            _client = client;
            InitializeComponent();
        }
        private async void buttonConvert(object sender, RoutedEventArgs e)
        {
            Market marketFirst = await _client.GetMarketSearch(ExchangeIdInput1.Text);
            Market marketSecond = await _client.GetMarketSearch(ExchangeIdInput2.Text);

            

            if (marketFirst != null && marketSecond != null)
            {
                double x = ConvertToDouble(ExchangeCount1.Text);
                double y = x * marketSecond.price / marketFirst.price;
                ExchangeCount2.Content = y.ToString();                
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
                        throw new Exception("Wrong string-to-double format");
                    }
                }
            }
            return result;
        }

    }
}

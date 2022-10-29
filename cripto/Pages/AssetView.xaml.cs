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
using crypto.Data;

namespace crypto.Pages
{
    /// <summary>
    /// Interaction logic for AssetView.xaml
    /// </summary>
    public partial class AssetView : Page
    {
        public AssetView()
        {
            DataAsset dataAsset = new DataAsset();
            dataAsset.FillData();
            CurrencyListAsset.ItemsSource = dataAsset.assetList;
            InitializeComponent();
        }
    }
}

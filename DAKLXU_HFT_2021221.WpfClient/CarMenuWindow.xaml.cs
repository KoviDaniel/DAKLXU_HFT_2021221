using DAKLXU_HFT_2021221.WpfClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DAKLXU_HFT_2021221.WpfClient
{
    /// <summary>
    /// Interaction logic for CarMenuWindow.xaml
    /// </summary>
    public partial class CarMenuWindow : Window
    {
        public CarMenuWindow()
        {
            InitializeComponent();
            var vm = new CarMenuWindowViewModel();
            this.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}

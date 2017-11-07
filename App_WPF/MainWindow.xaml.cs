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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace App_WPF
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task<(double latitude, double longitude)> task = Task.Run(() => GpsLocation.GetCoordinates());
            task.Wait();

            string result = String.Format("Latitude: {0:f2}, Longitude: {1:f2}", task.Result.latitude, task.Result.longitude);
            this.result.Content = result;
        }
    }
}

using MultiLibGPS;
using System;
using System.Threading.Tasks;
using System.Windows;

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

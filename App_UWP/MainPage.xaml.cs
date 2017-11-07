using MultiLibGPS;
using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace App_UWP
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize
              = new Size { Height = 350, Width = 960 };
            ApplicationView.PreferredLaunchWindowingMode
              = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task<(double latitude, double longitude)> task = Task.Run(() => GpsLocation.GetCoordinates());
            task.Wait();

            string result = String.Format("Latitude: {0:f2}, Longitude: {1:f2}", task.Result.latitude, task.Result.longitude);
            this.result.Text = result;
        }
    }
}

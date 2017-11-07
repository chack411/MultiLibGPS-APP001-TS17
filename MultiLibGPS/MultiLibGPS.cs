using System;
using System.Threading.Tasks;

namespace MultiLibGPS
{
    public static class GpsLocation
    {
        public static async Task<(double latitude, double longitude)> GetCoordinates()
        {
#if NET461
            return await Task.Run(async () =>
            {
                using (var watcher = new System.Device.Location.GeoCoordinateWatcher())
                {
                    watcher.TryStart(true, TimeSpan.FromSeconds(1));
                    while (watcher.Position.Location.IsUnknown)
                        await Task.Delay(TimeSpan.FromMilliseconds(100));

                    var location = watcher.Position.Location;
                    return (location.Latitude, location.Longitude);
                }
            });
#elif WINDOWS_UWP
            double latitude = 0.0;
            double longitude = 0.0;

            var accessStatus = await Windows.Devices.Geolocation.Geolocator.RequestAccessAsync();
            switch (accessStatus)
            {
                case Windows.Devices.Geolocation.GeolocationAccessStatus.Allowed:
                    var locator = new Windows.Devices.Geolocation.Geolocator();
                    var potition = await locator.GetGeopositionAsync();
                    latitude = potition.Coordinate.Point.Position.Latitude;
                    longitude = potition.Coordinate.Point.Position.Longitude;
                    break;
            }

            return (latitude, longitude);
#elif NETCOREAPP2_0 || NETSTANDARD2_0
            return (0.0, 0.0);
#else
            throw new PlatformNotSupportedException();
#endif
        }
    }
}

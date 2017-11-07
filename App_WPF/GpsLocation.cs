﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_WPF
{
    public static class GpsLocation
    {
        public static async Task<(double latitude, double longitude)> GetCoordinates()
        {
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
        }
    }
}

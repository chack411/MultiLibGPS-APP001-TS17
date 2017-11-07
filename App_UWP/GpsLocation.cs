﻿using System;
using System.Threading.Tasks;

namespace App_UWP
{
    public static class GpsLocationOrg
    {
        public static async Task<(double latitude, double longitude)> GetCoordinates()
        {
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
        }
    }
}

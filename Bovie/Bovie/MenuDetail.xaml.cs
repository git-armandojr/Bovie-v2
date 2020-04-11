using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Bovie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuDetail : ContentPage
    {
        private Position _position;

        public MenuDetail()
        {
            InitializeComponent();

            if (IsLocationAvailable() && IsGeoLocationEnabled())
                GetLocation();

            Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(
                              //new Position(-23.73815, -46.58407),
                              _position,
                              Distance.FromMiles(0.2)));


            var pin = new Pin
            {
                Type = PinType.Place,
                //Position = new Position(-23.73815, -46.58407),
                Position = _position,
                Label = string.Format("{0}, {1}", _position.Latitude.ToString(), _position.Longitude.ToString()),
                Address = "unknown",
            };

            Mapa.Pins.Add(pin);
        }

        private async void GetLocation()
        {
            Plugin.Geolocator.Abstractions.Position position = null;
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;

                position = await locator.GetLastKnownLocationAsync();

                if (position != null)
                {
                    _position = new Position(position.Latitude, position.Longitude);
                    //got a cahched position, so let's use it.
                    return;
                }

                if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                {
                    //not available or enabled
                    return;
                }

                position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);

            }
            catch (Exception ex)
            {
                throw ex;
                //Display error as we have timed out or can't get location.
            }
            _position = new Position(position.Latitude, position.Longitude);
            if (position == null)
                return;
        }

        public bool IsLocationAvailable()
        {
            if (!CrossGeolocator.IsSupported)
                return false;

            return CrossGeolocator.Current.IsGeolocationAvailable;
        }

        public bool IsGeoLocationEnabled()
        {
            return CrossGeolocator.Current.IsGeolocationEnabled;
        }
    }
}
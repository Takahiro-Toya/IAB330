using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapPage
{

    public class MapPageCS : ContentPage
    {
        public MapPageCS()
        {
            var customMap = new CustomMap
            {
                IsShowingUser = true, //Dont Activate this until GPS shows your position (It will just crash)
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(27.477931, 153.029069),
                Label = "QUT Gardens Point Campus",
                Address = "2 George St, Brisbane City QLD 4000"
            };

            var position = new Position(27.477931, 153.029069);
            customMap.Circle = new CustomCircle
            {
                Position = position,
                Radius = 1000
            };

            customMap.Pins.Add(pin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1.0)));

            Content = customMap;
        }
    }
}
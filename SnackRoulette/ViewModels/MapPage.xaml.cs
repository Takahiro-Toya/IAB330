using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Diagnostics;
using Plugin.Permissions.Abstractions;
using Plugin.Geolocator;
using MapPage;

namespace SnackRoulette
{
    public class MapPage : ContentPage
    {
        CustomMap customMap;
        public MapPage()
        {
            customMap = new CustomMap
            {
                
                IsShowingUser = true, //Dont Activate this until GPS permissions are met (It will just crash)
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };


            //Starting region of the map, figure out how to set that to GPS
            var position = new Position(-27.477730, 153.029065);

            // add the slider for adjusting search radius
            var slider = new Slider(1, 18, 1);
            slider.ValueChanged += (sender, e) => {

            };

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "QUT Gardens Point Campus",
                Address = "2 George St, Brisbane City QLD 4000"
            };

            
            customMap.Circle = new CustomCircle
            {
                Position = position,
                Radius = 1000
            };

            customMap.Pins.Add(pin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1.0)));


            // create map style buttons
            var street = new Button { Text = "Street" };
            var hybrid = new Button { Text = "Hybrid" };
            street.Clicked += HandleClicked;
            hybrid.Clicked += HandleClicked;
            var segments = new StackLayout
            {
                
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Horizontal,
                Spacing = 50,
                Children = { street, hybrid }
            };


            // constructing all above functions (Need to convert this into XML, I was lazy)
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(customMap);
            stack.Children.Add(slider);
            stack.Children.Add(segments);
            Content = stack;


 
        }

        void HandleClicked(object sender, EventArgs e)
        {
            var b = sender as Button;
            switch (b.Text)
            {
                case "Street":
                    customMap.MapType = MapType.Street;
                    break;
                case "Hybrid":
                    customMap.MapType = MapType.Hybrid;
                    break;
            }
        }
    }
}

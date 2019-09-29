using System;
using SnackRoulette.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Diagnostics;
using SnackRoulette.ViewModels;

namespace SnackRoulette
{
    public class MapViewModel : BaseViewModel
    {
        Map map;
        public MapViewModel()
        {
            map = new Map
            {
                IsShowingUser = true, //Dont Activate this until GPS works (It will just crash)
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            //Starting region of the map, figure out how to set that to GPS
            //map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Order.CoordinateLat, order.CoordinateLong), Distance.FromKilometers(6)));

            /*
             * This area isn't importing the Order object properly from RouletteViewModel, I know I've implemented it incorrectly, I just don't know how
             *
             */
            /*map.Pins.Clear();
            var position = new Position(Order.CoordinateLat, Order.CoordinateLong); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = Order.Cuisine,
            };
            map.Pins.Add(pin);*/




        }
    }
}

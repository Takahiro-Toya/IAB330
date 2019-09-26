using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Diagnostics;
using System.Collections.Generic;
using SnackRoulette.Models;
using Xamarin.Essentials;

namespace SnackRoulette
{
    public class MapView : ContentPage
    {
        private Place place
        {
            set
            {
                if (value != null)
                {

                        Models.Location locat = PlaceApi.GetLocat(value.PlaceId).Result;
                        Latitude = locat.Latitude;
                        Longitude = locat.Longitude;

                }
                else
                {
                    Latitude = 0;
                    Longitude = 0;
                }

            }
        }

        public OrderModel Order = null;
               private double latitude = 0;
        public double Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                OnPropertyChanged("Latitude");
            }
        }
        private double longitude = 0;
        public double Longitude
        {
            get { return longitude; }
            set
            {
                longitude = value;
                OnPropertyChanged("Longitude");
            }
        }


        Xamarin.Forms.Maps.Map map;
        public MapView()
        {
            
            map = new Xamarin.Forms.Maps.Map
            {
                IsShowingUser = true, //Dont Activate this until GPS works (It will just crash)
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };



            //Starting region of the map, figure out how to set that to GPS

            // add the slider for adjusting search radius
            var slider = new Slider(1, 18, 1);
            slider.ValueChanged += (sender, e) => {

            };


           /* async void recalcClicked(object sender, EventArgs args)
            {
                Xamarin.Essentials.Location location = await Geolocation.GetLocationAsync();
                map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, location.Latitude, location.Longitude));
            }*/



                // constructing all above functions (Need to convert this into XML, I was lazy)
                var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            stack.Children.Add(slider);
            Content = stack;


 
        }
    }
}

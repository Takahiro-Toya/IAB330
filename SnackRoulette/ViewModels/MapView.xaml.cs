using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Diagnostics;

namespace SnackRoulette
{
    public class MapView : ContentPage
    {
        Map map;
        public MapView()
        {
            map = new Map
            {
                //IsShowingUser = true, //Dont Activate this until GPS works (It will just crash)
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            //Starting region of the map, figure out how to set that to GPS
            //map.MoveToRegion(new MapSpan(new Position(0, 0), 360, 360));

            // add the slider for adjusting search radius
            var slider = new Slider(1, 18, 1);
            slider.ValueChanged += (sender, e) => {

            };


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
            stack.Children.Add(map);
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
                    map.MapType = MapType.Street;
                    break;
                case "Hybrid":
                    map.MapType = MapType.Hybrid;
                    break;
            }
        }
    }
}

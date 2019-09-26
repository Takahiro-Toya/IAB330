using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace SnackRoulette.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapView : ContentPage
    {
        Xamarin.Forms.Maps.Map map;
        public MapView()
        {
            InitializeComponent();
            map = new Xamarin.Forms.Maps.Map
        {
            HeightRequest = 100,
            WidthRequest = 960,
            VerticalOptions = LayoutOptions.FillAndExpand
        };



        //Starting region of the map, figure out how to set that to GPS

        // add the slider for adjusting search radius
        var slider = new Slider(1, 18, 1);
        slider.ValueChanged += (sender, e) => {

        };


        async void recalcClicked(object sender, EventArgs args)
        {
               
        }



            // constructing all above functions (Need to convert this into XML, I was lazy)
            var stack = new StackLayout { Spacing = 0 };
        stack.Children.Add(map);
        stack.Children.Add(slider);
        Content = stack;


 
    }

    }
}
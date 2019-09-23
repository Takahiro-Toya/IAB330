using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Diagnostics;
using Plugin.Permissions.Abstractions;
using Plugin.Geolocator;
using MapPage;
using System.Text;

namespace SnackRoulette
{
    public class MapPage : ContentPage
    {
        public void FindRestaurants(View v)
        {
            StringBuilder stringSearch = new StringBuilder("https://maps.googleapis.com/maps/api/place/nearbysearch?/xml?");
            stringSearch.Append("&radius =" + 1000);
            stringSearch.Append("&keyword=" + "restaurant");
            stringSearch.Append("&key="+ "AIzaSyB-ZzI-vRGNRgIkay97Cc42v5P_gxD_t5w");

            String search = stringSearch.ToString();
        }
    }
}

using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SnackRoulette.Views
{
    public partial class OrderScreen : ContentPage
    {
        async void Open_Map_Screen(object sender, System.EventArgs e)
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Location Required", "This app must use your location to find nearby restaurants", "OK");
                    }
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    var location = await Geolocation.GetLastKnownLocationAsync();

                    if (location != null)
                    {
                        double loc1 = location.Latitude;
                        double loc2 = location.Longitude;
                    }
                    await Navigation.PushAsync(new MapPage());
                }
                if (status == PermissionStatus.Granted)
                {
                    var location = await Geolocation.GetLastKnownLocationAsync();

                    if (location != null)
                    {
                        double loc1 = location.Latitude;
                        double loc2 = location.Longitude;
                    }
                    await Navigation.PushAsync(new MapPage());
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Cannot continue without Location enabled", "Ok");
                    
 
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.ToString(), "Ok");
            }
        }
        public OrderScreen()
        {
            InitializeComponent();
            budget_slider.Value = 30;
            radius_slider.Value = 2;
        }

        void HandlebBudget_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            budget_label.Text = String.Format("$: {0:F2}", e.NewValue);
        }

        void HandlebRadius_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            radius_label.Text = String.Format("{0:F0} km", e.NewValue);
        }

        void Open_Roulette_Screen(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RouletteScreen());
        }
    }
}

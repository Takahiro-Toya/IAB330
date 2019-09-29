using System;
using System.Collections.Generic;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SnackRoulette.Models;
using SnackRoulette.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SnackRoulette.Views
{
    public partial class OrderView : ContentPage
    {

        private Color themeColor = Color.FromHex("F95F62");

        // hold currently clicked button to change background color when new button is clicked
        private Button Prev_Selected_Button = new Button();
        private Button Prev_Selected_Button_Cuisine = new Button();

        // list of cuisines
        private List<string> cuisines = new List<string> {
            "French", "Greek", "Italian",
            "Spanish", "German", "Chinese",
            "Korean", "Japanese", "Indian",
            "Mexican", "Vietnamese", "Thai",
            "Singaporean", "Malaysian", "Steak",
            "Fish&Chips", "Hamburger", "Pizza",
            "Seafood", "Sushi", "I don't choose"
        };

        public OrderView(string email, AccountViewModel _facebookUserData)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            (BindingContext as OrderViewModel).userEmail = email;
            (BindingContext as OrderViewModel).facebookUserData = _facebookUserData;
            // by default, "inexpensive" is the default setting for budget
            budgetDefaultBtn.BackgroundColor = themeColor;
            budgetDefaultBtn.TextColor = Color.White;
            Prev_Selected_Button = budgetDefaultBtn;
            radius_slider.Value = 2; // default radius value (2km)
            setupCuisineView();
        }


         /// <summary>
         /// Layouts the cuisine button on the cuisine selectin view
         /// It's better to handle this here rather than .xaml as we may change types of cuisines or
         /// layout(number of columns or rows)in the future
         /// </summary>
        private void setupCuisineView()
        {
            int i = 0;
            // total five rows
            for (int r = 0; r < 7; ++r)
            {
                // 3 type per row
                for (int c = 0; c < 3; ++c)
                {
                    Button btn = new Button();
                    btn.Text = cuisines[i]; 
                    if (i == cuisines.Count - 1) // default setting
                    {
                        btn.TextColor = Color.White;
                        btn.BackgroundColor = themeColor;
                        Prev_Selected_Button_Cuisine = btn;
                    } else
                    {
                        i++;
                        btn.TextColor = themeColor;
                    }
                    btn.BorderColor = themeColor;
                    btn.BorderWidth = 1;
                    btn.Clicked += Cuisine_Changed;
                    Grid.SetRow(btn, r);
                    Grid.SetColumn(btn, c);
                    CuisineGrid.Children.Add(btn);
                }
            }
        }

         /// <summary>
         /// Called when cuisine button is clicked
         /// Tells OrderViewModel about this change, and
         /// change background color of new clicked button and previously clicked button
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        void Cuisine_Changed(object sender, EventArgs e)
        {
            Button newBtn = sender as Button;
            Prev_Selected_Button_Cuisine.TextColor = themeColor;
            Prev_Selected_Button_Cuisine.BackgroundColor = Color.FloralWhite;
            Prev_Selected_Button_Cuisine = newBtn;
            newBtn.TextColor = Color.White;
            newBtn.BackgroundColor = themeColor;
            (BindingContext as OrderViewModel).Cuisine = newBtn.Text;
        }

         /// <summary>
         /// Called when budget button is clicked
         /// Tells OrderViewModel about this change, and
         /// changes background color of the new clicked button and previously clicked button
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        void BudgetType_Changed(object sender, System.EventArgs e)
        {
            Button newBtn = sender as Button;
            Prev_Selected_Button.BackgroundColor = Color.White;
            Prev_Selected_Button.TextColor = themeColor;
            Prev_Selected_Button = newBtn;
            newBtn.BackgroundColor = themeColor;
            newBtn.TextColor = Color.White;
            (BindingContext as OrderViewModel).BudgetType = newBtn.Text;
        }

        /// <summary>
        /// The view to pick preferred cuisine will apper from bottom edge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void PreferredCuisineView(object sender, EventArgs e)
        {
            if (preferredCuisineView.IsVisible)
            {
                await preferredCuisineView.TranslateTo(0, preferredCuisineView.Height, 300);
                preferredCuisineView.IsVisible = !preferredCuisineView.IsVisible;
            }
            else
            {
                await preferredCuisineView.TranslateTo(0, preferredCuisineView.Height, 0);
                preferredCuisineView.IsVisible = !preferredCuisineView.IsVisible;
                await preferredCuisineView.TranslateTo(0, 0, 300);
            }
        }

        /// <summary>
        /// Called when radius' slider value is changed, and tells to OrderViewModel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            (BindingContext as OrderViewModel).Radius = value;
        }

        /// <summary>
        /// Called when number of guests picker value is changed, and tells to OrderViewModel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void onPickerValueChanged(object sender, ValueChangedEventArgs args)
        {
            int value = (int)args.NewValue;
            (BindingContext as OrderViewModel).NumGuests = value;
        }


        async void Location_Changed(object sender, System.EventArgs e)
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
                    var value = await Geolocation.GetLastKnownLocationAsync();

                    if (value != null)
                    {
                        double loc1 = value.Latitude;
                        double loc2 = value.Longitude;
                        (BindingContext as OrderViewModel).CoordinateLat = (value.Latitude);
                        (BindingContext as OrderViewModel).CoordinateLong = (value.Longitude);
                    };
                }
                if (status == PermissionStatus.Granted)
                {
                    var value = await Geolocation.GetLastKnownLocationAsync();

                    if (value != null)
                    {
                        double loc1 = value.Latitude;
                        double loc2 = value.Longitude;
                        (BindingContext as OrderViewModel).CoordinateLat = (value.Latitude);
                        (BindingContext as OrderViewModel).CoordinateLong = (value.Longitude);
                    }
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


    }
}

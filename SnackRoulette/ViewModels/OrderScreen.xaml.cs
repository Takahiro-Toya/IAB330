using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SnackRoulette.Views
{
    public partial class OrderScreen : ContentPage
    {
        void Open_Map_Screen(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MapPage());
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

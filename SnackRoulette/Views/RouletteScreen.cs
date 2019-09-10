using System;

using Xamarin.Forms;

namespace SnackRoulette.Views {
    public class RouletteScreen : ContentPage {
        public RouletteScreen()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}


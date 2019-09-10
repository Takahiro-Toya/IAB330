using System;

using Xamarin.Forms;

namespace SnackRoulette.ViewModels {
    public class OrderScreen : ContentPage {
        public OrderScreen()
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


using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SnackRoulette.Views
{
    public partial class LoginScreen : ContentPage
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        void Handle_Signup(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SignUpScreen());
        }

        void Handle_Submit(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new OrderScreen());
        }
    }
}

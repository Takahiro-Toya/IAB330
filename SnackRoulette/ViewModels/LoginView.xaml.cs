using System;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using SnackRoulette.Views;

namespace SnackRoulette.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
   
        }

        void Handle_Signup(object sender, System.EventArgs e)
        {
            var SignUpScreen = new SignUpView();
            
            Navigation.PushAsync(SignUpScreen);
        }

        void Handle_Submit(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new OrderView());
        }


    }
}

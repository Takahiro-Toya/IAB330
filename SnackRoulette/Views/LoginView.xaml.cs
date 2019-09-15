using System;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using SnackRoulette.Views;
using SnackRoulette.ViewModels;

namespace SnackRoulette.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();

            BindingContext = new LoginViewModel();
        }

        void Handle_Signup(object sender, System.EventArgs e)
        {

            var SignUpView = new SignUpView();

            Navigation.PushAsync(SignUpView);
        }

        void Handle_Submit(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new OrderView());
        }


    }
}

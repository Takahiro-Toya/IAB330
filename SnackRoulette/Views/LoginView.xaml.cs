using System;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using SnackRoulette.Views;
using SnackRoulette.ViewModels;
using SnackRoulette.Database;

namespace SnackRoulette.Views
{
    public partial class LoginView : ContentPage
    {
        UserDatabaseHelper userdatabase = new UserDatabaseHelper();

        public LoginView()
        {
            InitializeComponent();
            
            BindingContext = new LoginViewModel();
            
            email.ReturnCommand = new Command(() => password.Focus());
        }

        void Handle_Signup(object sender, System.EventArgs e)
        {

            var SignUpView = new SignUpView();

            Navigation.PushAsync(SignUpView);
        }

        private async void Handle_Login(object sender, System.EventArgs e)
        {
            if (email.Text != null && password.Text != null)
            {
                var isValid = userdatabase.LoginValidation(email.Text, password.Text);
                if (isValid)
                {
              
                    await Navigation.PushAsync(new OrderView(email.Text));
                }
                else
                {
                    await DisplayAlert("Login Failed", "Please Enter Correct Email Address and Password", "OK");
                }
            }
            else
            {
                await DisplayAlert("Login Failed", "Please Enter Your Email and Password", "OK");
            }
            
        }


    }
}

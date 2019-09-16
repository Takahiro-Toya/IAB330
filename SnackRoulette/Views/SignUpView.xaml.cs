using System;
using System.Collections.Generic;
using SnackRoulette.Models;
using SnackRoulette.Database;
using SnackRoulette.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnackRoulette.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpView : ContentPage
    {
        UserDatabaseHelper userdatabase = new UserDatabaseHelper();
        UserModel users = new UserModel();

        public SignUpView()
        {
            InitializeComponent();

            BindingContext = new SignUpViewModel();

            email.ReturnCommand = new Command(() => username.Focus());
            username.ReturnCommand = new Command(() => password.Focus());
            password.ReturnCommand = new Command(() => confirmPassword.Focus());
        }

        private async void Handle_Submit(object sender, System.EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(username.Text)) || (string.IsNullOrWhiteSpace(email.Text)) || (string.IsNullOrWhiteSpace(password.Text)) ||
                (string.IsNullOrEmpty(username.Text)) ||(string.IsNullOrEmpty(email.Text)) || (string.IsNullOrEmpty(password.Text)))
            {
                await DisplayAlert("Alert", "Please Enter Your Email, Username And Password", "OK");
            }
            else if (!string.Equals(password.Text, confirmPassword.Text))
            {
                password.Text = string.Empty;
                confirmPassword.Text = string.Empty;
            }
            else
            {
                users.email = email.Text;
                users.userName = username.Text;
                users.password = password.Text;

                var val = userdatabase.AddUser(users);
                if (val == "Successful")
                {
                    await DisplayAlert("Alert", "Successful", "OK");
                    await Navigation.PushAsync(new LoginView());
                }
                else
                {
                    await DisplayAlert("Alert", "That Email Address is Taken", "OK");
                    email.Text = string.Empty;
                    username.Text = string.Empty;
                    password.Text = string.Empty;
                    confirmPassword.Text = string.Empty;
                }
            }
        }

        



    }
}

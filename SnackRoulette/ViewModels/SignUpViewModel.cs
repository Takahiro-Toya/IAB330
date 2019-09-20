using System;
using Xamarin.Forms;
using SnackRoulette.Services;
using SnackRoulette.Database;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SnackRoulette.Models;
using System.Text.RegularExpressions;

namespace SnackRoulette.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        public SignUpViewModel()
        {
            LoginViewCommand = new Command(async () => await SignUpValidation());
        }

        UserDatabaseHelper userdatabase = new UserDatabaseHelper();
        UserModel users = new UserModel();

        string title = "SnackRoulette";
        string username = String.Empty;
        string email = String.Empty;
        string password = String.Empty;
        string confirmPassword = String.Empty;
        string emailPattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                OnPropertyChanged();
            }
        }

        public Command LoginViewCommand { get; set; }

        async Task SignUpValidation()
        {

            if ((string.IsNullOrWhiteSpace(username)) || (string.IsNullOrWhiteSpace(email)) || (string.IsNullOrWhiteSpace(password)) ||
                (string.IsNullOrEmpty(username)) || (string.IsNullOrEmpty(email)) || (string.IsNullOrEmpty(password)))
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Please Enter Your Email, Username And Password", "OK");
            }
            else if (!Regex.IsMatch(email, emailPattern))
            {
                email = string.Empty;
                OnPropertyChanged(nameof(Email));
                await Application.Current.MainPage.DisplayAlert("Sign Up Failed", "Email is not valid", "OK");
            }
            else if (!string.Equals(password, confirmPassword))
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Password and Confirm Password are not the same", "OK");
                password = string.Empty;
                confirmPassword = string.Empty;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(ConfirmPassword));

            }
            else
            {
                users.email = email;
                users.userName = username;
                users.password = password;

                var val = userdatabase.AddUser(users);
                if (val == "Successful")
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", "Successful", "OK");
                    await NavigationService.PushNextView(ViewType.LoginView, "");
                }
                else
                {
                    email = string.Empty;
                    username = string.Empty;
                    password = string.Empty;
                    confirmPassword = string.Empty;
                    OnPropertyChanged(nameof(Email));
                    OnPropertyChanged(nameof(Username));
                    OnPropertyChanged(nameof(Password));
                    OnPropertyChanged(nameof(ConfirmPassword));
                    await Application.Current.MainPage.DisplayAlert("Alert", "That Email Address is Taken", "OK");
                }
            }

        }
    }
}

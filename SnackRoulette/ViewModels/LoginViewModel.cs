using System;
using Xamarin.Forms;
using SnackRoulette.Services;
using SnackRoulette.Database;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Plugin.FacebookClient.Abstractions;
using Plugin.FacebookClient;
using Newtonsoft.Json;
using SnackRoulette.Models;

namespace SnackRoulette.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public LoginViewModel()
        {
            SignUpViewCommand = new Command(async () => await NavigationService.PushNextView(ViewType.SignUpView, "", ""));
            OrderViewCommand = new Command(async () => await LoginValidation());
            LoginWithFacebookCommand = new Command(async () => await LoginWithFacebookValidation());
        }

        UserDatabaseHelper userdatabase = new UserDatabaseHelper();
        IFacebookClient fbService = CrossFacebookClient.Current;

        public string title = "SnackRoulette";
        string password = "";
        string email = "";

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Email
        {
            get
            { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get
            { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public Command SignUpViewCommand { get; set; }

        public Command OrderViewCommand { get; set; }

        public Command LoginWithFacebookCommand { get; set; }

        async Task LoginValidation()
        {

            if (email != "" && password != "")
            {
                var isValid = userdatabase.LoginValidation(email, password);
                if (isValid)
                {
                    var _facebookUserModel = new AccountViewModel();
                    await NavigationService.PushNextView(ViewType.OrderView, email, _facebookUserModel);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Login Failed", "Please Enter Correct Email Address or Password", "OK");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed", "Please Enter Your Email and Password", "OK");
            }

        }

        async Task LoginWithFacebookValidation()
        {
            EventHandler<FBEventArgs<string>> facebookUserdata = null;

            facebookUserdata = async (object sender, FBEventArgs<string> args) =>
            {
                if (args == null)
                {
                    return;
                }

                switch (args.Status)
                {
                    case FacebookActionStatus.Canceled:
                        break;

                    case FacebookActionStatus.Completed:
                        var facebookData = await Task.Run(() => JsonConvert.DeserializeObject<FacebookUserModel>(args.Data));
                        var _facebookUserModel = new AccountViewModel
                        {
                            Email = facebookData.Email,
                            Username = $"{facebookData.FirstName} {facebookData.LastName}",
                        };
                        await NavigationService.PushNextView(ViewType.OrderView, "", _facebookUserModel);
                        break;
                }
                fbService.OnUserData -= facebookUserdata;
            };
            fbService.OnUserData += facebookUserdata;
            string[] FacebookRequestFields = { "email", "first_name", "last_name" };
            string[] FacebookPermisions = { "email" };
            await fbService.RequestUserDataAsync(FacebookRequestFields, FacebookPermisions);
        }
    }
}

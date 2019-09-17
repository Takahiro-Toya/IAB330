using System;
using Xamarin.Forms;
using SnackRoulette.Services;
using SnackRoulette.Database;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SnackRoulette.ViewModels
{
    public class LoginViewModel: INotifyPropertyChanged
    {

        public LoginViewModel()
        {
            SignUpViewCommand = new Command(async () => await NavigationService.PushNextView(ViewType.SignUpView, ""));
            OrderViewCommand = new Command(async () => await LoginValidation());
        }
        UserDatabaseHelper userdatabase = new UserDatabaseHelper();
        public event PropertyChangedEventHandler PropertyChanged;
        public string title = "SnackRoulette";
        string password = "";
        string email = "";

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public Command SignUpViewCommand { get; set; }

        public Command OrderViewCommand { get; set; }

        async Task LoginValidation()
        {

            if (email != "" && password != "")
            {
                var isValid = userdatabase.LoginValidation(email, password);
                if (isValid)
                {

                    NavigationService.PushNextView(ViewType.OrderView, "");
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
        

    }
}

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SnackRoulette.Views;

namespace SnackRoulette {
    public partial class App : Application {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new LoginScreen());
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("F95F62");
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

using System;
using System.Collections.Generic;
using SnackRoulette.Database;
using SnackRoulette.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace SnackRoulette.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountView : ContentPage
    {
        UserDatabaseHelper userdatabase = new UserDatabaseHelper();
        public AccountView(string email, AccountViewModel facebookUserData)
        {
            InitializeComponent();
            BindingContext = facebookUserData;
            oneuser.Text = email;
        }
    }
}

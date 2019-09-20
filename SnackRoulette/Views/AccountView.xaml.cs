using System;
using System.Collections.Generic;
using SnackRoulette.Database;
using SnackRoulette.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace SnackRoulette.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountView : ContentPage
    {
        UserDatabaseHelper userdatabase = new UserDatabaseHelper();
        public AccountView(string email)
        {
            InitializeComponent();
            //var Data = userdatabase.GetAllUsers();
            //user.ItemsSource = Data;

            var data2 = userdatabase.GetUser(email);
            oneuser.Text = email; 
        }
    }
}

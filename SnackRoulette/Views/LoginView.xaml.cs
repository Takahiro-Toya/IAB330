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
            
            //email.ReturnCommand = new Command(() => password.Focus());
        }


    }
}

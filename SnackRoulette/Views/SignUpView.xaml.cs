using System;
using System.Collections.Generic;
using SnackRoulette.ViewModels;
using Xamarin.Forms;

namespace SnackRoulette.Views
{
    public partial class SignUpView : ContentPage
    {
        public SignUpView()
        {
            InitializeComponent();

            BindingContext = new SignUpViewModel();
        }

        void Handle_Submit(object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new OrderScreen());
        }



    }
}

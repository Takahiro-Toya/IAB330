using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SnackRoulette.Views
{
    public partial class SignUpScreen : ContentPage
    {
        public SignUpScreen()
        {
            InitializeComponent();
        }

        public string FullName
        {
            get { return FullName; }
            set { FullName = value; }
        }

        public string Email
        {
            get { return Email; }
            set { Email = value; }
        }

        public string Password
        {
            get { return Password; }
            set { Password = value; }
        }

        public string Confirm
        {
            get { return Confirm; }
            set { Confirm = value; }
        }

        void Handle_Submit(object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new OrderScreen());
        }



    }
}

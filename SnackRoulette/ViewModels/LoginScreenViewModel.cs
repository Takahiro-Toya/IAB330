using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace SnackRoulette.ViewModels
{
    public class LoginScreenViewModel
    {
        public string title = "SnackRoulette";

        public LoginScreenViewModel()
        {

        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    }
}

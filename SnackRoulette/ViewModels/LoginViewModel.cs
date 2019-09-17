using System;
namespace SnackRoulette.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        public LoginViewModel()
        {
        }

        public string title = "SnackRoulette";

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    }
}

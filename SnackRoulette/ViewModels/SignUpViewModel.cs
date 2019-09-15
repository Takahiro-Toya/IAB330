using System;
namespace SnackRoulette.ViewModels
{
    public class SignUpViewModel
    {
        public SignUpViewModel()
        {
        }

        public string title = "SnackRoulette";

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        //public string FullName
        //{
        //    get { return FullName; }
        //    set { FullName = value; }
        //}

        //public string Email
        //{
        //    get { return Email; }
        //    set { Email = value; }
        //}

        //public string Password
        //{
        //    get { return Password; }
        //    set { Password = value; }
        //}

        //public string Confirm
        //{
        //    get { return Confirm; }
        //    set { Confirm = value; }
        //}
    }
}

using System;
using SnackRoulette.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnackRoulette.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpView : ContentPage
    {

        public SignUpView()
        {
            InitializeComponent();

            BindingContext = new SignUpViewModel();
        }

    }
}

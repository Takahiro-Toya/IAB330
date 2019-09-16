using System;
using System.Collections.Generic;
using SnackRoulette.Models;
using Xamarin.Forms;

namespace SnackRoulette.Views {
    public partial class OrderView : ContentPage {

        private Button Prev_Selected_Button = new Button();
        string user_email;
        public OrderView(string email)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            user_email = email;
            Inexpensive_Button.BackgroundColor = Color.FromHex("F95F62");
            Inexpensive_Button.TextColor = Color.White;
            Prev_Selected_Button = Inexpensive_Button;
            radius_slider.Value = 2; 
        }

        void BudgetType_Changed(object sender, System.EventArgs e) {
            Prev_Selected_Button.BackgroundColor = Color.White;
            Prev_Selected_Button.TextColor = Color.FromHex("F95F62");
            (sender as Button).BackgroundColor = Color.FromHex("F95F62");
            (sender as Button).TextColor = Color.White;
            Prev_Selected_Button = sender as Button;
            Budget_label.Text = (sender as Button).Text;
            //switch ((sender as Button).Text) {
            //    case "Inexpensive":
            //        Budget = OrderModel.BudgetType.Inexpensive;
            //        break;
            //    case "Moderate":
            //        Budget = OrderModel.BudgetType.Moderate;
            //        break;
            //    case "Expensive":
            //        Budget = OrderModel.BudgetType.Expensive;
            //        break;
            //    case "Very Expensive":
            //        Budget = OrderModel.BudgetType.VeryExpensive;
            //        break;
            //    default:
            //        Budget = OrderModel.BudgetType.Inexpensive;
            //        break;
            //}
        }

        //void Radius_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        //{
        //    //Radius = e.NewValue;
        //    radius_label.Text = String.Format("{0:F0} km", e.NewValue);
        //}

        void OpenPreferredCuisineView(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PreferredCuisineView());
        }

        void OpenMapView(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MapView());
        }

        void OpenRouletteView(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RouletteView());
        }

        void AccountView_OnClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AccountView(user_email));
        }
    }


}

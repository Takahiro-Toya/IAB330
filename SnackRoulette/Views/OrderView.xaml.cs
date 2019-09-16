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
            defaultBtn.BackgroundColor = Color.FromHex("F95F62");
            defaultBtn.TextColor = Color.White;
            Prev_Selected_Button = defaultBtn;
            radius_slider.Value = 2; 
        }

        void BudgetType_Changed(object sender, System.EventArgs e) {
            Button newBtn = sender as Button;
            Prev_Selected_Button.BackgroundColor = Color.White;
            Prev_Selected_Button.TextColor = Color.FromHex("F95F62");
            Prev_Selected_Button = newBtn;
            newBtn.BackgroundColor = Color.FromHex("F95F62");
            newBtn.TextColor = Color.White;
            Budget_label.Text = newBtn.Text;
        }

        void AccountView_OnClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AccountView(user_email));
        }
    }


}

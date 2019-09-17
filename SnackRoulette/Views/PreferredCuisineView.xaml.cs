using System;
using System.Collections.Generic;
using SnackRoulette.ViewModels;
using SnackRoulette.Views;
using Xamarin.Forms;

namespace SnackRoulette.Views {
    public partial class PreferredCuisineView : ContentPage {

        private Button prevSelectedButton = new Button();

        private List<string> cuisines = new List<string> {
            "French", "Greek", "Italian",
            "Spanish", "German", "Chinese",
            "Korean", "Japanese", "Indian",
            "Mexican", "Vietnamese", "Thai",
            "Singaporean", "Malaysian", "Steak",
            "Fish&Chips", "Hamburger", "Pizza",
            "Seafood", "Sushi", "I don't choose"
        };

        public PreferredCuisineView()
        {
            InitializeComponent();
            setupButtons();
        }

        private void setupButtons(){
            int i = 0;
            // total five rows
            for(int r=0; r<7; ++r) 
            {
                // 3 type per row
                for(int c=0; c<3; ++c) 
                {
                    Button btn = new Button();
                    btn.Text = cuisines[i];
                    i++;
                    btn.TextColor = Color.FromHex("F95F62");
                    btn.BorderColor = Color.FromHex("F95F62");
                    btn.BorderWidth = 1;
                    btn.Clicked += ButtonClicked;
                    Grid.SetRow(btn, r);
                    Grid.SetColumn(btn, c);
                    CuisineGrid.Children.Add(btn);
                }
            }
        }

        /*
         * changes button color to indicate that the button is currenly selected
         */
        public void ButtonClicked(object sender, EventArgs e)
        {   
            Button newBtn = sender as Button;
            prevSelectedButton.TextColor = Color.FromHex("F95F62");
            prevSelectedButton.BackgroundColor = Color.White;
            prevSelectedButton = newBtn;
            newBtn.TextColor = Color.White;
            newBtn.BackgroundColor = Color.FromHex("F95F62");
            ((OrderViewModel)BindingContext).setCuisine(newBtn.Text);
        }
    }
}

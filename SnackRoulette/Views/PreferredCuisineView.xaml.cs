using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SnackRoulette.Views {
    public partial class PreferredCuisineView : ContentPage {

        private Button prevSelectedButton = new Button();

        private List<string> cuisines = new List<string> {
            "Chinese", "Japanese", "Italian",
            "Indian", "French", "Mexican",
            "Thai", "Malaysian", "Greek",
            "Spanish", "Hamburger", "Pizza",
            "Seafood", "Sushi", "Fish&Chips"
        };

        public PreferredCuisineView()
        {
            InitializeComponent();
            setupButton();
        }

        private void setupButton(){
            int i = 0;
            for(int r=0; r<5; ++r) 
            {
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

        public void ButtonClicked(object sender, EventArgs e)
        {
            Button newBtn = sender as Button;

            prevSelectedButton.TextColor = Color.FromHex("F95F62");
            prevSelectedButton.BackgroundColor = Color.White;
            prevSelectedButton = newBtn;
            newBtn.TextColor = Color.White;
            newBtn.BackgroundColor = Color.FromHex("F95F62");
            
        }
    }
}

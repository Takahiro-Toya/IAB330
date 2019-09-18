using System;
using System.Collections.Generic;
using SnackRoulette.Models;
using SnackRoulette.ViewModels;
using Xamarin.Forms;

namespace SnackRoulette.Views {
    public partial class OrderView : ContentPage {

        private Button Prev_Selected_Button = new Button();
		private Button Prev_Selected_Button_Cuisine = new Button();

		private List<string> cuisines = new List<string> {
			"French", "Greek", "Italian",
			"Spanish", "German", "Chinese",
			"Korean", "Japanese", "Indian",
			"Mexican", "Vietnamese", "Thai",
			"Singaporean", "Malaysian", "Steak",
			"Fish&Chips", "Hamburger", "Pizza",
			"Seafood", "Sushi", "I don't choose"
		};

		public OrderView(string email)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            (BindingContext as OrderViewModel).userEmail = email;
            defaultBtn.BackgroundColor = Color.FromHex("F95F62");
            defaultBtn.TextColor = Color.White;
            Prev_Selected_Button = defaultBtn;
            radius_slider.Value = 2;
			setupCuisineView();
        }

		private void setupCuisineView()
		{
			int i = 0;
			// total five rows
			for (int r = 0; r < 7; ++r)
			{
				// 3 type per row
				for (int c = 0; c < 3; ++c)
				{
					Button btn = new Button();
					btn.Text = cuisines[i];
					i++;
					btn.TextColor = Color.FromHex("F95F62");
					btn.BorderColor = Color.FromHex("F95F62");
					btn.BorderWidth = 1;
					btn.Clicked += Cuisine_Changed;
					Grid.SetRow(btn, r);
					Grid.SetColumn(btn, c);
					CuisineGrid.Children.Add(btn);
				}
			}
		}

		void Cuisine_Changed(object sender, EventArgs e)
		{
			Button newBtn = sender as Button;
			Prev_Selected_Button_Cuisine.TextColor = Color.FromHex("F95F62");
			Prev_Selected_Button_Cuisine.BackgroundColor = Color.FloralWhite;
			Prev_Selected_Button_Cuisine = newBtn;
			newBtn.TextColor = Color.White;
			newBtn.BackgroundColor = Color.FromHex("F95F62");
			(BindingContext as OrderViewModel).Cuisine = newBtn.Text;
		}

		void BudgetType_Changed(object sender, System.EventArgs e) {
            Button newBtn = sender as Button;
            Prev_Selected_Button.BackgroundColor = Color.White;
            Prev_Selected_Button.TextColor = Color.FromHex("F95F62");
            Prev_Selected_Button = newBtn;
            newBtn.BackgroundColor = Color.FromHex("F95F62");
            newBtn.TextColor = Color.White;
            (BindingContext as OrderViewModel).BudgetType = newBtn.Text;
        }

        async void PreferredCuisineView(object sender, EventArgs e)
        {
			if (flyout.IsVisible)
			{
				await flyout.TranslateTo(0, flyout.Height, 300);
				flyout.IsVisible = !flyout.IsVisible;
			}
			else
			{
				await flyout.TranslateTo(0, flyout.Height, 0);
				flyout.IsVisible = !flyout.IsVisible;
				await flyout.TranslateTo(0, 0, 300);
			}
        }



        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            (BindingContext as OrderViewModel).Radius = value;
        }

        void onPickerValueChanged(object sender, ValueChangedEventArgs args)
        {
            int value = (int)args.NewValue;
            (BindingContext as OrderViewModel).NumMeals = value;
        }

    }
}

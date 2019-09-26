using System;
using SnackRoulette.Models;
using System.ComponentModel;
using SnackRoulette.Services;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace SnackRoulette.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {

        private string cuisine = "I don't choose";
        public string Cuisine
        {
            get { return cuisine; }
            set
            {
                cuisine = value;
                OnPropertyChanged("Cuisine");
            }
        }

        private double radius = 0.1;
        public double Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                OnPropertyChanged("Radius");
            }
        }

        private string budgetType = "Inexpensive";
        public string BudgetType
        {
            get { return budgetType; }
            set
            {
                budgetType = value;
                OnPropertyChanged("BudgetType");
            }
        }

        public int NumGuests { get; set; } = 1;


        public string userEmail { get; set; }

        public AccountViewModel facebookUserData { get; set; }

        public Command RouletteViewCommand { get; set; }
        public Command MapViewCommand { get; set; }
        public Command AccountViewCommand { get; set; }

        public OrderViewModel()
        {
            RouletteViewCommand = new Command(async () => await NavigationService.PushNextView(ViewType.RouletteView, DidConfirmOrderRequirements(), facebookUserData));
            MapViewCommand = new Command(async () => await NavigationService.PushNextView(ViewType.MapView,DidConfirmOrderRequirements(), facebookUserData));
            AccountViewCommand = new Command(async () => await NavigationService.PushNextView(ViewType.AccountView, userEmail, facebookUserData));
        }

        public OrderModel DidConfirmOrderRequirements()
        {
            int budget;
            switch (BudgetType)
            {
                case "Inexpensive":
                    budget = 1;
                    break;
                case "Moderate":
                    budget = 2;
                    break;
                case "Little expensive":
                    budget = 3;
                    break;
                case "Expensive":
                    budget = 4;
                    break;
                default:
                    budget = 1;
                    break;
            }
            string cuisineC;
            if (Cuisine == "I don't choose") { cuisineC = ""; }
            else { cuisineC = Cuisine; }
            return new OrderModel(cuisineC, Radius, budget, NumGuests);
        }

    }
}

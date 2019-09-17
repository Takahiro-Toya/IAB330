using System;
using SnackRoulette.Models;
using System.ComponentModel;
using SnackRoulette.Services;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace SnackRoulette.ViewModels {
    public class OrderViewModel : BaseViewModel  {

        public string Cuisine { get; set; }

        private double radius = 0.1;
        public double Radius
        {
            get { return radius; }
            set { radius = value;
                OnPropertyChanged("Radius");
            }
        }

        private string budgetType = "Inexpensive";
        public string BudgetType
        {
            get { return budgetType; }
            set { budgetType = value;
                OnPropertyChanged("BudgetType");
            }
        }

        public int NumMeals { get; set; } = 1;
        

        public string userEmail { get; set; }

        public Command RouletteViewCommand { get; set; }
        public Command MapViewCommand { get; set; }
        public Command PreferredCuisineViewCommand { get; set; }
        public Command CloseCuisineViewCommand { get; set;}
        //public Command AccountViewCommand { get; set; }

        public OrderViewModel()
        {
            BudgetType = "Inexpensive";
            RouletteViewCommand = new Command(async () => await NavigationService.PushNextView(ViewType.RouletteView, ""));
            MapViewCommand = new Command(async () => await NavigationService.PushNextView(ViewType.MapView, ""));
            PreferredCuisineViewCommand = new Command(async () => await NavigationService.ModelPushNextView(ViewType.PreferredCuisineView, ""));
            CloseCuisineViewCommand = new Command(async() => await NavigationService.navigation.PopModalAsync(true));
            //AccountViewCommand = new Command(async () => await NavigationService.PushNextView(ViewType.AccountView, userEmail));
        }

        public OrderModel DidConfirmOrderRequirement()
        {

            return new OrderModel(Cuisine, Radius, BudgetType, NumMeals);
        } 

    }
}

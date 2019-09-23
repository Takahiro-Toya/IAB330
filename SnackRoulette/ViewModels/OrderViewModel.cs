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
            MapViewCommand = new Command(async () => await NavigationService.PushNextView(ViewType.MapView, "", facebookUserData));
            AccountViewCommand = new Command(async () => await NavigationService.PushNextView(ViewType.AccountView, userEmail, facebookUserData));
        }

        public OrderModel DidConfirmOrderRequirements()
        {
            return new OrderModel(Cuisine, Radius, BudgetType, NumGuests);
        }

    }
}

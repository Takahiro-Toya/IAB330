using System;
using SnackRoulette.Models;
using System.ComponentModel;
using SnackRoulette.Services;
using Xamarin.Forms;

namespace SnackRoulette.ViewModels {
    public class OrderViewModel : BaseViewModel {

        public string Cuisine { get; set; }
        public double Radius { get; set; }
        public OrderModel.BudgetType BudgetType {get; set;}
        public string BudgetType_String { get; set; }

        public Command RouletteViewCommand { get; set; }
        public Command MapViewCommand { get; set; }
        public Command PreferredCuisineViewCommand { get; set; }

        public OrderViewModel()
        {
            RouletteViewCommand = new Command(async () => await NavigationService.PushNextView(ViewType.RouletteView, ""));
            MapViewCommand = new Command(async () => await NavigationService.PushNextView(ViewType.MapView, ""));
            PreferredCuisineViewCommand = new Command(async () => await NavigationService.PushNextView(ViewType.PreferredCuisineView, ""));
        }

        public void RadiusValueChanged(double newValue)
        {
            Radius = newValue;
        }

        public OrderModel DidConfirmOrderRequirement()
        {
            return new OrderModel(Cuisine, Radius, BudgetType);
        } 

    }
}

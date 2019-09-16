using System;
using SnackRoulette.Models;
using System.ComponentModel;
using Xamarin.Forms;

namespace SnackRoulette.ViewModels {
    public class OrderViewModel: BaseViewModel {

        public string Cuisine;
        public double Radius{
            get { return Radius; }
            set { Radius = value;
                Radius_String = String.Format("{0:F0} km", value); }
            }
        public string Radius_String;
        public OrderModel.BudgetType BudgetType;
        public string BudgetType_String;


        public OrderViewModel()
        {
            
        }

        public OrderModel DidConfirmOrderRequirement() {
            return new OrderModel(Cuisine, Radius, BudgetType);
        }

 

    }
}

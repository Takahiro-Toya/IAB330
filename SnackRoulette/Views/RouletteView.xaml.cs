using System;
using SnackRoulette.Models;
using SnackRoulette.ViewModels;
using Xamarin.Forms;

namespace SnackRoulette.Views
{
    public partial class RouletteView : ContentPage
    {
        public RouletteView(OrderModel order)
        {
            InitializeComponent();
            (BindingContext as RouletteViewModel).Order = order;
        }
    }
}

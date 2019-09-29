using System;
using SnackRoulette.Models;
using SnackRoulette.ViewModels;
using Xamarin.Forms;

namespace SnackRoulette.Views
{
    public partial class MapView : ContentPage
    {
        public MapView(/*RouletteView order*/)
        {
            InitializeComponent();
            //(BindingContext as MapViewModel).Order = order;

        }
    }
}

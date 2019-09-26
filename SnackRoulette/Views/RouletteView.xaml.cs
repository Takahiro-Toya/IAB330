using System;
using System.Collections.Generic;
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

        

        async void DetailView(object sender, EventArgs e)
        {
			if (detailView.IsVisible)
			{
				await detailView.TranslateTo(0, detailView.Height, 300);
				detailView.IsVisible = !detailView.IsVisible;
			}
			else
			{
				await detailView.TranslateTo(0, detailView.Height, 0);
				detailView.IsVisible = !detailView.IsVisible;
				await detailView.TranslateTo(0, 0, 300);
			}
        }
    }
}

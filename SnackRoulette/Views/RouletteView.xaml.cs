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

        

   //     async void DetailView(object sender, EventArgs e)
   //     {
			//if ((BindingContext as RouletteViewModel).DetailVisible)
			//{
			//	await detailView.TranslateTo(0, detailView.Height, 300);
   //             detailView.IsVisible = false;
   //             (BindingContext as RouletteViewModel).DetailVisible = false;

   //         }
			//else
			//{
			//	await detailView.TranslateTo(0, detailView.Height, 0);
   //             detailView.IsVisible = true;
   //             (BindingContext as RouletteViewModel).DetailVisible = true;
			//	await detailView.TranslateTo(0, 0, 300);
			//}
   //     }
    }
}

using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SnackRoulette.Views;
using SnackRoulette.Models;
using System.Threading.Tasks;
using SnackRoulette.ViewModels;

namespace SnackRoulette.Services
{

    public enum ViewType
    {
        AccountView,
        LoginView,
        MapView,
        OrderView,
        RouletteView,
        SignUpView
    }

    public static class NavigationService
    {

        public static INavigation navigation { get; set; }

        public static Dictionary<string, Page> pageMap = new Dictionary<string, Page>();

        /*
         * create page 
         */
        private static Page getPage(ViewType keyForView, object constructorParameter, object secondConstructorParameter)
        {
            switch (keyForView)
            {
                case ViewType.AccountView:
                    return new AccountView((string)constructorParameter, secondConstructorParameter as AccountViewModel);
                case ViewType.LoginView:
                    return new LoginView();
                case ViewType.MapView:
                    return new MapView();
                case ViewType.OrderView:
                    return new OrderView((string)constructorParameter, secondConstructorParameter as AccountViewModel);
                case ViewType.RouletteView:
                    return new RouletteView(constructorParameter as OrderModel);
                case ViewType.SignUpView:
                    return new SignUpView();
                default:
                    return new LoginView();
            }
        }



        /*
         * Call this function in ViewModel class to push next page
         * 
         *  e.g.
         *      // in .xaml 
         *          Command="{Binding command}"
         *      // in view model
         *          Command command;
         *          command = new Command(async () => await NavigationService.PushNextView(ViewType.LoginView, ""));
         */
        public static Task PushNextView(ViewType keyForView, object constructorParameter, object constructorSecondParameter)
        {
            return navigation.PushAsync(getPage(keyForView, constructorParameter, constructorSecondParameter));
        }

        /*
         * The page will appear from bottom
         *
         * call navigation.PopModalAsync() to remove
         */
        public static Task ModelPushNextView(ViewType keyForView, object constructorParameter, object constructorSecondParameter)
        {
            return navigation.PushModalAsync(getPage(keyForView, constructorParameter, constructorSecondParameter));
        }

    }
}

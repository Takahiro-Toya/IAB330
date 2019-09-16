using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SnackRoulette.Views;
using System.Threading.Tasks;

namespace SnackRoulette.Services {

    public enum ViewType {
        AccountView,
        LoginView,
        MapView,
        OrderView,
        PreferredCuisineView,
        RouletteView,
        SignUpView
    }

    public static class NavigationService {

        public static INavigation navigation { get; set; }

        public static Dictionary<string, Page> pageMap = new Dictionary<string, Page>();

        /*
         * create page 
         */
        private static Page getPage(ViewType keyForView, string constructorParameter = "")
        {
            switch (keyForView)
            {
                case ViewType.AccountView:
                    return new AccountView(constructorParameter);
                case ViewType.LoginView:
                    return new LoginView();
                case ViewType.MapView:
                    return new MapView();
                case ViewType.OrderView:
                    return new OrderView(constructorParameter);
                case ViewType.PreferredCuisineView:
                    return new PreferredCuisineView();
                case ViewType.RouletteView:
                    return new RouletteView();
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
        public static Task PushNextView(ViewType keyForView, string constructorParameter = "")
        {
            return navigation.PushAsync(getPage(keyForView, constructorParameter));
        }

    }
}

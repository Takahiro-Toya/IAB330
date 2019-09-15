using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace SnackRoulette.ViewModels {
    public class BaseViewModel: INotifyPropertyChanged {

        INavigation navigation;

        public BaseViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}

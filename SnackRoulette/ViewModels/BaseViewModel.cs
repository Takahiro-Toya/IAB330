using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace SnackRoulette.ViewModels {
    public class BaseViewModel: INotifyPropertyChanged {

      

        public BaseViewModel()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}

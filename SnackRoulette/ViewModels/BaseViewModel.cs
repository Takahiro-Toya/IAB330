using System;
using System.ComponentModel;
using Xamarin.Forms;

using System.Collections.Generic;
using System.Runtime.CompilerServices;

using SnackRoulette.Models;
using SnackRoulette.Services;
using System.Threading.Tasks;

namespace SnackRoulette.ViewModels {
    public class BaseViewModel: INotifyPropertyChanged {
        private bool isBusy;
        public bool IsBusy { get { return isBusy; } set { isBusy = value;
                OnPropertyChanged();
            } }
        public BaseViewModel()
        {
            
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}

using System;
using SnackRoulette.Models;

namespace SnackRoulette.ViewModels {
    public class RouletteViewModel: BaseViewModel {

        public OrderModel order
        {
            get { return order; }
            set { order = value;
                  rouletteModel = new RouletteModel(order);
            }
        }

        private RouletteModel rModel;
        public RouletteModel rouletteModel
        {
            get { return rModel; }
            set { rModel = value;
                OnPropertyChanged("rouletteModel");
            }
        }

        public RouletteViewModel()
        {

        }
    }
}

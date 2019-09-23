using System;
using SnackRoulette.Models;
using System.Collections.Generic;

namespace SnackRoulette.ViewModels {
    public class RouletteViewModel: BaseViewModel {

        private PlaceSearchModel model = new PlaceSearchModel();
        private List<Place> places
        {
            set
            {
                if (value.Count >= 1)
                {
                    ResName = value[0].Name;
                } else
                {
                    ResName = "Not found";
                }
             
            }
        }

        public OrderModel Order = null;

        private string resName = "restaurantName";
        public string ResName
        {
            get { return resName; }
            set
            {
                resName = value;
                OnPropertyChanged("ResName");
            }
        }

        private string description = "description";
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        private string address = "address";
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private string phoneNr = "phoneNumber";
        public string PhoneNr
        {
            get { return phoneNr; }
            set
            {
                phoneNr = value;
                OnPropertyChanged("PhoneNr");
            }
        }

        private string price = "0.0";
        public string Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public void search()
        {
            if (Order != null)
            {
                places = model.getPlacesDataForOrder(Order);
            }

        }

    }
}

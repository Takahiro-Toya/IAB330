using System;
using SnackRoulette.Models;
using System.Collections.Generic;

namespace SnackRoulette.ViewModels {
    public class RouletteViewModel: BaseViewModel {

        private PlaceSearchModel model = new PlaceSearchModel(); 
        private Place place
        {
            set
            {
                if (value != null)
                {
                    Detail detail = PlaceApi.GetDetails(value.PlaceId).Result;
                    ResName = detail.Name;
                    Description = Order.Cuisine;
                    PhoneNr = detail.Phone;
                    Address = detail.Address;
                    Price = getPriceType(Order.Budget);
                } else
                {
                    ResName = "Restaurant Not found";
                    Description = "";
                    Address = "";
                    PhoneNr = "";
                    Price = "";
                }
             
            }
        }

        /*
         * Converts price level (0 ~ 4) to meaningful name
         */
        private string getPriceType(int price)
        {
            switch (price)
            {
                case 0:
                    return "Free";
                case 1:
                    return "inexpensive";
                case 2:
                    return "moderate";
                case 3:
                    return "little expensive";
                case 4:
                    return "expensive";
                default:
                    return getPriceType(Order.Budget); // this is so bad
            }
        }

        public OrderModel Order = null; // set before start searching restaurant

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

        private string price = "inexpensive";
        public string Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }



        /*
         * Start searching restaurants with given order requirement
         */
        public void search()
        {
            if (Order != null)
            {
                place = model.getRandomPlace(Order);
            }

        }

    }
}

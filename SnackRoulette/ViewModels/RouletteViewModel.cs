using System;
using SnackRoulette.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SnackRoulette.ViewModels {
    public class RouletteViewModel: BaseViewModel {

        public ICommand StartRouletteCommand { get; private set; }
        public ICommand DetailViewCloseCommand { get; private set; }

        private RouletteModel model = new RouletteModel();
        public RouletteViewModel()
        {
            StartRouletteCommand= new Command(async () => {
                await search();
            });
        }

        private Detail placeDetail
        {
            set
            {
                if (value != null)
                {
                    ResName = value.Name;
                    Description = Order.Cuisine;
                    PhoneNr = value.Phone;
                    Address = value.Address;
                    Price = getPriceType(Order.Budget);
                } else
                {
                    ResName = "Restaurant Not Found";
                    Description = "";
                    PhoneNr = "";
                    Address = "";
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

        public string coordinate = "Coordinate";
        public string Coordinate
        {
            get { return coordinate; }
            set
            {
                coordinate = Convert.ToString(value);
                OnPropertyChanged("Coordinate");
            }
        }

        /*
         * Start searching restaurants with given order requirement
         */
        public async Task search()
        {
            IsBusy = true;
            if (Order != null)
            {
                placeDetail = await model.getRandomPlaceDetail(Order);
            }
            IsBusy = false;
        }

    }
}

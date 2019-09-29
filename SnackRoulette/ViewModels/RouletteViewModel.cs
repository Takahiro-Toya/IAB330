using System;
using SnackRoulette.Models;
using SnackRoulette.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SnackRoulette.ViewModels {
    public class RouletteViewModel: BaseViewModel {

        public ICommand StartRouletteCommand { get; private set; }
        public ICommand StartMapCommand { get; set; }

        private RouletteModel model = new RouletteModel();
        public RouletteViewModel()
        {
            StartRouletteCommand = new Command(async () => {await search();});
            StartMapCommand = new Command(async () => await NavigationService.PushNextView(ViewType.MapView, DidConfirmOrderRequirements(),""));
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
                    Coordinate = value.Geo.Location.Latitude.ToString() + "  " + value.Geo.Location.Longitude.ToString();
                    CoordinateLat = value.Geo.Location.Latitude;
                    CoordinateLon = value.Geo.Location.Longitude;
                    CoordinateMap = new Position(value.Geo.Location.Latitude, value.Geo.Location.Longitude);
                    if (Order.Cuisine == "")
                    {
                        FoodImage = "Roulette";
                    } else if (Order.Cuisine == "fish and chips")
                    {
                        FoodImage = "FishChips";
                    } else
                    {
                        FoodImage = String.Format("{0}", Order.Cuisine);
                    }
                } else
                {
                    ResName = "Restaurant Not Found";
                    Description = "";
                    PhoneNr = "";
                    Address = "";
                    Price = "";
                    FoodImage = "Roulette";
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

        private string resName = "";
        public string ResName
        {
            get { return resName; }
            set
            {
                resName = value;
                OnPropertyChanged("ResName");
            }
        }

        private string description = "";
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        private string address = "";
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private string phoneNr = "";
        public string PhoneNr
        {
            get { return phoneNr; }
            set
            {
                phoneNr = value;
                OnPropertyChanged("PhoneNr");
            }
        }

        private string price = "";
        public string Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public string coordinate = "";
        public string Coordinate
        {
            get { return coordinate; }
            set
            {
                coordinate = Convert.ToString(value);
                OnPropertyChanged("Coordinate");
            }
        }

        public double coordinateLat = 0;
        public double CoordinateLat
        {
            get { return coordinateLat; }
            set
            {
                coordinateLat = Convert.ToDouble(value);
                OnPropertyChanged("CoordinateLat");
            }
        }
        public double coordinateLon = 0;
        public double CoordinateLon
        {
            get { return coordinateLon; }
            set
            {
                coordinateLon = Convert.ToDouble(value);
                OnPropertyChanged("CoordinateLon");
            }
        }

        public Position coordinateMap = new Position();
        public Position CoordinateMap
        {
            get { return coordinateMap; }
            set
            {
                coordinateMap = new Position(Convert.ToDouble(value.Latitude),Convert.ToDouble(value.Longitude));
                OnPropertyChanged("CoordinateMap");
            }
        }

        private string foodImage = "Roulette";
        public string FoodImage
        {
            get { return foodImage; }
            set { foodImage = value;
                OnPropertyChanged("FoodImage");
            }
        }

        public OrderModel DidConfirmOrderRequirements()
        {
            return new OrderModel(ResName, 0, 0, 0, coordinateLat, coordinateLon);
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

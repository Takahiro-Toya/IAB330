using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SnackRoulette.Models {
    public class PlaceSearchModel {

        public List<Place> places = new List<Place>();

        /*
         * Get data from google place api
         */
         public List<Place> getPlacesDataForOrder(OrderModel order)
        {
            PlaceApi api = new PlaceApi();
            Response response = api.GetPlaces(-27.4738117, 153.0249561, order.Raduis * 1000, "restaurant", order.Cuisine, 1, true).Result;
            //Response response = api.GetPlaces(-27.4738117, 153.0249561, "restaurant", order.Raduis * 1000, true).Result;
            //Response response = api.GetPlaces(-27.469838, 153.025918, "restaurant", true).Result;
            List<Place> places = response.Places;
            return places;
        }

        
    }
}

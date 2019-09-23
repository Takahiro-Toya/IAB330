using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SnackRoulette.Models {
    public class PlaceSearchModel {

        /*
         * Get data from google place api
         */
         public List<Place> getPlacesDataForOrder(OrderModel order)
        {
            PlaceApi api = new PlaceApi();
            Response response = api.GetPlaces(-27.469838, 153.025918, "restaurant", true).Result;
            List<Place> places = response.Places;
            return places;
        }

        
    }
}

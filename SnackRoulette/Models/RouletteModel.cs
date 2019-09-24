using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SnackRoulette.Models {
    public class PlaceSearchModel {

        private Random random = new Random();

        /*
         * Get list of places from google place api
         */
        private List<Place> getPlacesForOrder(OrderModel order)
        {
            PlaceApi api = new PlaceApi();
            Response response = api.GetPlaces(-27.4738117, 153.0249561, order.Raduis * 1000, "restaurant", order.Cuisine, order.Budget, true).Result;
            List<Place> places = response.Places;
            return places;
        }


        /*
         * Get random place from the places got through getPlacesForOrder(:)
         */
        public Place getRandomPlace(OrderModel order)
        {
            List<Place> places = getPlacesForOrder(order);
            if (places.Count != 0)
            {
                int randomNum = random.Next(0, places.Count - 1);
                return places[randomNum];
            } else
            {
                return null;
            }
            
        }



        
    }
}

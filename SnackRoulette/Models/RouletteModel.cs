using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SnackRoulette.Models {
    public class RouletteModel {

        private Random random = new Random();

        /*
         * Get list of places from google place api
         */
        private async Task<List<Place>> getPlacesForOrder(OrderModel order)
        {
            PlaceApi api = new PlaceApi();
            Response response = api.GetPlaces(order.CoordinateLat, order.CoordinateLong, order.Raduis * 1000, "restaurant", order.Cuisine, order.Budget, true).Result;
            List<Place> places = response.Places;
            return places;
        }


        /*
         * Get random place from the places got through getPlacesForOrder(:)
         */
        public async Task<Place> getRandomPlace(OrderModel order)
        {
            List<Place> places = await getPlacesForOrder(order);
            if (places.Count != 0)
            {
                int randomNum = random.Next(0, places.Count - 1);
                return places[randomNum];
            } else
            {
                return null;
            }
            
        }

        public async Task<Detail> getRandomPlaceDetail(OrderModel order)
        {
            List<Place> places = await getPlacesForOrder(order);
            if (places.Count != 0)
            {
                int randomNum = random.Next(0, places.Count - 1);
                return await places[randomNum].GetDetails();
            } else
            {
                return null;
            }
        }



        
    }
}

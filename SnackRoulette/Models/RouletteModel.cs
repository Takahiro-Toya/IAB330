using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SnackRoulette.Models {
    public class RouletteModel {

        private Random random = new Random();

         /// <summary>
         /// Gets list of places from google place api
         /// </summary>
         /// <param name="order"></param>
         /// <returns></returns>
        private async Task<List<Place>> getPlacesForOrder(OrderModel order)
        {
            PlaceApi api = new PlaceApi();
            Response response = api.GetPlaces(order.CoordinateLat, order.CoordinateLong, order.Raduis * 1000, "restaurant", order.Cuisine, order.Budget, true).Result;
            List<Place> places = response.Places;
            return places;
        }


        /// <summary>
        /// Return place 'Detail' rather than 'Place'
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
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

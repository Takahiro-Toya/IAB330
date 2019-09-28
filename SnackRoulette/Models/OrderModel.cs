using System;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace SnackRoulette.Models {

    /*
     * This class holds order requirements that is specified in OrderView by user
     */
    public class OrderModel {

        public string Cuisine = "I don't choose"; // cuisine type
        public double Raduis = 2.0; // radius requirement
        public int Budget = 1; // 1 ~ 4 ( inexpensive ~ expensive)
        public int NumGuests = 1; // number of meals
        public double CoordinateLat =0;
        public double CoordinateLong =0;

        public OrderModel(string cuisine, double radius, int budget, int numGuests, double coordinateLat, double coordinateLong)
        {
            this.Cuisine = cuisine;
            this.Budget = budget;
            this.Raduis = radius;
            this.NumGuests = numGuests;
            this.CoordinateLat = coordinateLat;
            this.CoordinateLong = coordinateLong;
        }
    }
}

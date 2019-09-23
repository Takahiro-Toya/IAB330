using System;
using System.Collections.Generic;

namespace SnackRoulette.Models {

    /*
     * This class holds order requirements that is specified in OrderView by user
     */
    public class OrderModel {

        public string Cuisine = "I don't choose"; // cuisine type
        public double Raduis = 2.0; // radius requirement
        public string Budget = "Inexpensive"; // budget type as "inexpensive", "moderate", "little expensive", "expensive"
        public int NumGuests = 1; // number of meals

        public OrderModel(string cuisine, double radius, string budget, int numGuests)
        {
            this.Cuisine = cuisine;
            this.Budget = budget;
            this.Raduis = radius;
            this.NumGuests = numGuests;
        }
    }
}

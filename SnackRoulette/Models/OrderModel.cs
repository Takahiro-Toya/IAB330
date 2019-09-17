using System;
using System.Collections.Generic;

namespace SnackRoulette.Models {

    /*
     * This class holds order requirements that is specified in OrderView by user
     */
    public class OrderModel {

        string Cuisine; // cuisine type
        double Raduis; // radius requirement
        string Budget; // budget type as "inexpensive", "moderate", "little expensive", "expensive"
        int NumMeals; // number of meals

        public OrderModel(string cuisine, double radius, string budget, int numMeals)
        {
            this.Cuisine = cuisine;
            this.Budget = budget;
            this.Raduis = radius;
            this.NumMeals = numMeals;
        }
    }
}

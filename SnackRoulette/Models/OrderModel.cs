using System;
using System.Collections.Generic;

namespace SnackRoulette.Models {

    /*
     * This class holds order requirements that is specified in OrderView by user
     */
    public class OrderModel {

        public enum BudgetType {
            Inexpensive,
            Moderate,
            Expensive,
            VeryExpensive
        }

        List<String> Cuisines = new List<String>(); // holds cuisine types as a list of string 
        double Raduis; // holds radius requirement
        BudgetType Budget; // holds budget requirement as string
        //(because Google Place API price detail supports "inexpensive", "moderate", "expensive" and "very expensive"

        public OrderModel(List<string> cuisines, int radius, BudgetType budget)
        {
            this.Cuisines = cuisines;
            this.Budget = budget;
            this.Raduis = radius;
        }
    }
}

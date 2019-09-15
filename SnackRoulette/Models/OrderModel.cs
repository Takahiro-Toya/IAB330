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

        string Cuisine; // holds cuisine types as a list of string 
        double Raduis; // holds radius requirement
        BudgetType Budget; // holds budget requirement as string
        private double radius;
        private BudgetType budgetType;

        //(because Google Place API price detail supports "inexpensive", "moderate", "expensive" and "very expensive"

        public OrderModel(string cuisine, int radius, BudgetType budget)
        {
            this.Cuisine = cuisine;
            this.Budget = budget;
            this.Raduis = radius;
        }

        public OrderModel(string cuisine, double radius, BudgetType budgetType)
        {
            Cuisine = cuisine;
            this.radius = radius;
            this.budgetType = budgetType;
        }
    }
}

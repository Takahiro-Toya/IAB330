using System;

namespace SnackRoulette.Models {
    public class RouletteModel {

        private OrderModel order;

        public String mealName = "meal";
        public double price = 0.0;

        public String restaurantName = "restaurant";
        public String description = "Vietnamese restaurant";
        public String address = "address123";
        public String phoneNr = "1234567890";
        public String budgetType = "inexpensive";
        //public Image?



        public RouletteModel(OrderModel order)
        {
            this.order = order;
        }

        /*
         * Get data from google place api
         */
        
    }
}

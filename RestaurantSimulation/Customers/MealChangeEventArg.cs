using System;

namespace RestaurantSimulation
{
    public class MealChangeEventArg : EventArgs
    {
        public Customer theCustomer { get; set; }
        public Meal OldMeal { get; set; }
        public Meal NewMeal { get; set; }

        public MealChangeEventArg(Customer customer, Meal oldMeal, Meal newMeal)
        {
            OldMeal = oldMeal;
            NewMeal = newMeal;
            theCustomer = customer;
        }
    }
}
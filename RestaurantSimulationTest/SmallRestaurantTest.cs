using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSimulation;
using System;

namespace RestaurantSimulationTest
{
    [TestClass]
    public class SmallRestaurantTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
                "A Null table allowed through the restaurant class constructor")]
        public void SmallRestaurant_Constructor_Table_Assignment_Test()
        {
            Array meals = Enum.GetValues(typeof(Meal));
            Table table = null;

            SmallRestaurant restaurant
                        = new SmallRestaurant(table, meals);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "An empty meal list was passed to the restaurant class")]
        public void SmallRestaurant_Constructor_Meals_Array_Size_Test()
        {
            Meal[] emptyMeals = new Meal[] { };
            Table table = new Table();

            SmallRestaurant restaurant
                        = new SmallRestaurant(table, emptyMeals);
        }

        [TestMethod]
        [ExpectedException(typeof(ArrayTypeMismatchException),
            "An array of inappropriate type was allowed.")]
        public void SmallRestaurant_Constructor_Meals_Array_Type_Test()
        {
            string[] oneArray = new string[] { "first", "second" };
            Table table = new Table();

            SmallRestaurant restaurant
                        = new SmallRestaurant(table, oneArray);
        }
    }
}

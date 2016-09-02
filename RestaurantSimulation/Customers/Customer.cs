using System;

namespace RestaurantSimulation
{
    public delegate void MealChangeEventHandler(object sender, MealChangeEventArg e);

    public class Customer
    {
        public event MealChangeEventHandler MealChangeEvent;

        private Meal _theMeal;

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public Meal theMeal
        {
            get { return _theMeal; }
            protected set
            {
                if (theMeal != value)
                {
                    Meal oldMeal = theMeal;

                    _theMeal = value;
                    AnnounceMealChange(oldMeal, value);
                }
            }
        }

        private void AnnounceMealChange(Meal oldMeal, Meal newMeal)
        {
            MealChangeEventArg arg = new MealChangeEventArg(this, oldMeal, newMeal);
            MealChangeEvent?.Invoke(this, arg);
        }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            _theMeal = Meal.None;
        }

        public void OnTableOpenHappened(object sender, TableOpenEventArg e)
        {
            Console.WriteLine($"{FirstName} {LastName} got a table.");

            Array menu = typeof(Meal).GetEnumValues();

            foreach (Meal meal in menu)
            {
                if (meal != Meal.None)
                    ChangeMeal(meal);
            }
        }

        /// <summary>
        /// Changes the current meal that the customer is having to "meal"
        /// </summary>
        /// <param name="meal">The new meal</param>
        public void ChangeMeal(Meal meal)
        {
            theMeal = meal;
        }
    }
}
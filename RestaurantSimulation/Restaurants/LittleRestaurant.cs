using System;

namespace RestaurantSimulation
{
    public class LittleRestaurant
    {
        /// <summary>
        /// Number of tables in the restaurant (For now, just one)
        /// </summary>
        public readonly int NumberOfTables;

        /// <summary>
        /// Table of the restaurant
        /// </summary>
        public Table RestaurantTable { get; protected set; }

        /// <summary>
        /// Customer queue
        /// </summary>
        public CustomerQueue<Customer> RestaurantQueue { get; set; }

        /// <summary>
        /// Menu of the restaurant (List of the foods that customers will go through them)
        /// </summary>
        public Array Meals { get; set; }

        public LittleRestaurant(Table table, Array meals)
        {
            if (table == null)
                throw new ArgumentNullException("Restaurant table cannot be null");

            if (meals.Length == 0)
                throw new ArgumentOutOfRangeException("Restaurant menu doesn't have any items");

            NumberOfTables = 1;
            RestaurantTable = table;
            Meals = meals;
            RestaurantQueue = new CustomerQueue<Customer>();
        }

        /// <summary>
        /// As soon as a new customer is created, it will be added to the queue
        /// and a listener will be added to meal-change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnNewCustomer(object sender, NewCustomerEventArg e)
        {
            Customer customer = e.theCustomer;

            if (customer != null)
            {
                customer.MealChangeEvent += OnCurrentCustomerMealChanged;

                RestaurantQueue.Add(customer);
            }
        }


        /// <summary>
        /// Will be executed on any meal change event but in fact is looking for when
        /// the customer is done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnCurrentCustomerMealChanged(object sender, MealChangeEventArg e)
        {
            if ((sender == null && e == null) || e.NewMeal == Meal.Done)
            {
                Customer customer = RestaurantQueue.Remove();

                // If there's no other customer in the queue
                if (customer == null)
                {
                    Console.WriteLine("\nEveryone is full.");
                    return;
                }

                // If this isn't the first customer, previous customer
                // which is done should stop listening to TableOpen event
                if (sender != null)
                {
                    Customer prevCustomer = sender as Customer;
                    RestaurantTable.TableOpenEvent
                                            -= prevCustomer.OnTableOpenHappened;
                    Console.WriteLine();
                }

                RestaurantTable.TableOpenEvent += customer.OnTableOpenHappened;
                RestaurantTable.Clean();
            }
            else
            {
                if (e == null)
                    return;

                Customer customer = e.theCustomer;
                Console.WriteLine($"{customer.FirstName} {customer.LastName}"
                                            + $" is having {e.NewMeal}");
            }
        }

        /// <summary>
        /// Start the operation of the restaurant, i.e. serving customers in the queue
        /// </summary>
        public void Start()
        {
            OnCurrentCustomerMealChanged(null, null);
        }
    }
}
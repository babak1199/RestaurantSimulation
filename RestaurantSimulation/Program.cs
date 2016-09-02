using System;

namespace RestaurantSimulation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Array menu = typeof(Meal).GetEnumValues();

            CustomerFactory factory = new CustomerFactory();
            Table table = new Table();
            LittleRestaurant restaurant = new LittleRestaurant(table, menu);

            factory.NewCustomerEvent += restaurant.OnNewCustomer;

            CreateNewCustomers(factory);

            restaurant.Start();

            Console.ReadLine();
        }

        /// <summary>
        /// 11 customers are added from which the first one will be dropped
        /// based on the limitation that has been deployed on the queue
        /// </summary>
        /// <param name="factory"></param>
        private static void CreateNewCustomers(CustomerFactory factory)
        {
            factory.Create("Julie", "Stones");
            factory.Create("Sally", "Jones");
            factory.Create("John", "Jackson");
            factory.Create("Ed", "Morphy");
            factory.Create("Stuart", "Millans");
            factory.Create("David", "Cohen");
            factory.Create("Mary", "Taylor");
            factory.Create("Elizabeth", "Trump");
            factory.Create("Nancy", "Graham");
            factory.Create("Annie", "Practor");
            factory.Create("Lily", "Swift");
        }
    }
}

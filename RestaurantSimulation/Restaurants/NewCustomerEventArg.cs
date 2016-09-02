using System;

namespace RestaurantSimulation
{
    public class NewCustomerEventArg : EventArgs
    {
        public Customer theCustomer { get; set; }

        public NewCustomerEventArg(Customer customer)
        {
            theCustomer = customer;
        }
    }
}
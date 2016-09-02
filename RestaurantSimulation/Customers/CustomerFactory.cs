namespace RestaurantSimulation
{
    public delegate void NewCustomerEventHandler(object sender, NewCustomerEventArg e);

    public class CustomerFactory
    {
        public event NewCustomerEventHandler NewCustomerEvent;

        public Customer Create(string firstName, string lastName)
        {
            Customer customer = new Customer(firstName, lastName);
            NewCustomerEvent?.Invoke(this, new NewCustomerEventArg(customer));
            return customer;
        }
    }
}

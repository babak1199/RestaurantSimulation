using System;

namespace RestaurantSimulation
{
    public delegate void TableOpenEventHandler(object sender, TableOpenEventArg e);

    public class Table
    {
        public event TableOpenEventHandler TableOpenEvent;

        private void FireTableOpenEvent()
        {
            Console.WriteLine($"Table is open!");

            TableOpenEvent?.Invoke(this, new TableOpenEventArg());
        }

        /// <summary>
        /// Makes table clean and empty for next customer
        /// </summary>
        public void Clean()
        {
            FireTableOpenEvent();
        }
    }
}

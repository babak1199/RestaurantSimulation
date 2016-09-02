using System.Collections.Generic;

namespace RestaurantSimulation
{
    public class CustomerQueue<T> where T : Customer
    {
        private List<T> _items { get; set; }

        public CustomerQueue()
        {
            _items = new List<T>(10);
        }

        public void Add(T item)
        {
            if (_items.Count == 10)
            {
                Remove();
                _items.Add(item);
            }
            else
                _items.Add(item);
        }

        public T Remove()
        {
            return Peek(true);
        }

        public T Next()
        {
            return Peek();
        }

        private T Peek(bool bRemove = false)
        {
            if (_items.Count > 0)
            {
                T item = _items[0];
                if(bRemove)
                    _items.RemoveAt(0);
                return item;
            }

            return null;
        }
    }
}
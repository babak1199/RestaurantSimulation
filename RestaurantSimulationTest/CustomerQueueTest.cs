using RestaurantSimulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RestaurantSimulationTest
{
    [TestClass]
    public class CustomerQueueTest
    {
        [TestMethod]
        public void Cutomer_Queue_Remove_Order_Test()
        {
            // Arrange
            CustomerQueue<Customer> queue = new CustomerQueue<Customer>();
            Customer c1 = new Customer("f1", "l1");
            Customer c2 = new Customer("f2", "l2");
            Customer c3 = new Customer("f3", "l3");
            Customer c4 = new Customer("f4", "l4");
            Customer c5 = new Customer("f5", "l5");
            queue.Add(c1);
            queue.Add(c2);
            queue.Add(c3);
            queue.Add(c4);
            queue.Add(c5);

            // Act
            Customer first = queue.Remove();
            Customer second = queue.Remove();
            Customer third = queue.Remove();
            Customer fourth = queue.Remove();
            Customer fifth = queue.Remove();

            // Assert
            Assert.AreEqual(first, c1);
            Assert.AreEqual(second, c2);
            Assert.AreEqual(third, c3);
            Assert.AreEqual(fourth, c4);
            Assert.AreEqual(fifth, c5);
        }

        [TestMethod]
        public void Cutomer_Queue_Ten_Item_Limit_Test()
        {
            // Arrange
            CustomerQueue<Customer> queue = new CustomerQueue<Customer>();
            Customer c1 = new Customer("f1", "l1");
            Customer c2 = new Customer("f2", "l2");
            Customer c3 = new Customer("f3", "l3");
            Customer c4 = new Customer("f4", "l4");
            Customer c5 = new Customer("f5", "l5");
            Customer c6 = new Customer("f6", "l6");
            Customer c7 = new Customer("f7", "l7");
            Customer c8 = new Customer("f8", "l8");
            Customer c9 = new Customer("f9", "l9");
            Customer c10 = new Customer("f10", "l10");
            Customer c11 = new Customer("f11", "l11");
            queue.Add(c1);
            queue.Add(c2);
            queue.Add(c3);
            queue.Add(c4);
            queue.Add(c5);
            queue.Add(c6);
            queue.Add(c7);
            queue.Add(c8);
            queue.Add(c9);
            queue.Add(c10);
            queue.Add(c11);

            // Act
            Customer first = queue.Remove();

            // Assert
            Assert.AreEqual(first, c2);
        }

        [TestMethod]
        public void Cutomer_Queue_No_Item_Remove_Test()
        {
            // Arrange
            CustomerQueue<Customer> queue = new CustomerQueue<Customer>();
            Customer first = null;

            // Act
            try
            {
                first = queue.Remove();
            }
            // Assert
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.AreEqual(first, null);
        }

    }
}

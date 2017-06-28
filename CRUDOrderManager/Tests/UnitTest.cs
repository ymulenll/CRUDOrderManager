using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Implementation;
using Model;
using Repository.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestNotImplementedException()
        {
            ICreateReadUpdateDelete<Order> crud = new EmptyCreateReadUpdateDelete<Order>();
            //ICreateReadUpdateDelete<Order> crud = new NewDeleteOrder<Order>();

            crud.ReadAll();
        }

        [TestMethod]
        public void TestNotImplementedExceptionLists()
        {
            ICollection<Order> orders = GetOrders();

            var expectedCount = orders.Count + 1;

            orders.Add(new Order());

            Assert.AreEqual(expectedCount, orders.Count);
        }

        private ICollection<Order> GetOrders()
        {
            //return new List<Order>(new[] { new Order() });
            return new ReadOnlyCollection<Order>(new[] { new Order() });
        }
    }
}

using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class OrderController
    {
        private readonly ICreateReadUpdate<Order> orderCRU;

        private readonly IDelete<Order> orderDelete;

        public OrderController(ICreateReadUpdate<Order> orderCRU, IDelete<Order> orderDelete)
        {
            this.orderCRU = orderCRU;

            this.orderDelete = orderDelete;
        }

        public void CreateOrder(Order order)
        {
            orderCRU.Create(order);
        }

        public Order GetSingleOrder(int id)
        {
            return orderCRU.ReadOne(id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return orderCRU.ReadAll();
        }

        public void UpdateOrder(Order order)
        {
            orderCRU.Update(order);
        }

        public void DeleteOrder(Order order)
        {
            orderDelete.Delete(order);
        }
    }
}

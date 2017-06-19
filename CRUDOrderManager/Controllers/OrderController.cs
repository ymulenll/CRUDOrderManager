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
        private readonly ICreateUpdate<Order> orderCU;

        private readonly IDelete<Order> orderDelete;

        private readonly IRead<Order> orderRead;

        public OrderController(ICreateUpdate<Order> orderCU, IDelete<Order> orderDelete, IRead<Order> orderRead)
        {
            this.orderCU = orderCU;

            this.orderDelete = orderDelete;

            this.orderRead = orderRead;
        }

        public void CreateOrder(Order order)
        {
            orderCU.Create(order);
        }

        public Order GetSingleOrder(int id)
        {
            return orderRead.ReadOne(id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return orderRead.ReadAll();
        }

        public void UpdateOrder(Order order)
        {
            orderCU.Update(order);
        }

        public void DeleteOrder(Order order)
        {
            orderDelete.Delete(order);
        }
    }
}

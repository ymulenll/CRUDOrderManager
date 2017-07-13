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
        private readonly ISave<Order> orderSave;

        private readonly IDelete<Order> orderDelete;

        private readonly IRead<Order> orderRead;

        public OrderController(ISave<Order> orderSave, IDelete<Order> orderDelete, IRead<Order> orderRead)
        {
            this.orderSave = orderSave;

            this.orderDelete = orderDelete;

            this.orderRead = orderRead;
        }

        public void CreateOrder(Order order)
        {
            orderSave.Save(order);
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
            orderSave.Save(order);
        }

        public void DeleteOrder(Order order)
        {
            orderDelete.Delete(order);
        }
    }
}

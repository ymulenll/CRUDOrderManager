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
        private readonly ICreateReadUpdateDelete<Order> orderCRUD;

        public OrderController(ICreateReadUpdateDelete<Order> orderCRUD)
        {
            this.orderCRUD = orderCRUD;
        }

        public void CreateOrder(Order order)
        {
            orderCRUD.Create(order);
        }

        public Order GetSingleOrder(int id)
        {
            return orderCRUD.ReadOne(id);
        }

        public void UpdateOrder(Order order)
        {
            orderCRUD.Update(order);
        }

        public void DeleteOrder(Order order)
        {
            orderCRUD.Delete(order);
        }
    }
}

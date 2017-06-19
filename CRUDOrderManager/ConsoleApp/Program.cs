using Controllers;
using Model;
using Repository.Implementation;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateService();
        }

        private static void CreateService()
        {
            ICreateReadUpdateDelete<Order> crudOrder = new EmptyCreateReadUpdateDelete<Order>();
            OrderController orderController = new OrderController(crudOrder);
        }
    }
}

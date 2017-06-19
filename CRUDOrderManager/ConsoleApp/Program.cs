using Controllers;
using Decorators;
using Domain.Interfaces;
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

            Console.ReadKey();
        }

        private static void CreateService()
        {
            ILog log = new ConsoleLogAdapter();

            ICreateReadUpdateDelete<Order> crudOrder = new EmptyCreateReadUpdateDelete<Order>();
            ICreateReadUpdateDelete<Order> crudOrderLogDecorator = new CrudLoggingDecorator<Order>(crudOrder, log);

            OrderController orderController = new OrderController(crudOrderLogDecorator);

            orderController.GetSingleOrder(1);
        }
    }
}

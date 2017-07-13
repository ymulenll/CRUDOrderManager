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
            CreateSingleService();
            //CreateSeparateServices();

            Console.ReadKey();
        }

        static OrderController CreateSeparateServices()
        {
            var reader = new Reader<Order>();
            var saver = new Saver<Order>();
            var deleter = new Deleter<Order>();

            return new OrderController(saver, deleter, reader);
        }

        private static void CreateSingleService()
        {
            IUserInteraction userInteraction = new ConsoleUserInteraction();
            ISave<AuditInfo> auditSave = new EmptyCreateReadUpdateDelete<AuditInfo>();

            var crudOrder = new EmptyCreateReadUpdateDelete<Order>();

            IDelete<Order> deleteOrderConfirmationDecorator = new DeleteConfirmationDecorator<Order>(crudOrder, userInteraction);
            IRead<Order> readOrderCachingDecorator = new ReadCachingDecorator<Order>(crudOrder);
            ISave<Order> saveOrderAuditingDecorator = new SaveAuditingDecorator<Order>(crudOrder, auditSave);

            OrderController orderController = new OrderController(saveOrderAuditingDecorator, deleteOrderConfirmationDecorator, readOrderCachingDecorator);

            orderController.DeleteOrder(new Order());
        }
    }
}

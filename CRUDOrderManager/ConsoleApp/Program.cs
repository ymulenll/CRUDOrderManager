﻿using Controllers;
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
            IUserInteraction userInteraction = new ConsoleUserInteraction();

            ICreateReadUpdate<Order> cruOrder = new EmptyCreateReadUpdateDelete<Order>();

            IDelete<Order> deleteOrder = new EmptyCreateReadUpdateDelete<Order>();
            IDelete<Order> deleteOrderConfirmationDecorator = new DeleteConfirmationDecorator<Order>(deleteOrder, userInteraction);

            OrderController orderController = new OrderController(cruOrder, deleteOrderConfirmationDecorator);

            orderController.DeleteOrder(new Order());
        }
    }
}

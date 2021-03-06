﻿using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorators
{
    public class ConsoleUserInteraction : IUserInteraction
    {
        public bool Confirm(string message)
        {
            Console.WriteLine("{0} [y/N]", message);
            var keyInfo = Console.ReadKey();
            return (keyInfo.Key == ConsoleKey.Y);
        }
    }
}

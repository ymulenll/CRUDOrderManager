using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorators
{
    public class ConsoleLogAdapter : ILog
    {
        public void LogInfo(string message)
        {
            Console.WriteLine(message);
        }
    }
}

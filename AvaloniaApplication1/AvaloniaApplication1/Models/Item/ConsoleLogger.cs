using AvaloniaApplication1.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models.Item
{
    public class ConsoleLogger : ILoggerService
    {
        public string? LastLog { get; set; }

        public void Log(string message)
        {
            LastLog = message;
            Console.WriteLine("[Console Log] :" + message);
        }
    }
}

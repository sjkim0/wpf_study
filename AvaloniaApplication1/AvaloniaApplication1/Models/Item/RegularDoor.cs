using Avalonia.Logging;
using AvaloniaApplication1.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models.Item
{
    public class RegularDoor : IDoor
    {
        private readonly ILoggerService _logger;

        public RegularDoor(ILoggerService logger)
        {
            _logger = logger;
        }

        public void Close()
        {
            _logger.Log("Driver Door Closed");
        }

        public void Open()
        {
            _logger.Log("Driver Door Opened");
        }
    }
}

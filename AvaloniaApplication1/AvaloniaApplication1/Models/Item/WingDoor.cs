using AvaloniaApplication1.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models.Item
{
    public class WingDoor : IDoor
    {
        private readonly ILoggerService _logger;

        public WingDoor(ILoggerService logger)
        {
            _logger = logger;
        }

        public void Close()
        {
            _logger.Log("Passenger Door Closed");
        }

        public void Open()
        {
            _logger.Log("Passenger Door Opened");
        }
    }
}

using AvaloniaApplication1.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models.Item
{
    public class GasEngine : IEngine
    {
        private readonly ILoggerService _logger;

        public GasEngine(ILoggerService logger)
        {
            _logger = logger;
        }

        public bool Started { get; set; }

        public void RunBackward()
        {
            if (Started == false)
            {
                Start();
            }
            _logger.Log("Gas Engine Run backward\n");
        }

        public void RunForward()
        {
            if (Started == false)
            {
                Start();
            }
            _logger.Log("Gas Engine Run forward\n");
        }

        public void Start()
        {
            Started = true;
            _logger.Log("Gas Engine Started\n");
        }

        public void Stop()
        {
            Started = false;
            _logger.Log("Gas Engine Stopped\n");
        }
    }
}

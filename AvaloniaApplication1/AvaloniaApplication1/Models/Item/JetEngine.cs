using AvaloniaApplication1.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models.Item
{
    public class JetEngine : IEngine
    {
        private readonly ILoggerService _logger;

        public JetEngine(ILoggerService logger)
        {
            _logger = logger;
        }

        public bool Started { get; set; }

        public void RunBackward()
        {
            _logger.Log("JetEngine Run backward");
        }

        public void RunForward()
        {
            _logger.Log("JetEngine Run forward");
        }

        public void Start()
        {
            _logger.Log("JetEngine Started");
        }

        public void Stop()
        {
            _logger.Log("JetEngine Stop");
        }
    }
}

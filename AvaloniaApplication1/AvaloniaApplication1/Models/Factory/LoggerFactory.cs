using AvaloniaApplication1.Models.Interface;
using AvaloniaApplication1.Models.Interface.IFactory;
using AvaloniaApplication1.Models.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models.Factory
{
    public class LoggerFactory : ILoggerFactory
    {
        private ILoggerService _console_logger;
        private ILoggerService _message_logger;

        public LoggerFactory(ILoggerService console_logger, ILoggerService message_logger)
        {
            _console_logger = console_logger;
            _message_logger = message_logger;
        }

        public ILoggerService GetLogger(LoggerTypes.ENUM_LOGGER_TYPE type)
        {
            switch(type)
            {
                case LoggerTypes.ENUM_LOGGER_TYPE.ENUM_LOGGER_CONSOLE:
                    return _console_logger;
                case LoggerTypes.ENUM_LOGGER_TYPE.ENUM_LOGGER_MESSAGE:
                    return _message_logger;
                default:
                    break;
            }
            throw new NotImplementedException();
        }
    }
}

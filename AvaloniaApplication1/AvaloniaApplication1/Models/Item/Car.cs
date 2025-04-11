using AvaloniaApplication1.Models.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models.Item
{
    public class Car : ICar
    {
        private readonly ILoggerService _loggerService;
        private readonly IEngine _engine;
        private readonly IDoor _door;

        public string name { get; }

        public Car(string name, ILoggerService loggerService, IEngine engine, IDoor door)
        {
            this.name = name;
            _loggerService = loggerService;
            _engine = engine;
            _door = door;
        }

        public void GoBackward()
        {
            _loggerService.Log(name);
            _door.Open();
            _engine.Start();
            _engine.RunBackward();
        }

        public void GoFoward()
        {
            _loggerService.Log(name);
            _engine.Start();
            _engine.RunForward();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}

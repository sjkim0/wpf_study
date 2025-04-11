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
        private readonly IEngine _engine;
        private readonly IDoor _door;


        public Car(IEngine engine, IDoor door)
        {
            _engine = engine;
            _door = door;
        }


        public void GoBackward()
        {
            _door.Open();
            _engine.Start();
            _engine.RunBackward();
        }

        public void GoFoward()
        {
            _engine.Start();
            _engine.RunForward();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}

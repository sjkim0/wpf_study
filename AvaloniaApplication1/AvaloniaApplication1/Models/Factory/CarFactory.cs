using AvaloniaApplication1.Models.Interface;
using AvaloniaApplication1.Models.Interface.IFactory;
using AvaloniaApplication1.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models.Factory
{
    public class CarFactory : ICarFactory
    {
        private readonly ILoggerService _logger;
        private readonly Func<GasEngine> _gasEngineFactory;
        private readonly Func<JetEngine> _jetEngineFactory;
        private readonly Func<RegularDoor> _regDoorFactory;
        private readonly Func<WingDoor> _wingDoorFactory;

        public CarFactory(ILoggerService logger, Func<GasEngine> gasEngineFactory, Func<JetEngine> jetEngineFactory, Func<RegularDoor> regDoorFactory, Func<WingDoor> wingDoorFactory)
        {
            _logger = logger;
            _gasEngineFactory = gasEngineFactory;
            _jetEngineFactory = jetEngineFactory;
            _regDoorFactory = regDoorFactory;
            _wingDoorFactory = wingDoorFactory;
        }

        public ICar CreateNormalCar()
        {
            return new Car("NORMAL_CAR", _logger, _gasEngineFactory(), _regDoorFactory());
        }

        public ICar CreateSuperCar()
        {
            return new Car("SUPER_CAR", _logger, _jetEngineFactory(), _wingDoorFactory());
        }
    }
}

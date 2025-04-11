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
    public class DoorFactory : IDoorFactory
    {
        private readonly IDoor _driver_door;
        private readonly IDoor _passenger_door;

        public DoorFactory(IDoor driver_door,  IDoor passenger_door)
        {
            _driver_door = driver_door;
            _passenger_door = passenger_door;
        }

        public IDoor GetDoor(DoorTypes.ENUM_DOOR_TYPE type)
        {
            switch(type)
            {
                case DoorTypes.ENUM_DOOR_TYPE.ENUM_DOOR_DRIVER:
                    return _driver_door;
                case DoorTypes.ENUM_DOOR_TYPE.ENUM_DOOR_PASSENGER_0:
                    return _passenger_door;
                case DoorTypes.ENUM_DOOR_TYPE.ENUM_DOOR_PASSENGER_1:
                    return _passenger_door;
                case DoorTypes.ENUM_DOOR_TYPE.ENUM_DOOR_PASSENGER_2:
                    return _passenger_door;
            }
            throw new NotImplementedException();
        }
    }
}

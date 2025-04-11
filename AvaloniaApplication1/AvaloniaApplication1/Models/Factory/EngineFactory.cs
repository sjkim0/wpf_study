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
    public class EngineFactory : IEngineFactory
    {
        private readonly IEngine _gas_engine;
        private readonly IEngine _jet_engine;

        public EngineFactory(IEngine gas_engine, IEngine jet_engine)
        {
            _gas_engine = gas_engine;
            _jet_engine = jet_engine;
        }

        public IEngine GetEngine(EngineTypes.ENUM_ENGINE_TYPE type)
        {
            switch (type)
            {
                case EngineTypes.ENUM_ENGINE_TYPE.ENUM_ENGINE_GAS:
                    return _gas_engine;
                case EngineTypes.ENUM_ENGINE_TYPE.ENUM_ENGINE_JET:
                    return _jet_engine;
                default:
                    break;
            }
            throw new NotImplementedException();
        }
    }
}

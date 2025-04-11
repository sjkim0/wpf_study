using AvaloniaApplication1.Models.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models.Interface.IFactory
{
    public interface IEngineFactory
    {
        IEngine GetEngine(EngineTypes.ENUM_ENGINE_TYPE type);
    }
}

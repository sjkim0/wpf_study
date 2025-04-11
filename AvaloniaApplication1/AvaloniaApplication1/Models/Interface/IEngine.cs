using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models.Interface
{
    public interface IEngine
    {
        bool Started { get; set; } 

        void Start();
        void RunForward();
        void RunBackward();
        void Stop();
    }
}

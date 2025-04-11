using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models.Interface
{
    public interface ILoggerService
    {
        string? LastLog { get; set; }
        void Log(string message);
    }
}

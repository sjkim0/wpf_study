using AvaloniaApplication1.Models.Interface;
using MsBox.Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models.Item
{
    public class MessageLogger : ILoggerService
    {
        public string? LastLog { get; set; }

        public async void Log(string message)
        {
            var box = MessageBoxManager.GetMessageBoxStandard("MessageLogger", "[MessageLog]: " + message);
            LastLog = message;

            var result = await box.ShowAsync();
        }
    }
}

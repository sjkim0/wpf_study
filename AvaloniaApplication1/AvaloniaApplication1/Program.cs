using Avalonia;
using AvaloniaApplication1.Models.Interface;
using AvaloniaApplication1.Models.Item;
using AvaloniaApplication1.ViewModels;
using AvaloniaApplication1.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using AvaloniaApplication1.Models.Interface.IFactory;
using AvaloniaApplication1.Models.Factory;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace AvaloniaApplication1
{
    internal sealed class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace();
    }
}

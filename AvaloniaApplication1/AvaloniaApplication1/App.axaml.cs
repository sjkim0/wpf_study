using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.Models.Factory;
using AvaloniaApplication1.Models.Interface;
using AvaloniaApplication1.Models.Interface.IFactory;
using AvaloniaApplication1.Models.Item;
using AvaloniaApplication1.ViewModels;
using AvaloniaApplication1.Views;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AvaloniaApplication1
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            BindingPlugins.DataValidators.RemoveAt(0);

            //ServiceProvider? services;
            ServiceCollection collection = new ServiceCollection();

            collection.AddSingleton<ILoggerService, MessageLogger>();
            collection.AddTransient<GasEngine>();
            collection.AddTransient<JetEngine>();
            collection.AddTransient<RegularDoor>();
            collection.AddTransient<WingDoor>();

            collection.AddSingleton<Func<GasEngine>>(sp => () => sp.GetRequiredService<GasEngine>());
            collection.AddSingleton<Func<JetEngine>>(sp => () => sp.GetRequiredService<JetEngine>());
            collection.AddSingleton<Func<RegularDoor>>(sp => () => sp.GetRequiredService<RegularDoor>());
            collection.AddSingleton<Func<WingDoor>>(sp => () => sp.GetRequiredService<WingDoor>());

            collection.AddSingleton<ICarFactory, CarFactory>();
            collection.AddTransient<MainWindowViewModel>();

            ServiceProvider provider = collection.BuildServiceProvider();

            var viewModel = provider.GetRequiredService<MainWindowViewModel>();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = viewModel
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
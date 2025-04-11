using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.Models.Interface;
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

            ServiceProvider? services;

            // serivce_0
            ServiceCollection collection;
            Car normal_car;
            Car super_car;
            MainWindowViewModel view_model;

            collection = new ServiceCollection();
            collection.AddTransient<ILoggerService, MessageLogger>();
            collection.AddSingleton<IDoor, RegularDoor>();
            collection.AddTransient<IEngine, GasEngine>();
            collection.AddTransient<Car>();
            services = collection.BuildServiceProvider();

            normal_car = services.GetRequiredService<Car>();  // 여기서 생성자 호출됨

            collection = new ServiceCollection();
            collection.AddTransient<ILoggerService, MessageLogger>();
            collection.AddSingleton<IDoor, WingDoor>();
            collection.AddTransient<IEngine, JetEngine>();
            collection.AddTransient<Car>();
            services = collection.BuildServiceProvider();

            super_car = services.GetRequiredService<Car>();  // 여기서 생성자 호출됨

            collection.AddSingleton<ICar>(normal_car);
            collection.AddSingleton<ICar>(super_car);
            collection.AddTransient<MainWindowViewModel>();
            services = collection.BuildServiceProvider();
            view_model = services.GetRequiredService<MainWindowViewModel>();  // 여기서 생성자 호출됨

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = view_model
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
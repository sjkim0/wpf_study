using AvaloniaApplication1.Models.Interface;
using AvaloniaApplication1.Models.Interface.IFactory;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System;
using CommunityToolkit.Mvvm.DependencyInjection;
using AvaloniaApplication1.Models.Item;

namespace AvaloniaApplication1.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public ICar NormalCar { get; }
        public ICar SuperCar { get; }

        [ObservableProperty]
        public string greeting = "Welcome to Avalonia!";


        public MainWindowViewModel(ICarFactory car_factory)
        {
            NormalCar = car_factory.CreateNormalCar();
            SuperCar = car_factory.CreateSuperCar();
        }

        //public MainWindowViewModel(Car car)
        //{
        //    Greeting = "6666";
        //    car.GoFoward();
        //}

        //public MainWindowViewModel(List<Car> cars)
        //{
        //    Greeting = "5678";

        //    foreach (ICar car in cars)
        //    {
        //        car.GoFoward();
        //    }
        //}
    }
}

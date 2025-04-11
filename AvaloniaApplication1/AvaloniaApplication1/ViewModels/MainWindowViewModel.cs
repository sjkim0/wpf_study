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
        private readonly IEnumerable<ICar> _cars;

        private readonly ICar _jetCar;
        private readonly ICar _regularCar;

        [ObservableProperty]
        public string greeting = "Welcome to Avalonia!";


        public MainWindowViewModel(IEnumerable<ICar> cars)
        {
            _cars = cars;
            foreach (ICar car in _cars)
            {
                car.GoFoward();
            }
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

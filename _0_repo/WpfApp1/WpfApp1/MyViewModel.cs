using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace WpfApp1
{
    public partial class MyViewModel : ObservableObject
    {
        MyModel model_inst;

        public MyViewModel()
        {
            model_inst = new MyModel(id: 0);
            Vm_name = "12345";
            Count = 0;
            Collection_test = new ObservableCollection<string>() { Count.ToString() };
        }

        [ObservableProperty]
        private int vm_id;

        [ObservableProperty]
        private string vm_name;

        [ObservableProperty]
        private string vm_type;

        [ObservableProperty]
        private string vm_description;

        [ObservableProperty]
        private ObservableCollection<string> collection_test;

        [ObservableProperty]
        private int count;

        [RelayCommand]
        private void viewModelCommandTest()
        {
            Vm_name = "Clicked " + Collection_test[Count].ToString();
            Count += 1;
            Collection_test.Add(Count.ToString());
        }
    }
}

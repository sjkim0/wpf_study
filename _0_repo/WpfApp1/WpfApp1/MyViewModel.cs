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
        readonly UserServiceDB user_service_inst;

        public MyViewModel()
        {
            user_service_inst = new UserServiceDB();

            model_inst = new MyModel(id: 0);
            Vm_name = "12345";
            Count = 0;
            Collection_test = new ObservableCollection<string>() { Count.ToString() };

            User_collect = new ObservableCollection<User>();
           
        }

        [ObservableProperty]
        private ObservableCollection<User> user_collect;

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

        [RelayCommand]
        private void AddUser()
        {
            user_service_inst.AddUser("John Doe", 30); // Dummy user
            LoadUsers(); // Refresh user list
        }

        [RelayCommand]
        private void LoadUsers()
        {
            User_collect.Clear();
            var users = user_service_inst.GetUsers();
            foreach (var user in users)
            {
                User_collect.Add(user);
            }
        }
    }
}

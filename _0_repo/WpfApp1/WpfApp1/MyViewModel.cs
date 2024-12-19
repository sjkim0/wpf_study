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
        UserJsonService user_json_service_inst;

        public MyViewModel()
        {
            user_service_inst = new UserServiceDB();
            user_json_service_inst = new UserJsonService();

            model_inst = new MyModel(id: 0);
            Vm_name = "12345";
            Count = 0;
            Collection_test = new ObservableCollection<string>() { Count.ToString() };

            User_sql_collect = new ObservableCollection<User>();
            User_json_collect = new ObservableCollection<UserJson>();
            
        }

        [ObservableProperty]
        private ObservableCollection<User> user_sql_collect;

        [ObservableProperty]
        private ObservableCollection<UserJson> user_json_collect;

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
        private void AddSqlUser()
        {
            user_service_inst.AddUser("User name sql", Count); // Dummy user
            LoadSqlUsers(); // Refresh user list
        }

        [RelayCommand]
        private void LoadSqlUsers()
        {
            User_sql_collect.Clear();
            var users = user_service_inst.GetUsers();
            foreach (var user in users)
            {
                User_sql_collect.Add(user);
            }
        }

        [RelayCommand]
        private void DeleteFirstSql()
        {
            user_service_inst.DeleteFirst();
            LoadSqlUsers(); // Refresh user list
        }

        [RelayCommand]
        private void DeleteLastSql()
        {
            user_service_inst.DeleteLast();
            LoadSqlUsers(); // Refresh user list
        }

        [RelayCommand]
        private void ClearAllSql()
        {
            user_service_inst.ClearAll();
            LoadSqlUsers(); // Refresh user list
        }

        [RelayCommand]
        private void AddJsonUser()
        {
            user_json_service_inst.AddUser("User name json", Count); // Dummy user
            LoadJsonUsers(); // Refresh user list
        }

        [RelayCommand]
        private void LoadJsonUsers()
        {
            User_json_collect.Clear();
            var users = user_json_service_inst.GetUsers();
            foreach (var user in users)
            {
                User_json_collect.Add(user);
            }
        }

        [RelayCommand]
        private void DeleteFirstJson()
        {
            user_json_service_inst.DeleteFirst();
            LoadJsonUsers(); // Refresh user list
        }

        [RelayCommand]
        private void DeleteLastJson()
        {
            user_json_service_inst.DeleteLast();
            LoadJsonUsers(); // Refresh user list
        }

        [RelayCommand]
        private void DeleteAllJson()
        {
            user_json_service_inst.DeleteAll();
            LoadJsonUsers(); // Refresh user list
        }
    }
}

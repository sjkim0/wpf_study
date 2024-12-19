using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class UserJsonService
    {
        private const string file_path = "data.json";

        public UserJsonService()
        {
        }

        public void AddUser(string name, int age)
        {
            try
            {
                UserJson user = new UserJson();
                user.Name = name;
                user.Age = age;
                List<UserJson> users = GetUsers();

                if(users != null)
                {
                    user.Id = users.Count;
                    users.Add(user);
                }
                else
                {
                    user.Id = 0;
                    users = new List<UserJson> { user };
                }

                string update_json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented  = true });
                File.WriteAllText(file_path, update_json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public void DeleteFirst()
        {
            try
            {
                List<UserJson> users = GetUsers();

                if(users != null && users.Count > 0)
                {
                    users.RemoveAt(0);
                    string update_json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(file_path, update_json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void DeleteLast()
        {
            try
            {
                List<UserJson> users = GetUsers();

                if (users != null && users.Count > 0)
                {
                    users.RemoveAt(users.Count - 1);
                    string update_json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(file_path, update_json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void DeleteAll()
        {
            try
            {
                List<UserJson> users = GetUsers();

                if (users != null && users.Count > 0)
                {
                    users.Clear();
                    string update_json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(file_path, update_json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public List<UserJson> GetUsers()
        {
            List<UserJson> users = new List<UserJson>();

            try
            {
                if (File.Exists(file_path))
                {
                    string existing_json = File.ReadAllText(file_path);
                    users = JsonSerializer.Deserialize<List<UserJson>>(existing_json);
                }
                else
                {
                    users.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return users;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace WpfApp1
{
    public class UserServiceDB
    {
        private const string DbFile = "Data Source=users.db";

        public UserServiceDB()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            try
            {

                using (var connection = new SQLiteConnection(DbFile))
                {
                    connection.Open();
                    string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Age INTEGER NOT NULL
                    )";
                    SQLiteCommand command = new SQLiteCommand(createTableQuery, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void AddUser(string name, int age)
        {
            try
            {
                using (var connection = new SQLiteConnection(DbFile))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO Users (Name, Age) VALUES (@Name, @Age)";
                    SQLiteCommand command = new SQLiteCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Age", age);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (var connection = new SQLiteConnection(DbFile))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Users";
                SQLiteCommand command = new SQLiteCommand(selectQuery, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Age = reader.GetInt32(2)
                        });
                    }
                }
            }
            return users;
        }
    }
}

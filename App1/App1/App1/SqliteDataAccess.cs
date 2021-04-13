using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace App1
{
    public class SqliteDataAccess
    {
        public static List<User> LoadUsers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<User>("select * from Users", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveUser(User user)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                cnn.Execute("insert into Users (username, email, password, first_name, registration_date) values " +
                    "(@UserName, @Email, @Password, @FirstName, @RegistrationDate)", user);
            }
        }

        private static string LoadConnectionString()
        {
            return "Data Source=./Database.db";
        }
    }
}

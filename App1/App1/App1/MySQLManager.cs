using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySqlConnector;

namespace App1
{
    public class MySQLManager
    {

        public static string InsertUser(User user)
        {
            try
            {
                string connStr = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
                MySqlConnection con = new MySqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("insert into Users (username, email, password, first_name, registration_date) values " +
                    "(@username, @email, @password, @first_name, @registration_date)", con);

                    cmd.Parameters.AddWithValue("@username", user.username);
                    cmd.Parameters.AddWithValue("@email", user.email);
                    cmd.Parameters.AddWithValue("@password", user.password);
                    cmd.Parameters.AddWithValue("@first_name", user.first_name);
                    cmd.Parameters.AddWithValue("@registration_date", user.registration_date);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return "Success";
                }
            }
            catch(MySqlException ex)
            {
                return "Failure";
            }

            return "WALAS";
        }

        public static List<User> LoadUsers()
        {
            try
            {
                string connStr = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
                MySqlConnection conn = new MySqlConnection(connStr);

                conn.Open();

                string sql = "SELECT * FROM Users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                List<User> users = new List<User>();

                while (rdr.Read())
                {
                    User usr = new User(int.Parse(rdr[0].ToString()), rdr[1].ToString(), rdr[2].ToString(),
                        rdr[3].ToString(), rdr[4].ToString(), DateTime.Parse(rdr[5].ToString()));

                    users.Add(usr);
                }
                rdr.Close();

                return users;
            }
            catch (Exception ex)
            {
                return new List<User>();
            }

        }
    }
}

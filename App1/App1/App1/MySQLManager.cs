using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySqlConnector;
using App1.Assets;

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

        public static int InsertCompetition(Competition comp)
        {
            try
            {
                string connStr = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
                MySqlConnection con = new MySqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                    //MySqlCommand cmd = new MySqlCommand("INSERT INTO Competition (event_name, start_time, end_time, description, Live_event, fk_Usersid) values " +
                    //"(@name, @start, @end, @desc, @live, @fk", con);
                    MySqlCommand cmd = new MySqlCommand(@"INSERT INTO Competition (event_name, start_time, end_time, description, Live_event, fk_Usersid) values (@name, @start, @end, @desc, @live, @fk)", con);
                    
                    cmd.Parameters.AddWithValue("@name", comp.Name);
                    cmd.Parameters.AddWithValue("@start", comp.StartDate);
                    cmd.Parameters.AddWithValue("@end", comp.EndDate);
                    cmd.Parameters.AddWithValue("@desc", comp.Description);
                    cmd.Parameters.AddWithValue("@live", comp.LiveType);
                    cmd.Parameters.AddWithValue("@fk", comp.fk_CreatorId);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    return (int)cmd.LastInsertedId;
                }
            }
            catch (MySqlException ex)
            {
                return -1;
            }

            return -1;
        }

        public static string InsertTask(Task task)
        {
            try
            {
                string connStr = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
                MySqlConnection con = new MySqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("insert into Task (task_name, description, latitude, longitude, question, answer, fk_Competitionid) values " +
                    "(@name, @desc, @lati, @longi, @quest, @ans, @fk)", con);

                    cmd.Parameters.AddWithValue("@name", task.TaskName);
                    cmd.Parameters.AddWithValue("@desc", task.Description);
                    cmd.Parameters.AddWithValue("@lati", task.latitude);
                    cmd.Parameters.AddWithValue("@longi", task.longitude);
                    cmd.Parameters.AddWithValue("@quest", task.Question);
                    cmd.Parameters.AddWithValue("@ans", task.Answer);
                    cmd.Parameters.AddWithValue("@fk", task.fk_Competition_id);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    return "Success";
                }
            }
            catch (MySqlException ex)
            {
                return "Failure";
            }

            return "WALAS";
        }
    }
}

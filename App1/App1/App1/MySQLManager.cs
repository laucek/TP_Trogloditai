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

        public static string InsertCompetition(Competition comp)
        {
            try
            {
                string connStr = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
                MySqlConnection con = new MySqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("insert into Competition (event_name, start_time, end_time, description, Live_event, fk_Usersid) values " +
                    "(@name, @start, @end, @desc, @live, @fk, @fk)", con);

                    cmd.Parameters.AddWithValue("@name", comp.Name);
                    cmd.Parameters.AddWithValue("@start", comp.StartDate);
                    cmd.Parameters.AddWithValue("@end", comp.EndDate);
                    cmd.Parameters.AddWithValue("@desc", comp.Description);
                    cmd.Parameters.AddWithValue("@live", comp.LiveType);
                    cmd.Parameters.AddWithValue("@fk", comp.fk_CreatorId);

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

        public static bool UpdateUserInfo(User user)
        {
            try
            {
                string connStr = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
                MySqlConnection conn = new MySqlConnection(connStr);

                string sqlquery = "UPDATE Users a SET a.username=?usrn, a.email=?ema, a.password=?pass, a.first_name=?frst WHERE a.id=?idas";

                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, conn);
                mySqlCommand.Parameters.Add("?idas", MySqlDbType.Int32).Value = user.id;
                mySqlCommand.Parameters.Add("?usrn", MySqlDbType.VarChar).Value = user.username;
                mySqlCommand.Parameters.Add("?ema", MySqlDbType.VarChar).Value = user.email;
                mySqlCommand.Parameters.Add("?pass", MySqlDbType.VarChar).Value = user.password;
                mySqlCommand.Parameters.Add("?frst", MySqlDbType.VarChar).Value = user.first_name;


                conn.Open();
                mySqlCommand.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

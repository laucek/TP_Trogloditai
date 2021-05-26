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


        public static User GetUserById(int id)
        {
            try
            {
                string connStr = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
                MySqlConnection conn = new MySqlConnection(connStr);

                conn.Open();

                string sql = "SELECT * FROM Users WHERE id=" + id;
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

                return users[0];
            }
            catch (Exception ex)
            {
                return null;
            }
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
        public static List<Competition> LoadCompetitions()
        {
            try
            {
                string connStr = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
                MySqlConnection conn = new MySqlConnection(connStr);

                conn.Open();

                string sql = "SELECT * FROM Competition";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                List<Assets.Competition> comps = new List<Competition>();

                while (rdr.Read())
                {
                    Competition comp = new Competition(int.Parse(rdr[0].ToString()), rdr[1].ToString(), DateTime.Parse(rdr[2].ToString()),
                        DateTime.Parse(rdr[3].ToString()), rdr[4].ToString(), int.Parse(rdr[5].ToString()), int.Parse(rdr[6].ToString()));

                    comps.Add(comp);
                }
                rdr.Close();

                return comps;
            }
            catch (Exception ex)
            {
                return new List<Assets.Competition>();
            }
        }
        public static string DeleteFavorite(Favorite fav)
        {
            try
            {
                string connStr = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
                MySqlConnection con = new MySqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
                    MySqlConnection mySqlConnection = new MySqlConnection(conn);
                    string sqlquery = $@"DELETE FROM Favorite WHERE fk_Competitionid = {fav.fk_Competitionsid} AND fk_Usersid = {fav.fk_Usersid}";
                    MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    mySqlConnection.Close();

                    return "Success";
                }
            }
            catch (MySqlException ex)
            {
                return "Failure";
            }

            return "WALAS";
        }

        public static string InsertComment(Comment com)
        {
            try
            {
                string connStr = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
                MySqlConnection con = new MySqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                    string sqlquery = @"INSERT INTO `Comment`(`post_date`, `comment`, `fk_Competitionid`, `fk_Usersid`)
                        VALUES (?date,?comm,?fkcompid,?fkusid)";
                    MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, con);
                    mySqlCommand.Parameters.Add("?date", MySqlDbType.DateTime).Value = com.Date;
                    mySqlCommand.Parameters.Add("?comm", MySqlDbType.String).Value = com.Commentaras;
                    mySqlCommand.Parameters.Add("?fkusid", MySqlDbType.Int32).Value = com.fk_Usersid;
                    mySqlCommand.Parameters.Add("?fkcompid", MySqlDbType.Int32).Value = com.fk_Competitionsid;
                    mySqlCommand.ExecuteNonQuery();

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

        public static string InsertFavorite(Favorite fav)
        {
            try
            {
                string connStr = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
                MySqlConnection con = new MySqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("insert into Favorite (fk_Usersid, fk_Competitionid) values " +
                    "(@usid, @cmpid)", con);

                    cmd.Parameters.AddWithValue("@cmpid", fav.fk_Competitionsid);
                    cmd.Parameters.AddWithValue("@usid", fav.fk_Usersid);
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

        public static List<Comment> LoadCommentByCompetition(int competitionId)
        {
            try
            {
                string connStr = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
                MySqlConnection conn = new MySqlConnection(connStr);

                conn.Open();

                string sql = "SELECT * FROM Comment WHERE fk_Competitionid="+ competitionId;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                List<Comment> comment = new List<Comment>();

                while (rdr.Read())
                {
                    Comment cmt = new Comment(int.Parse(rdr[0].ToString()), DateTime.Parse(rdr[1].ToString()),
                        rdr[2].ToString(), int.Parse(rdr[3].ToString()), int.Parse(rdr[4].ToString()));

                    comment.Add(cmt);
                }
                rdr.Close();

                return comment;
            }
            catch (Exception ex)
            {
                return new List<Comment>();
            }
        }

        public static List<Favorite> LoadFavs()
        {
            try
            {
                string connStr = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
                MySqlConnection conn = new MySqlConnection(connStr);

                conn.Open();

                string sql = "SELECT * FROM Favorite";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                List<Favorite> favs = new List<Favorite>();

                while (rdr.Read())
                {
                    Favorite usr = new Favorite(int.Parse(rdr[0].ToString()), int.Parse(rdr[1].ToString()), int.Parse(rdr[2].ToString()));

                    favs.Add(usr);
                }
                rdr.Close();

                return favs;
            }
            catch (Exception ex)
            {
                return new List<Favorite>();
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

        public static List<Task> GetTasksByCompetition(int compId)
        {
            try
            {
                string connStr = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
                MySqlConnection conn = new MySqlConnection(connStr);

                conn.Open();

                string sql = "SELECT * FROM Task WHERE fk_Competitionid=" + compId;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                List<Task> tasks = new List<Task>();

                while (rdr.Read())
                {
                    Task cmt = new Task(int.Parse(rdr[0].ToString()), rdr[1].ToString(),
                        rdr[2].ToString(), double.Parse(rdr[3].ToString()), double.Parse(rdr[4].ToString()), rdr[5].ToString(), rdr[6].ToString()
                        , int.Parse(rdr[7].ToString()));

                    tasks.Add(cmt);
                }
                rdr.Close();

                return tasks;
            }
            catch (Exception ex)
            {
                return new List<Task>();
            }
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

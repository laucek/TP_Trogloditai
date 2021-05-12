using System;
using System.Collections.Generic;
using System.Text;
using App1.Assets;
using System.Configuration;
using MySqlConnector;
using System.Data;

namespace App1.Repos
{
    class CompetitionRepos
    {
        public List<Competition> getCompetition()
        {
            List<Competition> comp = new List<Competition>();
            string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            //string sqlquery = @"SELECT `id`, `event_name`, `start_time`, `end_time`, `description`, `Live_event`, `fk_Usersid` FROM `Competition` WHERE 1";
            string sqlquery = @"SELECT * FROM `Competition`";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                comp.Add(new Competition(Convert.ToInt32(item["id"]),
                    Convert.ToString(item["event_name"]),
                    Convert.ToDateTime(item["start_time"]),
                    Convert.ToDateTime(item["end_time"]),
                    Convert.ToString(item["description"]),
                    Convert.ToInt32(item["Live_event"]),
                    Convert.ToInt32(item["fk_Usersid"]))
               );
            }
            return comp;
        }

        public List<Competition> getCompetition(int id)
        {
            List<Competition> comp = new List<Competition>();
            string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `Competition` WHERE id=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                comp.Add(new Competition(Convert.ToInt32(item["id"]),
                    Convert.ToString(item["event_name"]),
                    Convert.ToDateTime(item["start_time"]),
                    Convert.ToDateTime(item["end_time"]),
                    Convert.ToString(item["description"]),
                    Convert.ToInt32(item["Live_event"]),
                    Convert.ToInt32(item["fk_Usersid"]))
               );
            }
            return comp;
        }

        public List<Competition> getFavoriteCompetition()
        {
            List<Competition> comp = new List<Competition>();
            string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM Competition c ORDER BY (select COUNT(a.fk_Competitionid) from Favorite a where a.fk_Competitionid = c.id) DESC";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                comp.Add(new Competition(Convert.ToInt32(item["id"]),
                    Convert.ToString(item["event_name"]),
                    Convert.ToDateTime(item["start_time"]),
                    Convert.ToDateTime(item["end_time"]),
                    Convert.ToString(item["description"]),
                    Convert.ToInt32(item["Live_event"]),
                    Convert.ToInt32(item["fk_Usersid"]))
               );
            }
            return comp;
        }

        public List<Competition> getFavoriteCompetition(int id)
        {
            List<Competition> comp = new List<Competition>();
            string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM Competition c INNER JOIN Favorite a on c.id = a.fk_Competitionid WHERE a.fk_Usersid =" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                comp.Add(new Competition(Convert.ToInt32(item["id"]),
                    Convert.ToString(item["event_name"]),
                    Convert.ToDateTime(item["start_time"]),
                    Convert.ToDateTime(item["end_time"]),
                    Convert.ToString(item["description"]),
                    Convert.ToInt32(item["Live_event"]),
                    Convert.ToInt32(item["fk_Usersid"]))
               );
            }
            return comp;
        }

        public bool addCompetition(Competition comp)
        {
            string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO `Competition`(`event_name`, `start_time`, `end_time`, `description`, `Live_event`, `fk_Usersid`)
                        VALUES (?name,?startdate,?enddate,?description,?live,?creator)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?name", MySqlDbType.String).Value = comp.Name;
            mySqlCommand.Parameters.Add("?startdate", MySqlDbType.DateTime).Value = comp.StartDate;
            mySqlCommand.Parameters.Add("?enddate", MySqlDbType.DateTime).Value = comp.EndDate;
            mySqlCommand.Parameters.Add("?description", MySqlDbType.String).Value = comp.Description;
            mySqlCommand.Parameters.Add("?live", MySqlDbType.Int32).Value = comp.LiveType;
            mySqlCommand.Parameters.Add("?creator", MySqlDbType.Int32).Value = comp.fk_CreatorId;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public bool updateCompetition(Competition comp)
        {
            string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE Competition a SET a.event_name=?ev, a.start_time=?start, a.end_time=?end, a.description=?des, a.Live_event=?live WHERE a.id=" + comp.Id;

            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?ev", MySqlDbType.String).Value = comp.Name;
            mySqlCommand.Parameters.Add("?start", MySqlDbType.DateTime).Value = comp.StartDate;
            mySqlCommand.Parameters.Add("?end", MySqlDbType.DateTime).Value = comp.EndDate;
            mySqlCommand.Parameters.Add("?des", MySqlDbType.String).Value = comp.Description;
            mySqlCommand.Parameters.Add("?live", MySqlDbType.Int32).Value = comp.LiveType;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public void deleteCompetition(int id)
        {
            string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM `Competition` WHERE id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using App1.Assets;
using System.Configuration;
using MySqlConnector;
using System.Data;

namespace App1.Repos
{
    class FavoriteRepos
    {
        //DOESNT FUCKING WORK 
        public List<Favorite> getFavoriteList(int id)
        {
            List<Favorite> fav = new List<Favorite>();
            string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `Favorite` WHERE fk_Usersid=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                fav.Add(new Favorite(Convert.ToInt32(item["id"]),
                    Convert.ToInt32(item["fk_Competitionid"]),
                    Convert.ToInt32(item["fk_Usersid"])
               ));
            }
            return fav;
        }

        public List<Favorite> GetFavorites(int id)
        {
            List<Favorite> favs = new List<Favorite>();
            string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            //string sqlquery = @"SELECT `id`, `event_name`, `start_time`, `end_time`, `description`, `Live_event`, `fk_Usersid` FROM `Competition` WHERE 1";
            string sqlquery = @"SELECT * FROM `Favorite` WHERE fk_Usersid=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                favs.Add(new Favorite(Convert.ToInt32(item["id"]),
                    Convert.ToInt32(item["fk_Competitionid"]),
                    Convert.ToInt32(item["fk_Usersid"])
               ));
            }
            return favs;
        }

        public bool addFavorite(Favorite fav)
        {
            string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO `Favorite`(`fk_Usersid`, `fk_Competitionid`)
                        VALUES (?usr,?com)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?usr", MySqlDbType.Int32).Value = fav.fk_Usersid;
            mySqlCommand.Parameters.Add("?com", MySqlDbType.Int32).Value = fav.fk_Competitionsid;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public void deleteFavorite(int Userid, int compId)
        {
            string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = $@"SELECT * FROM `Favorite` WHERE fk_Usersid = {Userid} AND fk_Competitionid = {compId}";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}

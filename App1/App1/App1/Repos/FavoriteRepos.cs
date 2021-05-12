using App1.Assets;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace App1.Repos
{
    class FavoriteRepos
    {
        public List<Favorite> getFavoriteList(int id)
        {
            List<Favorite> fav = new List<Favorite>();
            string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `Favorite` WHERE fk_Usersid=" + Session.Id;
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


        public bool addFavorite(Favorite fav)
        {
            string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO `Favorite`(`id`, `fk_Usersid`, `fk_Competitionid`)
                        VALUES (?idas,?usr,?com)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?name", MySqlDbType.String).Value = fav.id;
            mySqlCommand.Parameters.Add("?startdate", MySqlDbType.DateTime).Value = fav.fk_Usersid;
            mySqlCommand.Parameters.Add("?enddate", MySqlDbType.DateTime).Value = fav.fk_Competitionsid;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public void deleteCompetition(int id)
        {
            string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM `Favorite` WHERE id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}

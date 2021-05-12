using App1.Assets;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace App1.Repos
{
    class CommentRepos
    {
        public List<Comment> getCommentsList(int id)
        {
            List<Comment> com = new List<Comment>();
            string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `Comment` WHERE fk_Usersid=" + Session.Id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                com.Add(new Comment(Convert.ToInt32(item["id"]),
                    Convert.ToDateTime(item["post_date"]),
                    Convert.ToString(item["comment"]),
                    Convert.ToInt32(item["fk_Competitionid"]),
                    Convert.ToInt32(item["fk_Usersid"])
               ));
            }
            return com;
        }


        public bool addComment(Comment com)
        {
            string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO `Comment`(`id`, `post_date`, `comment`, `fk_Competitionid`, `fk_Usersid`)
                        VALUES (?idas,?post,?comm,?comp,?usr)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?name", MySqlDbType.Int32).Value = com.Id;
            mySqlCommand.Parameters.Add("?startdate", MySqlDbType.DateTime).Value = com.Date;
            mySqlCommand.Parameters.Add("?name", MySqlDbType.String).Value = com.Commentaras;
            mySqlCommand.Parameters.Add("?startdate", MySqlDbType.DateTime).Value = com.fk_Usersid;
            mySqlCommand.Parameters.Add("?enddate", MySqlDbType.DateTime).Value = com.fk_Competitionsid;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public void deleteComment(int id)
        {
            string conn = "server=sql5.freemysqlhosting.net;user=sql5405481;database=sql5405481;port=3306;password=gvTiFVNil3";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM `Comment` WHERE id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = Session.Id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}

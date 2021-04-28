using System;
using System.Collections.Generic;
using System.Text;
using App1.Assets;
using System.Configuration;
using MySqlConnector;
using System.Data;

namespace App1.DBControllers
{
    class TaskRepos
    {
        public List<Task> getTasks()
        {
            List<Task> task = new List<Task>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `Task` WHERE 1";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                task.Add(new Task(Convert.ToInt32(item["id"]),
                    Convert.ToString(item["task_name"]),
                    Convert.ToString(item["description"]),
                    Convert.ToDouble(item["latitude"]),
                    Convert.ToDouble(item["longitude"]),
                    Convert.ToString(item["question"]),
                    Convert.ToString(item["answer"]),
                    Convert.ToInt32(item["fk_Competitionid"]))
               );
            }
            return task;
        }

        public List<Task> getTasks(int id)
        {
            List<Task> task = new List<Task>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `Task` WHERE id="+ id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                task.Add(new Task(Convert.ToInt32(item["id"]),
                    Convert.ToString(item["task_name"]),
                    Convert.ToString(item["description"]),
                    Convert.ToDouble(item["latitude"]),
                    Convert.ToDouble(item["longitude"]),
                    Convert.ToString(item["question"]),
                    Convert.ToString(item["answer"]),
                    Convert.ToInt32(item["fk_Competitionid"]))
               );
            }
            return task;
        }
        public bool addTask(Task task)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO `Task`(`task_name`, `description`, `latitude`, `longitude`, `question`, `answer`, `fk_Competitionid`) 
                            VALUES (?taskname, ?description,?latitude,?longitude,?question,?answer,?competition)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?taskname", MySqlDbType.String).Value = task.TaskName;
            mySqlCommand.Parameters.Add("?description", MySqlDbType.String).Value = task.Description;
            mySqlCommand.Parameters.Add("?latitude", MySqlDbType.Double).Value = task.latitude;
            mySqlCommand.Parameters.Add("?longitude", MySqlDbType.Double).Value = task.longitude;
            mySqlCommand.Parameters.Add("?question", MySqlDbType.String).Value = task.Question;
            mySqlCommand.Parameters.Add("?answer", MySqlDbType.String).Value = task.Answer;
            mySqlCommand.Parameters.Add("?competition", MySqlDbType.Int32).Value = task.fk_Competition_id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }
        public void deleteTask(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM `Task` WHERE id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

    }
}

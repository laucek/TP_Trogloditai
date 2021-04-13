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
                    return "Success";
                }
            }
            catch(MySqlException ex)
            {
                return "Failure";
            }

            return "WALAS";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace App1
{
    public class MySQLManager
    {

        public static string InsertUser(User user)
        {
            try
            {
                MySqlConnection con = new MySqlConnection("Server=sql301.epizy.com;Port=3306;database=epiz_28350683_data;User Id=epiz_28350683;Password=oh7faxtRdFpI6;charset=utf8");

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

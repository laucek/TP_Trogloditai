using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public DateTime registration_date { get; set; }

        public User(int id, string username, string email, string password, string first_name, DateTime registration_date)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            this.password = password;
            this.first_name = first_name;
            this.registration_date = registration_date;
        }

        public override string ToString()
        {
            return $"{first_name} {username} {email} {password} {registration_date}";
        }
    }
}

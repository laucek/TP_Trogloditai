using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Assets
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Commentaras { get; set; }
        public int fk_Competitionsid { get; set; }
        public int fk_Usersid { get; set; }

        public Comment(int id, DateTime date, string commentaras, int fk_Competitionsid, int fk_Usersid)
        {
            Id = id;
            Date = date;
            Commentaras = commentaras;
            this.fk_Competitionsid = fk_Competitionsid;
            this.fk_Usersid = fk_Usersid;
        }
    }
}

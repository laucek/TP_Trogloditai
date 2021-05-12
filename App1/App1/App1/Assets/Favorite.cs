using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Assets
{
    class Favorite
    {
        public int id { get; set; }
        public int fk_Competitionsid { get; set; }
        public int fk_Usersid { get; set; }

        public Favorite(int id, int fk_Competitionsid, int fk_Usersid)
        {
            this.id = id;
            this.fk_Competitionsid = fk_Competitionsid;
            this.fk_Usersid = fk_Usersid;
        }
    }
}

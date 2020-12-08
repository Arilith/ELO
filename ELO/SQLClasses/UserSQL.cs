using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;

namespace ELO.SQLClasses
{
    public class UserSQL
    {

        public string ReadUser()
        {
            return MySQLManager.con.ServerVersion;
        }

    }
}

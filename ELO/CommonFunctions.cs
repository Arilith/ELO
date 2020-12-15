using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ELO
{
    public static class CommonFunctions
    {

        public static int RowCount(this MySqlDataReader reader)
        {
            int rowCount = 0;
            while (reader.Read())
                rowCount++;
            
            return rowCount;
        }

    }
}

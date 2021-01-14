using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using ELO.SQLClasses;
using MySql.Data.MySqlClient;

namespace ELO
{
    public static class KillSleepingMySQL
    {

        public static int KillSleepingConnections(int iMinSecondsToExpire)
        {
            string strSQL = "show processlist";
            System.Collections.ArrayList m_ProcessesToKill = new ArrayList();

            MySqlManager mysqlManager = new MySqlManager();
            MySqlCommand myCmd = new MySqlCommand(strSQL, mysqlManager.con);
            MySqlDataReader MyReader = null;

            try
            {
                // Get a list of processes to kill.
                MyReader = myCmd.ExecuteReader();
                while (MyReader.Read())
                {
                    // Find all processes sleeping with a timeout value higher than our threshold.
                    int iPID = Convert.ToInt32(MyReader["Id"].ToString());
                    string strState = MyReader["Command"].ToString();
                    int iTime = Convert.ToInt32(MyReader["Time"].ToString());

                    if (strState == "Sleep" && iTime >= iMinSecondsToExpire && iPID > 0)
                    {
                        // This connection is sitting around doing nothing. Kill it.
                        m_ProcessesToKill.Add(iPID);
                    }
                }

                MyReader.Close();

                foreach (int aPID in m_ProcessesToKill)
                {
                    strSQL = "kill " + aPID;
                    myCmd.CommandText = strSQL;
                    myCmd.ExecuteNonQuery();
                }
            }
            catch (Exception excep)
            {
            }
            finally
            {
                if (MyReader != null && !MyReader.IsClosed)
                {
                    MyReader.Close();
                }

                if (mysqlManager.con != null && mysqlManager.con.State == ConnectionState.Open)
                {
                    mysqlManager.con.Close();
                }
            }

            return m_ProcessesToKill.Count;
        }
    }
}

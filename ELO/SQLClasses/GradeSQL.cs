using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ELO.SQLClasses
{
    public class GradeSQL
    {

        // public List<Grade> GetGradeList(string school)
        // {
        //     string finalstring = "";
        //
        //     MySqlCommand cmd = new MySqlCommand("SELECT * FROM grades WHERE school = '"+ school + "'", MySqlManager.con);
        //     MySqlDataReader reader = cmd.ExecuteReader();
        //
        //     List<Grade> returnedGrades = new List<Grade>();
        //
        //     while (reader.Read())
        //     {
        //        returnedGrades.Add(new Grade());
        //     }
        //
        //     reader.Close();
        //
        //     return finalstring;
        // }
        //
        public List<Grade> GetGradeList(string school, string subjectUUID, string classUUID)
        {


            return null;
        }

       



    }
}

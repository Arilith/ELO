﻿using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ELO.SQLClasses
{
    class ClassroomSQL
    {
        private MySqlManager MySqlManager;

        private SubjectManager subjectManager;
        private ClassManager classManager;

        public ClassroomSQL()
        {
            MySqlManager = new MySqlManager();
        }

        public List<Classroom> GetClassroomListFromDatabase(string school)
        {
            MySqlCommand getClassroomCommand = new MySqlCommand($"SELECT * FROM classrooms WHERE school = '{school}'", MySqlManager.con);
            MySqlDataReader ClassroomReader = getClassroomCommand.ExecuteReader();

            List<Classroom> returnList = new List<Classroom>();

            while (ClassroomReader.Read())
            {

                string returnName = ClassroomReader["name"].ToString();
                int returnFloor = Convert.ToInt32(ClassroomReader["floor"]);
                bool returnAvailable = Convert.ToBoolean(ClassroomReader["available"]);
                string returnUUID = ClassroomReader["UUID"].ToString();

                returnList.Add(new Classroom(returnName, returnFloor, returnAvailable, returnUUID));

            }

            ClassroomReader.Close();

            return returnList;
        }

        public void AddClassroomToDB(string name, string floor, string available, string UUID)
        {
            MySqlCommand addClassroomCommand = new MySqlCommand($"INSERT INTO classrooms (name, floor, available, UUID) VALUES ({name}, {floor}, {available}, {UUID})", MySqlManager.con);
            addClassroomCommand.ExecuteNonQuery();
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ELO.SQLClasses
{
    public class AppointmentSQL
    {
        // managers aanroepen
        private MySqlManager mySqlManager;

        private SubjectManager subjectManager;
        private ClassManager classManager;
        private ClassroomMan classroomManager;
        private UserMan userManager;
        private HwMan homeworkManager;
        private SchoolManager schoolMan;
        private ExamMan examManager;
        private string UUID;

        public List<Appointment> GetAppointmentList(string school, string _classUUID)
        {
            mySqlManager = new MySqlManager();

            // connecties met de dadabase aanmaken
            subjectManager = new SubjectManager();
            classManager = new ClassManager();
            userManager = new UserMan();
            homeworkManager = new HwMan();
            examManager = new ExamMan();

            MySqlCommand getAppointmentCommand = new MySqlCommand($"SELECT * FROM appointments WHERE school = '{school}' AND classUUID = '{_classUUID}'", mySqlManager.con);
            MySqlDataReader appointmentReader = getAppointmentCommand.ExecuteReader();

            List<Appointment> returnList = new List<Appointment>();

            while (appointmentReader.Read())
            {
                // gelezen data opslaan in variabelen
                string returnTeacher = appointmentReader["teacher"].ToString();
                string returnSubject = appointmentReader["subject"].ToString();
                string returndateAndTime = appointmentReader["dateAndTime"].ToString();
                string returnClassroom = appointmentReader["classroom"].ToString();
                string returnClass = appointmentReader["classUUID"].ToString();
                string returnSchool = appointmentReader["school"].ToString();
                bool returnCancelled = Convert.ToBoolean(appointmentReader["cancelled"]);
                string returnExamUUID = appointmentReader["ExamUUID"].ToString();
                string returnUUID = appointmentReader["UUID"].ToString();
                int returnLesUur = Convert.ToInt32(appointmentReader["lesuur"]);


                // variabelen omzetten naar objecten waar nodig
                string classRoom = returnClassroom;
                //Exam insertExam = examManager.GetExam(returnExamUUID);

                DateTime dateTime = DateTime.Parse(returndateAndTime);

                // met alle data het object appointment maken
                Appointment returnAppointment = new Appointment(returnTeacher, returnSubject, dateTime,
                    classRoom, returnClass, returnSchool, returnCancelled,
                    returnUUID, returnLesUur);

                returnList.Add(returnAppointment);
            }

            // connecties sluiten na gebruik
            subjectManager = null;
            classManager = null;
            userManager = null;
            homeworkManager = null;
            //examManager = null;

            appointmentReader.Close();

            mySqlManager.con.Close();
            mySqlManager = null;

            return returnList;
        }

        // appointment aan database toevoegen
        public void AddAppointmentToDatabase(string teacher, string subject, string dateTime, string classroom, string classUUID, string school, string UUID, int lesUur)
        {
            mySqlManager = new MySqlManager();

            string sql = "INSERT INTO appointments (teacher, subject, dateandTime, classroom, classUUID, school, UUID, lesuur) VALUES (@teacher, @subject, @dateandTime, @classroom, @classUUID, @school, @UUID, @lesUur)";

            MySqlCommand addAppointmentCommand = new MySqlCommand(sql, mySqlManager.con);

            // de variabelen aan de goede kolom in de database linken
            addAppointmentCommand.Parameters.AddWithValue("@teacher", teacher);
            addAppointmentCommand.Parameters.AddWithValue("@subject", subject);
            addAppointmentCommand.Parameters.AddWithValue("@dateandTime", dateTime);
            addAppointmentCommand.Parameters.AddWithValue("@classroom", classroom);
            addAppointmentCommand.Parameters.AddWithValue("@classUUID", classUUID);
            addAppointmentCommand.Parameters.AddWithValue("@school", school);
            addAppointmentCommand.Parameters.AddWithValue("@UUID", UUID);
            addAppointmentCommand.Parameters.AddWithValue("@lesuur", lesUur);

            // de data invoeren in de database
            addAppointmentCommand.Prepare();
            addAppointmentCommand.ExecuteNonQuery();

            mySqlManager.con.Close();
            mySqlManager = null;
        }
    }
}
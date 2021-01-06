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
                string returnTeacherUUID = appointmentReader["teacherUUID"].ToString();
                string returnSubjectUUID = appointmentReader["subjectUUID"].ToString();
                string returndateAndTime = appointmentReader["dateAndTime"].ToString();
                string returnClassroom = appointmentReader["classroomUUID"].ToString();
                string returnClassUUID = appointmentReader["classUUID"].ToString();
                string returnSchool = appointmentReader["school"].ToString();
                string returnHomeworkUUID = appointmentReader["homeworkUUID"].ToString();
                bool returnCancelled = Convert.ToBoolean(appointmentReader["cancelled"]);
                string returnExamUUID = appointmentReader["ExamUUID"].ToString();
                string returnUUID = appointmentReader["UUID"].ToString();

                // variabelen omzetten naar objecten waar nodig
                Teacher insertTeacher = (Teacher)userManager.FindUserInDataBase(returnTeacherUUID);
                Subject insertSubject = subjectManager.FindSubjectInDatabase(returnSubjectUUID);
                string classRoom = returnClassroom;
                Class insertClass = classManager.GetClassFromDatabase(returnClassUUID);
                Homework insertHomework = homeworkManager.GetHomeworkFromDB(returnHomeworkUUID);
                //Exam insertExam = examManager.GetExam(returnExamUUID);

                // met alle data het object appointment maken
                Appointment returnAppointment = new Appointment(insertTeacher, insertSubject, returndateAndTime,
                    classRoom, insertClass, returnSchool, insertHomework, returnCancelled,
                    returnUUID);

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
        public void AddAppointmentToDatabase(string teacherUUID, string subjectUUID, string dateTime, string classroomUUID, string classUUID, string school, string UUID)
        {
            mySqlManager = new MySqlManager();

            string sql = "INSERT INTO appointments (teacherUUID, subjectUUID, dateandTime, classroomUUID, classUUID, school, UUID) VALUES (@teacherUUID, @subjectUUID, @dateandTime, @classroomUUID, @classUUID, @school, @UUID)";

            MySqlCommand addAppointmentCommand = new MySqlCommand(sql, mySqlManager.con);

            // de variabelen aan de goede kolom in de database linken
            addAppointmentCommand.Parameters.AddWithValue("@teacherUUID", teacherUUID);
            addAppointmentCommand.Parameters.AddWithValue("@subjectUUID", subjectUUID);
            addAppointmentCommand.Parameters.AddWithValue("@dateandTime", dateTime);
            addAppointmentCommand.Parameters.AddWithValue("@classroomUUID", classroomUUID);
            addAppointmentCommand.Parameters.AddWithValue("@classUUID", classUUID);
            addAppointmentCommand.Parameters.AddWithValue("@school", school);
            addAppointmentCommand.Parameters.AddWithValue("@UUID", UUID);

            // de data invoeren in de database
            addAppointmentCommand.Prepare();
            addAppointmentCommand.ExecuteNonQuery();

            mySqlManager.con.Close();
            mySqlManager = null;
        }
    }
}
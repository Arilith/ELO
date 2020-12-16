using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ELO.SQLClasses
{
    public class AppointmentSQL
    {
        private MySqlManager MySqlManager;
        private SubjectManager subjectManager;
        private ClassManager classManager;
        private ClassroomMan classroomManager;
        private UserMan userManager;
        private HwMan homeworkManager;
        private SchoolManager schoolMan;
        //private ExamMan examManager;

        public AppointmentSQL()
        {
            MySqlManager = new MySqlManager();
        }

        public List<Appointment> GetAppointmentList(string school, string _classUUID)
        {
            MySqlCommand getAppointmentCommand = new MySqlCommand($"SELECT * FROM appointments WHERE school = '{school}' AND classUUID = '{_classUUID}'", MySqlManager.con);
            MySqlDataReader appointmentReader = getAppointmentCommand.ExecuteReader();

            List<Appointment> returnList = new List<Appointment>();

            while (appointmentReader.Read())
            {

                string returnTeacherUUID = appointmentReader["teacherUUID"].ToString();
                string returnSubjectUUID = appointmentReader["subjectUUID"].ToString();
                string returnTime = appointmentReader["time"].ToString();
                string returnClassroomUUID = appointmentReader["classroomUUID"].ToString();
                string returnClassUUID = appointmentReader["classUUID"].ToString();
                string returnSchool = appointmentReader["school"].ToString();
                string returnHomeworkUUID = appointmentReader["homeworkUUID"].ToString();
                bool returnCancelled = Convert.ToBoolean(appointmentReader["cancelled"]);
                string returnExamUUID = appointmentReader["ExamUUID"].ToString();
                string returnUUID = appointmentReader["UUID"].ToString();


                Teacher insertTeacher = userManager.GetTeacher(returnTeacherUUID);
                Subject insertSubject = subjectManager.FindSubject(returnSubjectUUID);
                Classroom insertClassroom = classroomManager.GetClassroom(returnClassroomUUID);
                Class insertClass = classManager.GetClassFromDatabase(returnClassUUID);
                //Homework insertHomework = homeworkManager.GetHomeWork(returnHomeworkUUID);
                School insertSchool = schoolMan.GetSchool(returnSchool);
               // Exam insertExam = examManager.GetExam(returnExamUUID);

              //  returnList.Add(new Appointment(insertTeacher, insertSubject, returnTime, insertClassroom, insertClass, insertSchool, insertHomework, returnCancelled, returnExamUUID, returnUUID));

            }

            appointmentReader.Close();

            return returnList;
        }

        public void AddAppointmentToDB(string school, string title, string duedate, string content, string classUUID, string subject)
        {
            MySqlCommand addAppointmentCommand = new MySqlCommand($"INSERT INTO appointments (subject, school, title, content, duedate, classUUID, subject) VALUES ({subject}, {school}, {title}, {content}, {duedate}, {classUUID}, {subject})", MySqlManager.con);
            addAppointmentCommand.ExecuteNonQuery();
        }
    }
}

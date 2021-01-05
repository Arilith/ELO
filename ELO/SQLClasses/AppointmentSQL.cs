using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ELO.SQLClasses
{
    public class AppointmentSQL
    {
        private MySqlManager mySqlManager;
        private SubjectManager subjectManager;
        private ClassManager classManager;
        private ClassroomMan classroomManager;
        private UserMan userManager;
        private HwMan homeworkManager;
        private SchoolManager schoolMan;
        private ExamMan examManager;
        private string UUID;

        public AppointmentSQL()
        {
            mySqlManager = new MySqlManager();
        }

        public List<Appointment> GetAppointmentList(string school, string _classUUID)
        {
            MySqlCommand getAppointmentCommand = new MySqlCommand($"SELECT * FROM appointments WHERE school = '{school}' AND classUUID = '{_classUUID}'", mySqlManager.con);
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
                Homework insertHomework = homeworkManager.GetHomework(returnHomeworkUUID);
                School insertSchool = schoolMan.GetSchool(returnSchool);
                Exam insertExam = examManager.GetExam(returnExamUUID);

                returnList.Add(new Appointment(insertTeacher, insertSubject, returnTime, insertClassroom, insertClass, insertSchool, insertHomework, returnCancelled, insertExam, returnUUID));

            }

            appointmentReader.Close();

            return returnList;
        }

        public void AddAppointmentToDatabase(string teacherUUID, string subjectUUID, string dateTime, string classroomUUID, string classUUID, string school, string UUID)
        {
            string sql =
                "INSERT INTO appointments (teacherUUID, subjectUUID, dateandTime, classroomUUID, classUUID, school, UUID) VALUES (@teacherUUID, @subjectUUID, @dateandTime, @classroomUUID, @classUUID, @school, @UUID)";

            MySqlCommand addAppointmentCommand = new MySqlCommand(sql, mySqlManager.con);

            addAppointmentCommand.Parameters.AddWithValue("@teacherUUID", teacherUUID);
            addAppointmentCommand.Parameters.AddWithValue("@subjectUUID", subjectUUID);
            addAppointmentCommand.Parameters.AddWithValue("@dateandTime", dateTime);
            addAppointmentCommand.Parameters.AddWithValue("@classroomUUID", classroomUUID);
            addAppointmentCommand.Parameters.AddWithValue("@classUUID", classUUID);
            addAppointmentCommand.Parameters.AddWithValue("@school", school);
            addAppointmentCommand.Parameters.AddWithValue("@UUID", UUID);

            addAppointmentCommand.Prepare();
            addAppointmentCommand.ExecuteNonQuery();
        }
    }
}

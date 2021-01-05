using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO
{
    public class TodayMan
    {
        private SubjectManager subjectManager;
        private UserMan userMan;
        private ClassroomMan classroomMan;
        
        public static List<Appointment> AppointmentList { get; private set; }
        public string UUID { get; private set; }

        private AppointmentSQL appointmentSql;

        public TodayMan()
        {
            AppointmentList = new List<Appointment>();
            UUID = new Random().Next().ToString() + DateTime.Now.ToString("ddmmYYYhhiiss");
            
            subjectManager = new SubjectManager();
            userMan = new UserMan();
            classroomMan = new ClassroomMan();
        }

        public void AddAppointment(Teacher teacher, Subject subject, string time, Classroom classroom, Class _class, Homework homework, bool cancelled, Exam exam)
        {
           // Appointment Appointment = new Appointment(teacher, subject, time, classroom, _class, homework, cancelled, exam);
            //AppointmentList.Add(Appointment);
        }

        public void AddAppointment(string teacherUUID, string subjectUUID, string dateTime, string classroomUUID, string classUUID, string school)
        {
            Teacher insertTeacher = userMan.GetTeacher(teacherUUID);
            Subject insertSubject = subjectManager.FindSubject(subjectUUID);
            Classroom insertClassroom = classroomMan.GetClassroom(classroomUUID);
            Class insertClass = Manager.classMan.GetClass(classUUID);
            
            
            appointmentSql.AddAppointmentToDatabase(teacherUUID, subjectUUID, dateTime,  classroomUUID,  classUUID,  school, UUID);
        }

        public void GetAppointmentListFromDatabase(string school, string _classUUID)
        {
           appointmentSql.GetAppointmentList(school, _classUUID);
        }
    }
}

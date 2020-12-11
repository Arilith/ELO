using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace ELO.SQLClasses
{
    public class UserSQL
    {

        private ClassManager classManager;
        private UserMan userManager;
        private SubjectManager subjectManager;

        private string date;
        private string userUUID;
        public UserSQL()
        { 
            classManager = new ClassManager(); 
            //userManager = new UserMan();
            subjectManager = new SubjectManager();

            date = DateTime.Now.ToString();
            userUUID = new Random().Next().ToString() + DateTime.Now.ToString("ddMMYYYYhhiiss");
        }

        public string ReadUser()
        {
            return MySqlManager.con.ServerVersion;
        }

        public string GetUserList()
        {
            string finalstring = "";

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users", MySqlManager.con);
            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                finalstring += "Row: " + reader.GetInt32(0) + "Username:" + reader.GetString(1);
            }

            reader.Close();

            return finalstring;
        }

        public SysAdmin AddAdmin(string username, string password, string school, string name, string email)
        {
            string AddAdminSQL = "INSERT INTO users(username, password, email, registrationdate, role, name, uuid, school) VALUES (@username, @password, @email, @registrationdate, @role, @name, @uuid, @school)";
            MySqlCommand AddAdminCommand;

            AddAdminCommand = new MySqlCommand(AddAdminSQL, MySqlManager.con);

            AddAdminCommand.Parameters.AddWithValue("@username", username);
            AddAdminCommand.Parameters.AddWithValue("@password", password);
            AddAdminCommand.Parameters.AddWithValue("@email", email);
            AddAdminCommand.Parameters.AddWithValue("@registrationdate", date);
            AddAdminCommand.Parameters.AddWithValue("@role", "SysAdmin");
            AddAdminCommand.Parameters.AddWithValue("@name", name);
            AddAdminCommand.Parameters.AddWithValue("@uuid", userUUID);
            AddAdminCommand.Parameters.AddWithValue("@school", school);

            AddAdminCommand.Prepare();
            AddAdminCommand.ExecuteNonQuery();

            return new SysAdmin(name, 0, school, "SysAdmin", userUUID, date, username, email);

        }

        public Teacher AddTeacher(string username, string password, string school, string name, string email)
        {

            string addTeacherSQL = "INSERT INTO users(username, password, email, registrationdate, role, name, uuid, school) VALUES (@username, @password, @email, @registrationdate, @role, @name, @uuid, @school)";
            MySqlCommand addTeacherCommand;

            addTeacherCommand = new MySqlCommand(addTeacherSQL, MySqlManager.con);

            addTeacherCommand.Parameters.AddWithValue("@username", username);
            addTeacherCommand.Parameters.AddWithValue("@password", password);
            addTeacherCommand.Parameters.AddWithValue("@email", email);
            addTeacherCommand.Parameters.AddWithValue("@registrationdate", date);
            addTeacherCommand.Parameters.AddWithValue("@role", "Teacher");
            addTeacherCommand.Parameters.AddWithValue("@name", name);
            addTeacherCommand.Parameters.AddWithValue("@uuid", userUUID);
            addTeacherCommand.Parameters.AddWithValue("@school", school);

            addTeacherCommand.Prepare();
            addTeacherCommand.ExecuteNonQuery();

            return new Teacher(name, 0, school, "Teacher", userUUID, date, username, email);

        }

        

        public Student AddStudent(string username, string password, int leerlingnummer, string school, string name, string email, string classUUID, string mentorUUID)
        {

            string addStudentSql = "INSERT INTO users(username, leerlingnummer, password, email, registrationdate, role, name, uuid, school, classUUID, mentorUUID) VALUES (@username, @leerlingnummer, @password, @email, @registrationdate, @role, @name, @uuid, @school, @classUUID, @mentorUUID)";
            MySqlCommand addStudentCommand;

            addStudentCommand = new MySqlCommand(addStudentSql, MySqlManager.con);

            addStudentCommand.Parameters.AddWithValue("@leerlingnummer", leerlingnummer);
            addStudentCommand.Parameters.AddWithValue("@username", username);
            addStudentCommand.Parameters.AddWithValue("@password", password);
            addStudentCommand.Parameters.AddWithValue("@email", email);
            addStudentCommand.Parameters.AddWithValue("@registrationdate", date);
            addStudentCommand.Parameters.AddWithValue("@role", "Student");
            addStudentCommand.Parameters.AddWithValue("@name", name);
            addStudentCommand.Parameters.AddWithValue("@uuid", userUUID);
            addStudentCommand.Parameters.AddWithValue("@school", school);
            addStudentCommand.Parameters.AddWithValue("@classUUID", classUUID);
            addStudentCommand.Parameters.AddWithValue("@mentorUUID", mentorUUID);

            addStudentCommand.Prepare();
            addStudentCommand.ExecuteNonQuery();


            Class returnClass = classManager.GetClassFromDatabase(classUUID);
            Teacher mentorTeacher = (Teacher)FindUserInDataBase(mentorUUID);

            return new Student(name, 0, school, "Student", returnClass, mentorTeacher, userUUID, leerlingnummer, date, username, email);

        }

        public Person FindUserInDataBase(string uuid)
        {
            string findUserSql = $"SELECT * FROM users WHERE uuid = '" + uuid + "'";
            MySqlCommand findUserCommand = new MySqlCommand(findUserSql, MySqlManager.con);

            MySqlDataReader reader = findUserCommand.ExecuteReader();

            if (reader.Read())
            {
                
                string returnName = reader["name"].ToString();
                string returnUsername = reader["username"].ToString();
                int returnAge = Convert.ToInt32(reader["age"]);
                string returnType = reader["role"].ToString();
                string returnSchool = reader["school"].ToString();
                string returnUserId = Convert.ToString(reader["uuid"]);
                string returnRegistrationdate = reader["registrationdate"].ToString();
                string returnEmail = reader["email"].ToString();
                int returnLeerlingnummer = Convert.ToInt32(reader["leerlingnummer"]);
                //TO BE DONE
                string returnClassUUID = reader["className"].ToString();
                string returnSubjectUUID = reader["subjectUUID"].ToString();
                string returnMentorUUID = reader["mentorUUID"].ToString();

                Class returnClass = classManager.GetClass(returnClassUUID);
                Teacher returnTeacher = (Teacher)FindUserInDataBase(returnMentorUUID);
                Subject returnSubject = subjectManager.FindSubjectInDatabase(returnSubjectUUID);
                reader.Close();

                if(returnType == "Student")
                    return new Student(returnName, returnAge, returnSchool, "Student", returnClass, returnTeacher, returnUserId, returnLeerlingnummer, returnRegistrationdate, returnUsername, returnEmail);
                if(returnType == "Teacher")
                    return new Teacher(returnName, returnAge, returnSchool, "Teacher", returnSubject, returnClass, returnUserId, returnRegistrationdate, returnUsername, returnEmail);
                if(returnType == "SysAdmin")
                    return new SysAdmin(returnName, returnAge, returnSchool, "SysAdmin", returnUserId, returnRegistrationdate, returnUsername, returnEmail);
            }

            return null;
        }

        public Person FindUserInDataBase(string username, string password, int leerlingnummer, string school, string type)
        {

            if (type == "SysAdmin")
            {
                string findUserSql = $"SELECT * FROM users WHERE username='{username}' AND password='{password}' AND school = '{school}'";
                MySqlCommand findUserCommand = new MySqlCommand(findUserSql, MySqlManager.con);

                MySqlDataReader reader = findUserCommand.ExecuteReader();

                if (reader.Read())
                {
                    string returnUsername = reader["username"].ToString();
                    string returnName = reader["name"].ToString();
                    int returnAge = Convert.ToInt32(reader["age"]);
                    string returnType = reader["role"].ToString();
                    string returnSchool = reader["school"].ToString();
                    string returnUserId = Convert.ToString(reader["uuid"]);
                    string returnRegistrationdate = reader["registrationdate"].ToString();
                    string email = reader["email"].ToString();
                    //TO BE DONE
                    string mentorClass = reader["classUUID"].ToString();
                    //string subject = reader["subjectUUID"].ToString();

                    reader.Close();

                    if(returnType == "SysAdmin")
                        return new SysAdmin(returnName, returnAge, returnSchool, returnType, returnUserId, returnRegistrationdate, returnUsername, email);
                    else if(returnType == "Teacher")
                        return new Teacher(returnName, returnAge, returnSchool, returnType, returnUserId, returnRegistrationdate, returnUsername, email);

                }

                reader.Close();
            } else if (type == "Student")
            {
                string findUserSql = $"SELECT * FROM users WHERE leerlingnummer='{leerlingnummer}' AND password='{password}' AND school = '{school}'";
                MySqlCommand findUserCommand = new MySqlCommand(findUserSql, MySqlManager.con);

                MySqlDataReader reader = findUserCommand.ExecuteReader();

                string finalstring = "";

                if (reader.Read())
                {
                    string returnUsername = reader["username"].ToString();
                    string returnName = reader["name"].ToString();
                    int returnAge = Convert.ToInt32(reader["age"]);
                    string returnType = reader["role"].ToString();
                    string returnSchool = reader["school"].ToString();
                    string returnUserId = Convert.ToString(reader["uuid"]);
                    int returnLeerlingNummer = Convert.ToInt32(reader["leerlingnummer"]);
                    string returnRegistrationdate = reader["registrationdate"].ToString();
                    string email = reader["email"].ToString();
                    Class returnClass = classManager.GetClassFromDatabase(reader["classUUID"].ToString());
                    Teacher returnTeacher = (Teacher)FindUserInDataBase(reader["classUUID"].ToString());

                    reader.Close();
                    return new Student(returnName, returnAge, returnSchool, returnType, returnClass, returnTeacher, returnUserId, returnLeerlingNummer, returnRegistrationdate, returnUsername, email);
                }

                reader.Close();
            } 
            

            return null;
        }
        
    }
}

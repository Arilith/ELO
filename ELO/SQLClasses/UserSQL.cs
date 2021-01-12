using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ELO.SQLClasses
{
    public class UserSQL
    {

        private UserMan userManager;
        private SubjectManager subjectManager;
        private MySqlManager mySqlManager;
        private string date;
        private string userUUID;

        public UserSQL()
        {
            //userManager = new UserMan();
            subjectManager = new SubjectManager();

            date = DateTime.Now.ToString();
            userUUID = new Random().Next().ToString() + DateTime.Now.ToString("O");
        }

        public List<Person> GetList(string school, string type)
        {
            ClassManager classManager = new ClassManager();
            mySqlManager = new MySqlManager();

            List<Person> returnList = new List<Person>();

            MySqlCommand getStudentsCommand = new MySqlCommand("SELECT * FROM users WHERE role = '" + type + "' AND school = '" + school + "'", mySqlManager.con);
            MySqlDataReader Studentsreader = getStudentsCommand.ExecuteReader();

            while (Studentsreader.Read())
            {
                string returnName = Studentsreader["name"].ToString();
                string returnUsername = Studentsreader["username"].ToString();
                int returnAge = Convert.ToInt32(Studentsreader["age"]);
                string returnType = Studentsreader["role"].ToString();
                string returnSchool = Studentsreader["school"].ToString();
                string returnUserId = Convert.ToString(Studentsreader["uuid"]);
                string returnRegistrationdate = Studentsreader["registrationdate"].ToString();
                string returnEmail = Studentsreader["email"].ToString();
                int returnLeerlingnummer = Convert.ToInt32(Studentsreader["leerlingnummer"]);
                //TO BE DONE
                string returnClassUUID = Studentsreader["classUUID"].ToString();
                string returnSubjectUUID = Studentsreader["subjectUUID"].ToString();
                string returnMentorUUID = Studentsreader["mentorUUID"].ToString();
                int returnExp = Convert.ToInt32(Studentsreader["exp"]);

                Class returnClass = classManager.GetClassFromDatabase(returnClassUUID);
                Teacher returnTeacher = (Teacher)new UserSQL().FindUserInDataBase(returnMentorUUID);
                Subject returnSubject = subjectManager.FindSubjectInDatabase(returnSubjectUUID);

                if (returnType == "Student")
                    returnList.Add(new Student(returnName, returnAge, returnSchool, "Student", returnClass, returnTeacher, returnUserId, returnLeerlingnummer, returnRegistrationdate, returnUsername, returnEmail, returnExp));
                if (returnType == "Teacher")
                    returnList.Add(new Teacher(returnName, returnAge, returnSchool, "Teacher", returnSubject, returnClass, returnUserId, returnRegistrationdate, returnUsername, returnEmail, returnExp));
                if (returnType == "SysAdmin")
                    returnList.Add(new SysAdmin(returnName, returnAge, returnSchool, "SysAdmin", returnUserId, returnRegistrationdate, returnUsername, returnEmail, returnExp));
            }

            classManager = null;
            mySqlManager.con.Close();
            mySqlManager = null;

            return returnList;
        }

        public List<Person> GetUserList(string type, string school)
        {
            mySqlManager = new MySqlManager();
            userManager = new UserMan();

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM users WHERE role = '{type}' AND school = '{school}'", mySqlManager.con);
            MySqlDataReader reader = cmd.ExecuteReader();

            List<Person> returnList = new List<Person>();

            while (reader.Read())
            {
                string userUUID = reader["uuid"].ToString();

                returnList.Add(userManager.FindUserInDataBase(userUUID));
            }

            reader.Close();

            mySqlManager.con.Close();
            mySqlManager = null;

            return returnList;
        }

        public SysAdmin AddAdmin(string username, string password, string school, string name, string email, int exp)
        {
            mySqlManager = new MySqlManager();

            string AddAdminSQL = "INSERT INTO users(username, password, email, registrationdate, role, name, uuid, school, exp) VALUES (@username, @password, @email, @registrationdate, @role, @name, @uuid, @school, @exp)";
            MySqlCommand AddAdminCommand;

            AddAdminCommand = new MySqlCommand(AddAdminSQL, mySqlManager.con);

            AddAdminCommand.Parameters.AddWithValue("@username", username);
            AddAdminCommand.Parameters.AddWithValue("@password", password.CreateMD5());
            AddAdminCommand.Parameters.AddWithValue("@email", email);
            AddAdminCommand.Parameters.AddWithValue("@registrationdate", date);
            AddAdminCommand.Parameters.AddWithValue("@role", "SysAdmin");
            AddAdminCommand.Parameters.AddWithValue("@name", name);
            AddAdminCommand.Parameters.AddWithValue("@uuid", userUUID);
            AddAdminCommand.Parameters.AddWithValue("@school", school);
            AddAdminCommand.Parameters.AddWithValue("@exp", exp);

            AddAdminCommand.Prepare();
            AddAdminCommand.ExecuteNonQuery();

            mySqlManager.con.Close();
            mySqlManager = null;

            return new SysAdmin(name, 0, school, "SysAdmin", userUUID, date, username, email, exp);
        }

        public Teacher AddTeacher(string username, string password, string school, string name, string email, int exp)
        {
            mySqlManager = new MySqlManager();

            string addTeacherSQL = "INSERT INTO users(username, password, email, registrationdate, role, name, uuid, school, exp) VALUES (@username, @password, @email, @registrationdate, @role, @name, @uuid, @school, @exp)";
            MySqlCommand addTeacherCommand;

            addTeacherCommand = new MySqlCommand(addTeacherSQL, mySqlManager.con);

            addTeacherCommand.Parameters.AddWithValue("@username", username);
            addTeacherCommand.Parameters.AddWithValue("@password", password.CreateMD5());
            addTeacherCommand.Parameters.AddWithValue("@email", email);
            addTeacherCommand.Parameters.AddWithValue("@registrationdate", date);
            addTeacherCommand.Parameters.AddWithValue("@role", "Teacher");
            addTeacherCommand.Parameters.AddWithValue("@name", name);
            addTeacherCommand.Parameters.AddWithValue("@uuid", userUUID);
            addTeacherCommand.Parameters.AddWithValue("@school", school);
            addTeacherCommand.Parameters.AddWithValue("@exp", exp);

            addTeacherCommand.Prepare();
            addTeacherCommand.ExecuteNonQuery();

            mySqlManager.con.Close();
            mySqlManager = null;

            return new Teacher(name, 0, school, "Teacher", userUUID, date, username, email, exp);
        }

        public Student AddStudent(string username, string password, int leerlingnummer, string school, string name, string email, string classUUID, string mentorUUID, int exp)
        {
            mySqlManager = new MySqlManager();
            ClassManager classManager = new ClassManager();

            string addStudentSql = "INSERT INTO users(username, leerlingnummer, password, email, registrationdate, role, name, uuid, school, classUUID, mentorUUID, exp) VALUES (@username, @leerlingnummer, @password, @email, @registrationdate, @role, @name, @uuid, @school, @classUUID, @mentorUUID, @exp)";
            MySqlCommand addStudentCommand;

            addStudentCommand = new MySqlCommand(addStudentSql, mySqlManager.con);

            addStudentCommand.Parameters.AddWithValue("@leerlingnummer", leerlingnummer);
            addStudentCommand.Parameters.AddWithValue("@username", username);
            addStudentCommand.Parameters.AddWithValue("@password", password.CreateMD5());
            addStudentCommand.Parameters.AddWithValue("@email", email);
            addStudentCommand.Parameters.AddWithValue("@registrationdate", date);
            addStudentCommand.Parameters.AddWithValue("@role", "Student");
            addStudentCommand.Parameters.AddWithValue("@name", name);
            addStudentCommand.Parameters.AddWithValue("@uuid", userUUID);
            addStudentCommand.Parameters.AddWithValue("@school", school);
            addStudentCommand.Parameters.AddWithValue("@classUUID", classUUID);
            addStudentCommand.Parameters.AddWithValue("@mentorUUID", mentorUUID);
            addStudentCommand.Parameters.AddWithValue("@exp", exp);

            addStudentCommand.Prepare();
            addStudentCommand.ExecuteNonQuery();

            Class returnClass = classManager.GetClassFromDatabase(classUUID);
            Teacher mentorTeacher = (Teacher)FindUserInDataBase(mentorUUID);

            classManager = null;
            mySqlManager.con.Close();
            mySqlManager = null;

            return new Student(name, 0, school, "Student", returnClass, mentorTeacher, userUUID, leerlingnummer, date, username, email, exp);
        }

        public Person FindUserInDataBase(string uuid)
        {
            mySqlManager = new MySqlManager();
            ClassManager classManager = new ClassManager();

            string findUserSql = $"SELECT * FROM users WHERE uuid = '{uuid}'";
            MySqlCommand findUserCommand = new MySqlCommand(findUserSql, mySqlManager.con);

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
                string returnClassUUID = reader["classUUID"].ToString();
                string returnSubjectUUID = reader["subjectUUID"].ToString();
                string returnMentorUUID = reader["mentorUUID"].ToString();
                int returnExp = Convert.ToInt32(reader["exp"]);

                reader.Close();

                Class returnClass = classManager.GetClassFromDatabase(returnClassUUID);
                Teacher returnTeacher = (Teacher)FindUserInDataBase(returnMentorUUID);
                Subject returnSubject = subjectManager.FindSubjectInDatabase(returnSubjectUUID);

                //mySqlManager.con.Close();
                //mySqlManager = null;

                if (returnType == "Student")
                    return new Student(returnName, returnAge, returnSchool, "Student", returnClass, returnTeacher, returnUserId, returnLeerlingnummer, returnRegistrationdate, returnUsername, returnEmail, returnExp);
                if (returnType == "Teacher")
                    return new Teacher(returnName, returnAge, returnSchool, "Teacher", returnSubject, returnClass, returnUserId, returnRegistrationdate, returnUsername, returnEmail, returnExp);
                if (returnType == "SysAdmin")
                    return new SysAdmin(returnName, returnAge, returnSchool, "SysAdmin", returnUserId, returnRegistrationdate, returnUsername, returnEmail, returnExp);
            }

            reader.Close();

            classManager = null;

            return null;
        }

        public Person FindUserInDataBase(string username, string password, int leerlingnummer, string school, string type)
        {
            mySqlManager = new MySqlManager();

            password = password.CreateMD5();

            if (type == "SysAdmin")
            {
                string findUserSql = $"SELECT * FROM users WHERE username='{username}' AND password='{password}' AND school = '{school}'";
                MySqlCommand findUserCommand = new MySqlCommand(findUserSql, mySqlManager.con);

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
                    int returnExp = Convert.ToInt32(reader["exp"]);

                    reader.Close();
                    mySqlManager.con.Close();
                    mySqlManager = null;
                    if (returnType == "SysAdmin")
                        return new SysAdmin(returnName, returnAge, returnSchool, returnType, returnUserId, returnRegistrationdate, returnUsername, email, returnExp);
                    else if (returnType == "Teacher")
                        return new Teacher(returnName, returnAge, returnSchool, returnType, returnUserId, returnRegistrationdate, returnUsername, email, returnExp);
                }

                reader.Close();
                mySqlManager.con.Close();
                mySqlManager = null;
            }
            else if (type == "Student")
            {
                string findUserSql = $"SELECT * FROM users WHERE leerlingnummer='{leerlingnummer}' AND password='{password}' AND school = '{school}'";
                MySqlCommand findUserCommand = new MySqlCommand(findUserSql, mySqlManager.con);

                MySqlDataReader reader = findUserCommand.ExecuteReader();

                string finalstring = "";

                ClassManager classManager = new ClassManager();

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

                    string classUUID = reader["classUUID"].ToString();
                    int exp = Convert.ToInt32(reader["exp"]);

                    reader.Close();
                    mySqlManager.con.Close();
                    mySqlManager = null;

                    Class returnClass = classManager.GetClassFromDatabase(classUUID);
                    Teacher returnTeacher = (Teacher)FindUserInDataBase(classUUID);

                    return new Student(returnName, returnAge, returnSchool, returnType, returnClass, returnTeacher, returnUserId, returnLeerlingNummer, returnRegistrationdate, returnUsername, email, exp);
                }

                classManager = null;
                mySqlManager.con.Close();
                mySqlManager = null;
                reader.Close();
            }

            return null;
        }

        public List<Student> FindStudentsInClass(string classUUID)
        {
            mySqlManager = new MySqlManager();
            ClassManager classManager = new ClassManager();
            string findStudents = $"SELECT * FROM users WHERE classUUID='{classUUID}'";
            MySqlCommand findStudentsCommand = new MySqlCommand(findStudents, mySqlManager.con);
            // reader activeren
            MySqlDataReader reader = findStudentsCommand.ExecuteReader();
            List<Student> returnList = new List<Student>();
            // tijdens het lezen van data in de lijst zetten
            while (reader.Read())
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
                int exp = Convert.ToInt32(reader["exp"]);

                Class returnClass = classManager.GetClassFromDatabase(classUUID);
                Teacher returnTeacher = (Teacher)FindUserInDataBase(classUUID);

                returnList.Add(new Student(returnName, returnAge, returnSchool, returnType, returnClass, returnTeacher, returnUserId, returnLeerlingNummer, returnRegistrationdate, returnUsername, email, exp));
            }

            reader.Close();
            mySqlManager.con.Close();
            mySqlManager = null;
            classManager = null;

            return returnList;
        }
    }
}
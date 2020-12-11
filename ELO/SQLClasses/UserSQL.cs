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
        private string date;
        private string userUUID;
        public UserSQL()
        { 
            classManager = new ClassManager(); 
            //userManager = new UserMan();

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

        // public Student AddStudent(string username, string password, int leerlingnummer, string school, string type, string name, string email, string className, string mentorName)
        // {
        //
        // }
        //
        // public Teacher AddTeacher(string username, string password, string school, string type, string name, string email, string mentorClass)
        // {
        //
        // }
        //
        // public Person AddUser(string username, string password, int leerlingnummer, string school, string type, string name, string email, string className, string mentorName)
        // {
        //     string AddUserSQL = "INSERT INTO users(username, password, email, registrationdate, role, name, uuid, leerlingnummer, className, mentorName) VALUES (@username, @password, @email, @registrationdate, @role, @uuid, @leerlingnummer, @className, @mentorName)";
        //     MySqlCommand AddUserCommand;
        //
        //     
        //
        //
        //
        //     AddUserCommand = new MySqlCommand(AddUserSQL, MySqlManager.con);
        //     AddUserCommand.Parameters.AddWithValue("@username", username);
        //     AddUserCommand.Parameters.AddWithValue("@password", password);
        //     AddUserCommand.Parameters.AddWithValue("@email", email);
        //     AddUserCommand.Parameters.AddWithValue("@registrationdate", date);
        //     AddUserCommand.Parameters.AddWithValue("@role", type);
        //     AddUserCommand.Parameters.AddWithValue("@name", name);
        //     AddUserCommand.Parameters.AddWithValue("@leerlingnummer", userUUID);
        //     AddUserCommand.Parameters.AddWithValue("@className", userUUID);
        //     AddUserCommand.Parameters.AddWithValue("@mentorName", userUUID);
        //     
        //     AddUserCommand.Prepare();
        //     AddUserCommand.ExecuteNonQuery();
        //
        //
        //     if (type == "Leerling")
        //     {
        //         Class studentClass = classManager.GetClass(className);
        //         Teacher mentorTeacher = userManager.GetTeacher(mentorName);
        //         return new Student(name, 0, school, type, studentClass, mentorTeacher, userUUID, leerlingnummer, date, username, email);
        //     }
        //         
        //     if(type == "SysAdmin")
        //         return new SysAdmin();
        //     if(type == "Teacher")
        //         return new Teacher();
        // }

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

                    reader.Close();
                    return new SysAdmin(returnName, returnAge, returnSchool, returnType, returnUserId, returnRegistrationdate, returnUsername, email);
                }

                reader.Close();
            } else if (type == "Leerling")
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
                    Class returnClass = Manager.classMan.GetClass(reader["className"].ToString());
                    Teacher returnTeacher = Manager.userMan.GetTeacher(reader["mentorName"].ToString());

                    reader.Close();
                    return new Student(returnName, returnAge, returnSchool, returnType, returnClass, returnTeacher, returnUserId, returnLeerlingNummer, returnRegistrationdate, returnUsername, email);
                }

                reader.Close();
            } else if (type == "Teacher")
            {

            }
            

            return null;
        }
        
    }
}

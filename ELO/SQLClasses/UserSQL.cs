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

        public UserSQL()
        {
          
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

        public void AddUser(string name, string password, string email, string date, string role)
        {
            string AddUserSQL = "INSERT INTO users(username, password, email, registrationdate, role) VALUES (@username, @password, @email, @registrationdate, @role)";
            MySqlCommand AddUserCommand;

            AddUserCommand = new MySqlCommand(AddUserSQL, MySqlManager.con);
            AddUserCommand.Parameters.AddWithValue("@username", name);
            AddUserCommand.Parameters.AddWithValue("@password", password);
            AddUserCommand.Parameters.AddWithValue("@email", email);
            AddUserCommand.Parameters.AddWithValue("@registrationdate", date);
            AddUserCommand.Parameters.AddWithValue("@role", role);

            AddUserCommand.Prepare();
            AddUserCommand.ExecuteNonQuery();
        }

        public SysAdmin FindUserInDataBase(string username, string password, string school)
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
                int returnUserId = Convert.ToInt32(reader["userId"]);
                string returnRegistrationdate = reader["registrationdate"].ToString();

                reader.Close();
                return new SysAdmin(returnName, returnAge, returnSchool, returnType, returnUserId, returnRegistrationdate, returnUsername);
            }

            reader.Close();

            return null;
        }

        public Student FindUserInDataBase(int leerlingnummer, string password, string school)
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
                int returnUserId = Convert.ToInt32(reader["Id"]);
                int returnLeerlingNummer = Convert.ToInt32(reader["leerlingnummer"]);
                string returnRegistrationdate = reader["registrationdate"].ToString();
                Class returnClass = Manager.classMan.GetClass(reader["className"].ToString());
                Teacher returnTeacher = Manager.userMan.GetTeacher(reader["mentorName"].ToString());

                reader.Close();
                return new Student(returnName, returnAge, returnSchool, returnType, returnClass, returnTeacher, returnUserId, returnLeerlingNummer, returnRegistrationdate, returnUsername);
            }

            reader.Close();

            return null;
        }

    }
}

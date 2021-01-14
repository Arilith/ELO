using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ELO.SQLClasses
{
    public class FileSQL
    {
        private MySqlManager mySqlManager;

        public FileSQL()
        {

        }


        public File UploadFile(File fileToUpload)
        {
            string uploadFileQuery = $"INSERT INTO file (fileName, filePath, studentUUID, homeworkUUID, subjectUUID) VALUES (@fileName, @filePath, @studentUUID, @homeworkUUID, @subjectUUID)";
            mySqlManager = new MySqlManager();
            MySqlCommand uploadFileCommand = new MySqlCommand(uploadFileQuery, mySqlManager.con);

            uploadFileCommand.Parameters.AddWithValue("@fileName", fileToUpload.FileName);
            uploadFileCommand.Parameters.AddWithValue("@filePath", fileToUpload.FilePath);
            uploadFileCommand.Parameters.AddWithValue("@studentUUID", fileToUpload.Student.UserId);
            uploadFileCommand.Parameters.AddWithValue("@homeworkUUID", fileToUpload.Homework.UUID);
            uploadFileCommand.Parameters.AddWithValue("@subjectUUID", fileToUpload.Homework.Subject.uuid);

            uploadFileCommand.Prepare();
            uploadFileCommand.ExecuteNonQuery();

            mySqlManager.con.Close();
            mySqlManager = null;

            return fileToUpload;
        }

        public List<File> GetFileListForSubject(Subject subject)
        {
            //Get the files for this specific homework.
            string readFilesOfSubject = $"SELECT * FROM file WHERE subjectUUID = '{subject.uuid}'";
            mySqlManager = new MySqlManager();
            MySqlCommand getFileCommand = new MySqlCommand(readFilesOfSubject, mySqlManager.con);
            MySqlDataReader getFileReader = getFileCommand.ExecuteReader();

            List<File> returnFiles = new List<File>();

            while (getFileReader.Read())
            {
                returnFiles.Add(MakeFileFromReader(getFileReader, true));
            }

            mySqlManager.con.Close();
            mySqlManager = null;
            return returnFiles;
        }

        public List<File> GetFileListByHomework(string homeworkUUID)
        {
            //Get the files for this specific homework.
            string readFilesOfHomework = $"SELECT * FROM file WHERE homeworkUUID = '{homeworkUUID}'";
            mySqlManager = new MySqlManager();
            MySqlCommand getFileCommand = new MySqlCommand(readFilesOfHomework, mySqlManager.con);
            MySqlDataReader getFileReader = getFileCommand.ExecuteReader();

            List<File> returnFiles = new List<File>();

            while (getFileReader.Read())
            {
                returnFiles.Add(MakeFileFromReader(getFileReader, true));
            }

            mySqlManager.con.Close();
            mySqlManager = null;
            return returnFiles;
        }



        public List<File> GetFileListByUser(string userUUID)
        {
            //Get the files for this specific homework.
            string readFilesOfHomework = $"SELECT * FROM file WHERE studentUUID = '{userUUID}'";

            mySqlManager = new MySqlManager();

            MySqlCommand getFileCommand = new MySqlCommand(readFilesOfHomework, mySqlManager.con);
            MySqlDataReader getFileReader = getFileCommand.ExecuteReader();

            List<File> returnFiles = new List<File>();

            while (getFileReader.Read())
            {
                returnFiles.Add(MakeFileFromReader(getFileReader, true));
            }

            mySqlManager.con.Close();
            mySqlManager = null;
            return returnFiles;
        }

        public File GetFile(string filePath)
        {
            // get files from database
            string getFileQuery = $"SELECT * FROM file WHERE filePath = '{filePath}'";

            mySqlManager = new MySqlManager();
            MySqlCommand getFileCommand = new MySqlCommand(getFileQuery, mySqlManager.con);
            MySqlDataReader getFileReader = getFileCommand.ExecuteReader();

            List<File> returnFiles = new List<File>();

            if (getFileReader.Read())
            {
                return MakeFileFromReader(getFileReader, true);
            }

            mySqlManager.con.Close();
            mySqlManager = null;
            return null;
        }

        public File MakeFileFromReader(MySqlDataReader reader, bool withHomework)
        {

            UserMan userMan = new UserMan();
            HwMan homeworkMan = new HwMan();
            SubjectManager subjectManager = new SubjectManager();

            string fileName = Convert.ToString(reader["fileName"]);
            string filePath = Convert.ToString(reader["filePath"]);
            string fileUploadDate = Convert.ToString(reader["uploadDate"]); ;
            Student fileStudent = (Student)userMan.FindUserInDataBase(Convert.ToString(reader["studentUUID"]));
            Homework fileHomework = homeworkMan.GetHomeworkFromDB(Convert.ToString(reader["homeworkUUID"]));
            Subject fileSubject = subjectManager.FindSubjectInDatabase(Convert.ToString(reader["subjectUUID"]));
            userMan = null;
            homeworkMan = null;

            if (withHomework)
                return new File(fileName, filePath, fileStudent, fileUploadDate, fileHomework);
            else
                return new File(fileName, filePath, fileStudent, fileUploadDate);
        }
    }
}

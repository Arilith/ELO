using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ELO.SQLClasses
{
    public class FileSQL
    {
        private MySqlManager mysqlManager;

        public FileSQL()
        {

        }


        public File UploadFile(File fileToUpload)
        {
            string uploadFileQuery = $"INSERT INTO file (fileName, filePath, studentUUID, homeworkUUID) VALUES (@fileName, @filePath, @studentUUID, @homeworkUUID)";
            mysqlManager = new MySqlManager();
            MySqlCommand uploadFileCommand = new MySqlCommand(uploadFileQuery, mysqlManager.con);

            uploadFileCommand.Parameters.AddWithValue("@fileName", fileToUpload.FileName);
            uploadFileCommand.Parameters.AddWithValue("@filePath", fileToUpload.FilePath);
            uploadFileCommand.Parameters.AddWithValue("@studentUUID", fileToUpload.Student.UserId);
            uploadFileCommand.Parameters.AddWithValue("@homeworkUUID", fileToUpload.Homework.UUID);

            uploadFileCommand.Prepare();
            uploadFileCommand.ExecuteNonQuery();


            return fileToUpload;
        }

        public List<File> GetFileListByHomework(string homeworkUUID)
        {
            //Get the files for this specific homework.
            string readFilesOfHomework = $"SELECT * FROM file WHERE homeworkUUID = '{homeworkUUID}'";
            mysqlManager = new MySqlManager();
            MySqlCommand getFileCommand = new MySqlCommand(readFilesOfHomework, mysqlManager.con);
            MySqlDataReader getFileReader = getFileCommand.ExecuteReader();

            List<File> returnFiles = new List<File>();

            while (getFileReader.Read())
            {
                returnFiles.Add(MakeFileFromReader(getFileReader, true));
            }

            return returnFiles;
        }

        public File GetFile(string filePath)
        {
            // get files from database
            string getFileQuery = $"SELECT * FROM file WHERE filePath = '{filePath}'";

            mysqlManager = new MySqlManager();
            MySqlCommand getFileCommand = new MySqlCommand(getFileQuery, mysqlManager.con);
            MySqlDataReader getFileReader = getFileCommand.ExecuteReader();

            List<File> returnFiles = new List<File>();

            while (getFileReader.Read())
            {
                returnFiles.Add(MakeFileFromReader(getFileReader, false));
            }

            throw new NotImplementedException();
        }

        public File MakeFileFromReader(MySqlDataReader reader, bool withHomework)
        {

            UserMan userMan = new UserMan();
            HwMan homeworkMan = new HwMan();

            string fileName = Convert.ToString(reader["fileName"]);
            string filePath = Convert.ToString(reader["filePath"]);
            string fileUploadDate = Convert.ToString(reader["uploadDate"]); ;
            Student fileStudent = (Student)userMan.FindUserInDataBase(Convert.ToString(reader["studentUUID"]));
            Homework fileHomework = homeworkMan.GetHomeworkFromDB(Convert.ToString(reader["homeworkUUID"]));

            userMan = null;
            homeworkMan = null;

            if (withHomework)
                return new File(fileName, filePath, fileStudent, fileUploadDate, fileHomework);
            else
                return new File(fileName, filePath, fileStudent, fileUploadDate);
        }

    }
}

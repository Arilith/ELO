using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using ELO.SQLClasses;

namespace ELO
{
    public class FileManager
    {
        public List<File> files { get; private set; }

        private FileSQL fileSql;
        private HwMan homeworkManager;

        public FileManager()
        {
            fileSql = new FileSQL();
        }

        public File GetFileFromDatabase(string filePath)
        {
            return fileSql.GetFile(filePath);
        }

        public void UploadFile(string fileName, string homeworkUUID, Person loggedInPerson)
        {

            string filePath = "/UploadedFiles/" + fileName;

            Homework assignedHomework = homeworkManager.GetHomeworkFromDB(homeworkUUID);

            File fileToUpload;

            if (homeworkUUID != null)
                fileToUpload = new File(fileName, filePath, (Student)loggedInPerson, assignedHomework);
            else
                fileToUpload = new File(fileName, filePath, (Student)loggedInPerson);

            fileSql.UploadFile(fileToUpload);
        }


        public List<File> GetFileListForHomework(string homeworkUUID)
        {
            return fileSql.GetFileListByHomework(homeworkUUID);
        }

    }
}

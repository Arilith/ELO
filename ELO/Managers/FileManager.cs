﻿using System;
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

        public void UploadFile(string fileName, Homework homework, Person loggedInPerson)
        {

            string filePath = "/UploadedFiles/" + fileName;

            File fileToUpload;

            if (homework != null)
                fileToUpload = new File(fileName, filePath, (Student)loggedInPerson, homework);
            else
                fileToUpload = new File(fileName, filePath, (Student)loggedInPerson);

            fileSql.UploadFile(fileToUpload);
        }


        public List<File> GetFileListForHomework(string homeworkUUID)
        {
            return fileSql.GetFileListByHomework(homeworkUUID);
        }

        public List<File> GetFileListForSubject(Subject subject)
        {
            return fileSql.GetFileListForSubject(subject);
        }

        public List<File> GetFileListByUser(string userUUID)
        {
            return fileSql.GetFileListByUser(userUUID);
        }

    }
}

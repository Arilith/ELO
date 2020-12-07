using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    
    public class File
    {
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public Student Student { get; private set; }

        public string UploadDate { get; private set; }

        public File(string fileName, string filePath, Student student, string uploadDate)
        {
            this.FileName = fileName;
            this.FilePath = filePath;
            this.Student = student;
            this.UploadDate = uploadDate;
        }
        //Temporary overload
        public File(string fileName, string filePath, string uploadDate)
        {
            this.FileName = fileName;
            this.FilePath = filePath; 
            this.UploadDate = uploadDate;
        }

    }
}

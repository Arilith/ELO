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

        public Homework Homework { get; private set; }

        // Als de upload *wel* vast zit aan een huiswerkopdracht.
        public File(string fileName, string filePath, Student student, string uploadDate, Homework homework)
        {
            this.FileName = fileName;
            this.FilePath = filePath;
            this.Student = student;
            this.UploadDate = uploadDate;
            this.Homework = homework;
        }
        // Als de upload niet vast zit aan een huiswerkopdracht.
        public File(string fileName, string filePath, Student student, string uploadDate)
        {
            this.FileName = fileName;
            this.FilePath = filePath;
            this.Student = student;
            this.UploadDate = uploadDate;
        }

        // Als de upload aangemaakt word, hoef je geen datum aan te geven, dat doet de database.
        public File(string fileName, string filePath, Student student)
        {
            this.FileName = fileName;
            this.FilePath = filePath;
            this.Student = student;
        }

        // Als de upload aangemaakt word, hoef je geen datum aan te geven, dat doet de database, wel met huiswerk.
        public File(string fileName, string filePath, Student student, Homework homework)
        {
            this.FileName = fileName;
            this.FilePath = filePath;
            this.Student = student;
            this.Homework = homework;
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

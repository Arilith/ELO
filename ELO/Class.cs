using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Class
    {
        public string Name { get; private set; }
        public int AmountOfStudents { get; private set; }
        
        public string Cluster { get; private set; }
        public string LesHuis { get; private set; }
        public string Stream { get; private set; }
        public int StudyYear { get; private set; }
        public Teacher Mentor { get; private set; }

        public Class(string name, string cluster, string leshuis, string stream, int studyYear, Teacher mentor)
        {
            this.Name = name;
            this.Cluster = cluster;
            this.LesHuis = leshuis;
            this.Stream = stream;
            this.StudyYear = studyYear;
            this.Mentor = mentor;
        }

        public Class(string name, string cluster, string leshuis, string stream, int studyYear)
        {
            this.Name = name;
            this.Cluster = cluster;
            this.LesHuis = leshuis;
            this.Stream = stream;
            this.StudyYear = studyYear;
        }

    }
}

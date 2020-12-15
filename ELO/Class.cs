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
        public string Level { get; private set; }
        public int StudyYear { get; private set; }
        public Teacher Mentor { get; private set; }

        public string UUID { get; private set; }

        public Class(string name, string cluster, string leshuis, string Level, int studyYear, Teacher mentor, string uuid)
        {
            this.Name = name;
            this.Cluster = cluster;
            this.LesHuis = leshuis;
            this.Level = Level;
            this.StudyYear = studyYear;
            this.Mentor = mentor;
            this.UUID = uuid;
        }

        public Class(string name, string cluster, string leshuis, string Level, int studyYear, string uuid)
        {
            this.Name = name;
            this.Cluster = cluster;
            this.LesHuis = leshuis;
            this.Level = Level;
            this.StudyYear = studyYear;
            this.UUID = uuid;
        }

    }
}

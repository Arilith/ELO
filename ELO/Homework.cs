 using System;
 using System.Collections.Generic;
using System.Text;

 namespace ELO
 {
    public class Homework
    {
        public string Work { get; private set; }

        public string DueDate { get; private set; }

        public string Content { get; private set; }
        public Subject Subject { get; private set; }

        public Class _class { get; }
        public string UUID { get; private set; }
        public string subjectUUID { get; private set; }


        public Homework(string work, Subject subject, string content, string dueDate, Class _class)
        {
            this.Work = work;
            this.Subject = subject;
            this.DueDate = dueDate;
            this._class = _class;
            this.Content = content;
        }

        public override string ToString()
        {
            return $"Voor klas: {_class.Name} moet voor het vak {Subject} op {DueDate}, {Work} af zijn.";
        }



    }
}
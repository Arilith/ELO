 using System;
 using System.Collections.Generic;
using System.Text;

 namespace ELO
 {
    public class Homework
    {
        public string Title { get; private set; }

        public string DueDate { get; private set; }

        public string Content { get; private set; }
        public Subject Subject { get; private set; }

        public Class _class { get; }
        public string UUID { get; private set; }
        public string subjectUUID { get; private set; }

        public int Exp { get; private set; }

        public bool IsTest { get; private set; }

        public Homework(string title, Subject subject, string content, string dueDate, Class _class, int exp, bool isTest, string uuid)
        {
            this.Title = title;
            this.Subject = subject;
            this.DueDate = dueDate;
            this._class = _class;
            this.Content = content;
            this.Exp = exp;
            this.IsTest = isTest;
            this.UUID = uuid;
        }

        public override string ToString()
        {
            return $"Voor klas: {_class.Name} moet voor het vak {Subject.Name} op {DueDate}, {Title} af zijn.";
        }



    }
}
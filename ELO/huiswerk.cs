 using System;
 using System.Collections.Generic;
using System.Text;

 namespace ELO
 {
    class huiswerk
    {
        public string Work { get; private set; }

        public string DueDate { get; private set; }

        public string Subject { get; private set; }

        public string Group { get; }

        public huiswerk(string work, string subject, string dueDate, string group)
        {
            this.Work = work;
            this.Subject = subject;
            this.DueDate = dueDate;
            this.Group = group;
        }
        public override string ToString()
        {
            return $"Voor klas: {Group} moet voor het vak {Subject} op {DueDate}, {Work} af zijn.";
        }



    }
}
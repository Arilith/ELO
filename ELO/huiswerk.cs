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

        public string Class { get; }


        private huiswerk(string work, string subject, string dueDate, string _class)
        {
            this.Work = work;
            this.Subject = subject;
            this.DueDate = dueDate;
            this.Class = _class;
        }

        public override string ToString()
        {
            return $"Voor klas: {Class} moet voor het vak {Subject} op {DueDate}, {Work} af zijn.";
        }



    }
}
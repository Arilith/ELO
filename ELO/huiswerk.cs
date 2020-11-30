 using System;
 using System.Collections.Generic;
using System.Text;

 namespace ELO
 {
    class huiswerk
    {
        public string Work { get; private set; }

        public string DueDate { get; private set; }

        public string Description { get; private set; }

        public string Group { get; }

        public huiswerk(string work, string description, string dueDate, string group)
        {
            this.Work = work;
            this.Description = description;
            this.DueDate = dueDate;
            this.Group = group;
        }
        public override string ToString()
        {
            return $"Voor klas: {Group} moet voor {DueDate} {Work} af zijn, waarbij {Description}";
        }



    }
}
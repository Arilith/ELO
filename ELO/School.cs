using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class School
    {

        public string Name { get; private set; }

        public List<SysAdmin> SysAdmins { get; private set; }
        
        public School (string name)
        {
            this.Name = name;
            this.SysAdmins = new List<SysAdmin>();
        }

    }
}

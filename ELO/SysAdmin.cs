using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class SysAdmin : Person
    {

        public SysAdmin(string name, int age, string school, string type, string userId, string registrationDate, string userName, string email, int exp) : base(name, age, school, type, userName, userId, registrationDate, email, exp)
        {
            
        }

    }
}

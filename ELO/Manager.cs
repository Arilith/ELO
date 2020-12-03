using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Manager
    {
        public static ClassManager classMan = new ClassManager();
        public static UserMan userMan = new UserMan();
		private static BookMan bookMan = new BookMan();
        public static HwMan hwMan = new HwMan();
    }


}

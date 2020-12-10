using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    class TodayMan
    {
        public static List<Appointment> AppointmentList { get; private set; }

        public TodayMan()
        {
            AppointmentList = new List<Appointment>();
        }
    }
}

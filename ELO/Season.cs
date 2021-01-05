using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Season
    {
        public DateTime StartDate { get; private set;}
        public DateTime EndDate { get; private set; }
        public string SeasonName { get; private set; }
        public string UUID { get; private set; }


        public Season(DateTime StartDate, DateTime EndDate, String SeasonName, string UUID)
        {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.SeasonName = SeasonName;
            this.UUID = UUID;
        }
    }
}

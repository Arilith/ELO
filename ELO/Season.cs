using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Season
    {
        public string StartDate { get; private set;}
        public string EndDate { get; private set; }
        public string SeasonName { get; private set; }
        public string UUID { get; private set; }


        public Season(string StartDate, string EndDate, string SeasonName, string UUID)
        {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.SeasonName = SeasonName;
            this.UUID = UUID;
        }
    }
}

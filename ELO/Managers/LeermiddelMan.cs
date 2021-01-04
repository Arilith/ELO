using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO
{
    public class LeermiddelMan
    {
        public static List<Leermiddel> leermiddellist { get; private set; }
        public LeermiddelMan()
        {
            leermiddellist = new List<Leermiddel>();
        }
        public void AddleermiddelToList(string subject, string niveau, int leerjaar, string link, string description)
        {
            leermiddellist.Add(new Leermiddel(subject, niveau, leerjaar, link, description));
        }
        public List<Leermiddel> GetLeermiddelList()
        {
            return leermiddellist;
        }
    }
}


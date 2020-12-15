using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Leermiddel
    {
        public string subject { get; private set; }
        public string niveau { get; private set; }
        public int leerjaar { get; private set; }
        public string link { get; private set; }
        public string description { get; private set; }

        public Leermiddel(string subject, string niveau, int leerjaar, string link, string description)
        {
            this.subject = subject;
            this.niveau = niveau;
            this.leerjaar = leerjaar;
            this.link = link;
            this.description = description;
        }
    }
}


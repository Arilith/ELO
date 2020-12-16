using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Exam
    {
        private string uuid;
        private Subject subject;
        private int weight;
        private Class _class;

        public Exam(string uuid, Subject subject, int weight, Class _class)
        {
            this.uuid = uuid;
            this.weight = weight;
            this.subject = subject;
            this._class = _class;
        }
    }
}

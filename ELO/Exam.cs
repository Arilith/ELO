using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    class Exam
    {
        private Subject subject;
        private int weight;
        private Class _class;

        public Exam(Subject subject, int weight, Class _class)
        {
            this.weight = weight;
            this.subject = subject;
            this._class = _class;
        }
    }
}

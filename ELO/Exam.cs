using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Exam
    {
        public string UUID { get; private set; }
        public Subject subject { get; private set; }
        public int weight { get; private set; }
        public Class _classUUID { get; private set; }
        public string school { get; private set; }

        public Exam(string uuid, Subject subject, int weight, Class _classUUID, string school)
        {
            this.UUID = uuid;
            this.weight = weight;
            this.subject = subject;
            this._classUUID = _classUUID;
            this.school = school;
        }
    }
}

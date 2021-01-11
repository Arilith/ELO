using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ELO
{
    class TeunSpithoven
    {
        // TeunSpithoven.name aanmaken
        private string name;

        // get returned zichzelf, set veranderd de waarde van zichzelf
        public string Name
        {
            // als bv: TeunSpithoven teun = new TeunSpithoven
            //         teun.Name = Teun Spithoven
            get { return name; }
            // bv Console.Println(teun.Name)
            set { name = value; }
        }

        // alles van de eerste comment tot hier doet hetzelfde als public string Name { get; set;)
        public int Age { get; set; }




        //constructor, dit is wat er gebeurt bij het aanmaken van een niewe Teun Spithoven
        public TeunSpithoven(string newName, int newAge)
        {
            // voor het gebruiken van de parameters gebruiken we this. om botsingen te voorkomen
            // TeunSpithoven.Name = name;
            name = newName;
            this.Age = newAge;
        }


        // enum heeft vaste waardes die read-only zijn
        enum Aanwezig
        {
            Niet,
            Matig,
            Redelijk,
            Goed,
            Super
        }
    }
}

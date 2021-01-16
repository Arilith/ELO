using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;

namespace ELO.Managers
{
    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CSVManager
    {
        public List<CSVStudent> ReadCSV(string fileLocation)
        {
            var reader = new StreamReader(fileLocation);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.Delimiter = ";";
            
            return csv.GetRecords<CSVStudent>().ToList();
        }

    }
}

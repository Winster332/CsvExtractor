using System.Collections.Generic;
using CsvExtractor.CsvSerialize;

namespace CsvExtractor
{
    public class Csv
    {
        public List<Table> Tables { get; set; }

        public Csv()
        {
            Tables = new List<Table>();
        }

        public Table OpenFile(string fileName)
        {
            var table = CsvSerializer.Deserialize(fileName);
            
            return table;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CsvExtractor.CsvSerialize
{
    public class CsvSerializer
    {
        public static string Serialize(Table table)
        {
            var result = "";

            table.GetCellsRows(row =>
            {
                for (var i = 0; i < row.Length; i++)
                {
                    var cell = row[i];
                    
                    if (i == row.Length-1)
                    {
                        if (cell == null)
                            result += "\n";
                        else result += $"{cell.Value.ToString()}\n";
                    }
                    else
                    {
                        if (cell == null)
                            result += ",";
                        else result += $"{cell.Value.ToString()},";
                    }
                }
            });
            result = result.Substring(0, result.Length - 1);

            return result;
        }
        
        public static bool Serialize(Table table, string fileName)
        {
            var tableString = Serialize(table);

            try
            {
                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    var writer = new StreamWriter(stream, Encoding.UTF32);
                    writer.Write(tableString);
                    writer.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }
        
        public static Table Deserialize(string fileName)
        {
            var rows = new List<List<Cell>>();
            var width = 0;
            var height = 0;
            var table = Table.Create(width, height);
            
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var reader = new StreamReader(stream);
                var line = "";

                while ((line = reader.ReadLine()) != null)
                {
                    var fields = line.Split(",");
                    var stringColumns = new string[fields.Length];
                    var listCell = new List<Cell>();

                    
                    for (var i = 0; i < fields.Length; i++)
                    {
                        stringColumns[i] = fields[i];
                        listCell.Add(new Cell(table, i, rows.Count, fields[i].Replace("\"", "")));
                    }
                    
                    if (listCell.Count > width)
                        width = listCell.Count;
                    
                    rows.Add(listCell);
                }

                height = rows.Count;

                reader.Close();
            }

            table.Width = width;
            table.Height = height;
            table.Cells = new Cell[width, height];
            
            rows.ForEach(row => table.Set(row.ToArray()));

            return table;
        }
    }
}
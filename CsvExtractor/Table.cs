using System;
using System.Collections.Generic;
using System.IO;

namespace CsvExtractor
{
    public class Table
    {
        public Cell[,] Cells { get; set; }
        public string FileName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Table()
        {
        }

        public Cell Get(int x, int y)
        {
            return Cells[x, y];
        }

        public static Table Create(int width, int height)
        {
            var table = new Table();
            table.Width = width;
            table.Height = height;
            table.Cells = new Cell[table.Width, table.Height];
            
            return table;
        }

        public void Set(params Cell[] insertCells)
        {
            foreach (var iCell in insertCells)
            {
                if (iCell != null)
                {
                    Cells[iCell.Position.X, iCell.Position.Y] = iCell;
                    Cells[iCell.Position.X, iCell.Position.Y].SetTable(this);
                }
            }
        }
        
        public void Set(int beginX, int beginY, params Cell[] insertCells)
        {
            foreach (var iCell in insertCells)
            {
                if (iCell != null)
                {
                    Cells[iCell.Position.X + beginX, iCell.Position.Y + beginY] = iCell;
                    Cells[iCell.Position.X + beginX, iCell.Position.Y + beginY].SetTable(this);
                }
            }
        }
        
        public void GetCellsRows(Action<Cell[]> action)
        {
            for (var y = 0; y < Height; y++)
            {
                var cells = new Cell[Width];
                
                for (var x = 0; x < Width; x++)
                {
                    cells[x] = Cells[x, y];
                }

                action(cells);
            }
        }
        
        public void GetCellsColumns(Action<Cell[]> action)
        {
            for (var x = 0; x < Width; x++)
            {
                var cells = new Cell[Width];
                
                for (var y = 0; y < Height; y++)
                {
                    cells[x] = Cells[x, y];
                }

                action(cells);
            }
        }
        
        public static Table Load(string fileName)
        {
            var table = new Table();
            
            var rows = new List<List<Cell>>();
            
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
                        //listCell.Add(new Cell(i, rows.Count, fields[i].Replace("\"", "")));
                    }
                    
                    rows.Add(listCell);
                }

                reader.Close();
            }

            return table;
        }
    }
}
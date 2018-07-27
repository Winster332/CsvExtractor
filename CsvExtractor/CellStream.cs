using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace CsvExtractor
{
    public enum FindType { X = 0, Y = 1, XY = 2 }
    
    public class CellStream
    {
        private Table _table;
        private Cell[,] _cells
        {
            get => _table.Cells;
        }
        private Cell _cell;
        private FindType _findType;
        private int _x_field;
        private int _y_field;
        
        public CellStream(Table table, Cell cell)
        {
            _table = table;
            _cell = cell;
            _findType = FindType.Y;
            _x_field = -1;
            _y_field = -1;
        }

        public CellStream ByX(int rowNumber)
        {
            _x_field = rowNumber-1;
            _findType = FindType.X;
            return this;
        }
        
        public CellStream ByY(int columnNumber)
        {
            _y_field = columnNumber-1;
            _findType = FindType.Y;
            return this;
        }

        public List<List<Cell>> Search()
        {
            var result = new List<List<Cell>>();

            if (_findType == FindType.Y)
            {
                for (var y = 0; y < _table.Height; y++)
                {
                    var cell = _cells[_y_field, y];

                    if (cell.Value.ToString() == _cell.Value.ToString())
                    {
                        var row = new List<Cell>();
                        for (var x = 0; x < _table.Width; x++)
                            row.Add(_table.Get(x, y));
                        
                        result.Add(row);
                    }
                }
            }

            return result;
        }

        public List<Cell> Max(int columnIndex)
        {
            columnIndex = columnIndex - 1;
            
            var result = new List<Cell>();
            var rows = Search();
            var maxValue = -1.0f;
            
            rows.ForEach(row =>
            {
                var value = row[columnIndex].ToFloat();

                if (value > maxValue)
                {
                    maxValue = value;
                    result = row;
                }
            });
            
            return result;
        }

        public List<Cell> WithoutDoublicate()
        {
            var dictColumns = new Dictionary<object, Cell>();
            var result = new List<Cell>();

            if (_findType == FindType.Y)
            {
                for (var y = 0; y < _table.Height; y++)
                {
                    var cell = _cells[_y_field, y];

                    if (!dictColumns.ContainsKey(cell.Value))
                    {
                        dictColumns.Add(cell.Value, cell);
                        result.Add(cell);
                    }
                }
            }

            return result;
        }
        
        public List<Cell> Min(int columnIndex)
        {
            columnIndex = columnIndex - 1;
            
            var result = new List<Cell>();
            var rows = Search();
            var maxValue = float.MaxValue;
            
            rows.ForEach(row =>
            {
                var value = row[columnIndex].ToFloat();

                if (value < maxValue)
                {
                    maxValue = value;
                    result = row;
                }
            });
            
            return result;
        }
        
        public float Sum(int columnIndex)
        {
            columnIndex = columnIndex - 1;
            var result = 0.0f;

            var rows = Search();
            
            rows.ForEach(row =>
            {
                try
                {
                    result += row[columnIndex].ToFloat();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                }
            });

            return result;
        }
        
        public float Average(int columnIndex)
        {
            columnIndex = columnIndex - 1;
            var result = 0.0f;

            var rows = Search();
            var count = 0;
            
            rows.ForEach(row =>
            {
                try
                {
                    result += row[columnIndex].ToFloat();
                    count++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                }
            });

            return result / count;
        }
        
        public CellStream ByXY()
        {
            _findType = FindType.XY;
            return this;
        }

        public Cell GetCell()
        {
            return _cell;
        }
    }
}
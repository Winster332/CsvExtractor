using System;
using CsvExtractor.CsvSerialize;
using Xunit;

namespace CsvExtractor.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestCreateWithCell()
        {
            var table = Table.Create(3, 3);
            table.Set(new Cell(0, 0, "index"), new Cell(1, 0, "name"), new Cell(2, 0, "address"),
                      new Cell(0, 1, "1"),     new Cell(1, 1, "Stas"), new Cell(2, 1, "127.0.0.1"),
                      new Cell(0, 2, "2"),     new Cell(1, 2, "Ury"),  new Cell(2, 2, "192.168.0.1"));

            var textTable = CsvSerializer.Serialize(table, "test_table.csv");

            var oldTable = CsvSerializer.Deserialize("test_table.csv");
        }
        
        [Fact]
        public void TestCreateSearch()
        {
            var table = Table.Create(3, 6);
            table.Set(new Cell(0, 0, "index"), new Cell(1, 0, "name"),   new Cell(2, 0, "address"),
                      new Cell(0, 1, "1"),     new Cell(1, 1, "Stas"),   new Cell(2, 1, "127.0.0.1"),
                      new Cell(0, 2, "2"),     new Cell(1, 2, "Ury"),    new Cell(2, 2, "177.168.44.1"),
                      new Cell(0, 3, "3"),     new Cell(1, 3, "Agata"),  new Cell(2, 3, "98.44.168.1"),
                      new Cell(0, 4, "4"),     new Cell(1, 4, "Ury"),    new Cell(2, 4, "1.1.1.1"),
                      new Cell(0, 5, "5"),     new Cell(1, 5, "May"),    new Cell(2, 5, "192.168.0.1"));

            var result = table.Get(1, 2).Stream().ByY(2).Search();
        }
        
        [Fact]
        public void TestCreateSum()
        {
            var table = Table.Create(3, 6);
            table.Set(new Cell(0, 0, "index"), new Cell(1, 0, "name"),   new Cell(2, 0, "address"),
                      new Cell(0, 1, "1"),     new Cell(1, 1, "Stas"),   new Cell(2, 1, "127.0.0.1"),
                      new Cell(0, 2, "2"),     new Cell(1, 2, "Ury"),    new Cell(2, 2, "177.168.44.1"),
                      new Cell(0, 3, "3"),     new Cell(1, 3, "Agata"),  new Cell(2, 3, "98.44.168.1"),
                      new Cell(0, 4, "4"),     new Cell(1, 4, "Ury"),    new Cell(2, 4, "1.1.1.1"),
                      new Cell(0, 5, "5"),     new Cell(1, 5, "May"),    new Cell(2, 5, "192.168.0.1"));

            var result = table.Get(1, 2).Stream().ByY(2).Sum(1);
        }
        
        [Fact]
        public void TestCreateAverage()
        {
            var table = Table.Create(3, 6);
            table.Set(new Cell(0, 0, "index"), new Cell(1, 0, "name"),   new Cell(2, 0, "address"),
                      new Cell(0, 1, "1"),     new Cell(1, 1, "Stas"),   new Cell(2, 1, "127.0.0.1"),
                      new Cell(0, 2, "2"),     new Cell(1, 2, "Ury"),    new Cell(2, 2, "177.168.44.1"),
                      new Cell(0, 3, "3"),     new Cell(1, 3, "Agata"),  new Cell(2, 3, "98.44.168.1"),
                      new Cell(0, 4, "4"),     new Cell(1, 4, "Ury"),    new Cell(2, 4, "1.1.1.1"),
                      new Cell(0, 5, "5"),     new Cell(1, 5, "May"),    new Cell(2, 5, "192.168.0.1"));

            var result = table.Get(1, 2).Stream().ByY(2).Average(1);
        }
        
        [Fact]
        public void TestCreateMax()
        {
            var table = Table.Create(3, 6);
            table.Set(new Cell(0, 0, "index"), new Cell(1, 0, "name"),   new Cell(2, 0, "address"),
                      new Cell(0, 1, "1"),     new Cell(1, 1, "Stas"),   new Cell(2, 1, "127.0.0.1"),
                      new Cell(0, 2, "2"),     new Cell(1, 2, "Ury"),    new Cell(2, 2, "177.168.44.1"),
                      new Cell(0, 3, "3"),     new Cell(1, 3, "Agata"),  new Cell(2, 3, "98.44.168.1"),
                      new Cell(0, 4, "4"),     new Cell(1, 4, "Ury"),    new Cell(2, 4, "1.1.1.1"),
                      new Cell(0, 5, "5"),     new Cell(1, 5, "May"),    new Cell(2, 5, "192.168.0.1"));

            var result = table.Get(1, 2).Stream().ByY(2).Max(1);
        }
        
        [Fact]
        public void TestCreateMin()
        {
            var table = Table.Create(3, 6);
            table.Set(new Cell(0, 0, "index"), new Cell(1, 0, "name"),   new Cell(2, 0, "address"),
                      new Cell(0, 1, "1"),     new Cell(1, 1, "Stas"),   new Cell(2, 1, "127.0.0.1"),
                      new Cell(0, 2, "2"),     new Cell(1, 2, "Ury"),    new Cell(2, 2, "177.168.44.1"),
                      new Cell(0, 3, "3"),     new Cell(1, 3, "Agata"),  new Cell(2, 3, "98.44.168.1"),
                      new Cell(0, 4, "4"),     new Cell(1, 4, "Ury"),    new Cell(2, 4, "1.1.1.1"),
                      new Cell(0, 5, "5"),     new Cell(1, 5, "May"),    new Cell(2, 5, "192.168.0.1"));

            var result = table.Get(1, 2).Stream().ByY(2).Min(1);
        }
    }
}
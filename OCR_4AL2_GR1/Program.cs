using System;
using System.Linq;

namespace OCR_4AL2_GR1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new DataParser(FileReader.GetContent("path"))
                .Parse()
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}

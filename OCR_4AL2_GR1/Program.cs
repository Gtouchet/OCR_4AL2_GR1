using System;
using System.IO;
using System.Linq;

namespace OCR_4AL2_GR1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent + OcrCodex.CODES_FILENAME;

            new DataParser(File.ReadAllLines(filePath))
                .Parse()
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}

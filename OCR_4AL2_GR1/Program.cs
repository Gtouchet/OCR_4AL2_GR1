using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace OCR_4AL2_GR1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO horrible
            string filename = "/OcrCodes.txt";
            string filePath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent + filename;

            new DataParser(new OcrConfiguration(), File.ReadAllLines(filePath))
                .Parse()
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}

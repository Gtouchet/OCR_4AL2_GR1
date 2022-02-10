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
            OcrConfiguration ocrConfig = JsonAccessor
                .GetConfiguration()
                .GetSection("OcrConfiguration")
                .Get<OcrConfiguration>();

            string filePath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent + ocrConfig.FileName;

            new DataParser(ocrConfig, File.ReadAllLines(filePath))
                .Parse()
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}

using OCR_4AL2_GR1.OcrConfigurations;
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

            try
            {
                new DataParser(new Ocr4x3Number(), File.ReadAllLines(filePath))
                    .Parse()
                    .ToList()
                    .ForEach(Console.WriteLine);
            }
            catch (UnreadableEntryException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

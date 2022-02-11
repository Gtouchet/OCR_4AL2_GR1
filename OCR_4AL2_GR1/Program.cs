using OCR_4AL2_GR1.Application;
using OCR_4AL2_GR1.Application.Exceptions;
using OCR_4AL2_GR1.OcrConfigurations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OCR_4AL2_GR1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent + "/OcrSample.ocr";
            string fileName = Path.GetFileNameWithoutExtension(filePath);

            try
            {
                List<Entry> entries = new DataParser(new Ocr4x3Number(), File.ReadAllLines(filePath)).Parse().ToList();

                FileWriter.Write(fileName, entries);
            }
            catch (UnreadableEntryException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

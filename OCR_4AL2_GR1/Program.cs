using OCR_4AL2_GR1.Application.Exceptions;
using OCR_4AL2_GR1.Application.Models;
using OCR_4AL2_GR1.Application.Parser;
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
            // Input from CLI
            string inputFilePath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent + "/OcrSample.ocr";

            string inputFileName = Path.GetFileNameWithoutExtension(inputFilePath);

            try {
                IEnumerable<Entry> entriesList = DataParser
                    .Of(new Ocr4x3Number())
                    .Parse(File.ReadAllLines(inputFilePath))
                    .ToList();

                IDictionary<string, List<Entry>> entriesDict = DataParser
                    .Of(new Ocr4x3Number())
                    .Parse(File.ReadAllLines(inputFilePath))
                    .ToDictionary();

                FileWriter.WriteEntriesInSingleFile(inputFileName, entriesList);
                FileWriter.WriteEntriesSortedInFiles(inputFileName, entriesDict);

            } catch (UnreadableEntryException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}

using OCR_4AL2_GR1.Application.Models;
using OCR_4AL2_GR1.Application.Parser;
using System;
using System.Collections.Generic;
using System.IO;

namespace OCR_4AL2_GR1.CliEngine
{
    public class ConsoleEngine
    {
        private readonly IOcrParser ocrParser;

        public ConsoleEngine(IOcrParser ocrParser)
        {
            this.ocrParser = ocrParser;
        }

        public void Run()
        {
            Console.WriteLine("Console engine started");
            Console.WriteLine("Usage: OcrAbsoluteFilePath merged|sorted");

            while (true)
            {
                Console.Write(" > ");
                string[] args = Console.ReadLine().Split(" ");

                if (args.Length > 1 && args[1].ToUpper().Equals("SORTED"))
                {
                    try
                    {
                        IDictionary<string, List<Entry>> entries = this.ocrParser.Parse(File.ReadAllLines(args[0])).ToDictionary();
                        FileWriter.WriteDictionaryInSortedFiles(Path.GetFileNameWithoutExtension(args[0]), entries);

                    } catch (FileNotFoundException e) {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    if (args.Length > 1 && !args[1].ToUpper().Equals("MERGED"))
                    {
                        Console.WriteLine($"Warning: '{args[1].ToUpper()}' is not a valid keyword, output will not be sorted");
                    }

                    try
                    {
                        IList<Entry> entries = this.ocrParser.Parse(File.ReadAllLines(args[0])).ToList();
                        FileWriter.WriteListInMergedFile(Path.GetFileNameWithoutExtension(args[0]), entries);

                    } catch (FileNotFoundException e) {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}

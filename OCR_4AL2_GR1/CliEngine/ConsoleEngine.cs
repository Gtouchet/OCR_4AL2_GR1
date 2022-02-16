using OCR_4AL2_GR1.Application.Models;
using OCR_4AL2_GR1.Application.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
            Console.WriteLine("Usage: OcrAbsoluteFolderOrFilePath merged|sorted");

            while (true)
            {
                Console.Write(" > ");
                string[] args = Regex.Replace(Console.ReadLine().Trim(), @"\s+", " ").Split(" ");

                string[] ocrContent;
                try {
                    ocrContent = this.IsFolder(args[0]) ? this.GetOcrFilesContent(args[0]) : File.ReadAllLines(args[0]);
                } catch (FileNotFoundException e) {
                    Console.WriteLine(e.Message);
                    continue;
                }

                if (args.Length > 1 && args[1].ToUpper().Equals("SORTED"))
                {
                    IDictionary<string, List<Entry>> entries = this.ocrParser.Parse(ocrContent).ToDictionary();
                    FileWriter.WriteDictionaryInSortedFiles(Path.GetFileNameWithoutExtension(args[0]), entries);
                }
                else
                {
                    if (args.Length > 1 && !args[1].ToUpper().Equals("MERGED"))
                    {
                        Console.WriteLine($"Warning: '{args[1].ToUpper()}' is not a valid keyword, output will not be sorted");
                    }
                    
                    IList<Entry> entries = this.ocrParser.Parse(ocrContent).ToList();
                    FileWriter.WriteListInMergedFile(Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(args[0])), entries);
                }
            }
        }

        private bool IsFolder(string path)
        {
            return (File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory;
        }

        private string[] GetOcrFilesContent(string folderPath)
        {
            List<string> filesContent = new List<string>();

            Directory.GetFiles(folderPath).ToList().ForEach(file =>
            {
                if (Path.GetExtension(file).Equals(".ocr"))
                {
                    filesContent.AddRange(File.ReadAllLines(file).ToList());
                }
            });

            return filesContent.ToArray();
        }
    }
}

using OCR_4AL2_GR1.Application.Exceptions;
using OCR_4AL2_GR1.Application.Models;
using OCR_4AL2_GR1.Application.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OCR_4AL2_GR1.CliEngine
{
    public class ConsoleCommandHandler
    {
        private readonly IOcrParser ocrParser;

        public ConsoleCommandHandler(IOcrParser ocrParser)
        {
            this.ocrParser = ocrParser;
        }

        public ConsoleReturnCodes Handle(string[] args)
        {
            string[] ocrContent;
            try {
                ocrContent = this.IsFolder(args[0]) ? this.GetOcrFilesContent(args[0]) : File.ReadAllLines(args[0]);

            } catch (FileNotFoundException e) {
                Console.WriteLine(e.Message);
                return ConsoleReturnCodes.FileNotFound;
            }

            if (args.Length > 1 && args[1].Trim().ToUpper().Equals("SORTED"))
            {
                IDictionary<string, List<Entry>> entries;
                try {
                    entries = this.ocrParser.Parse(ocrContent).ToDictionary();

                } catch (UnreadableEntryException e) {
                    Console.WriteLine(e.Message);

                    return ConsoleReturnCodes.UnreadableFileContent;
                }
                FileWriter.WriteDictionaryInSortedFiles(Path.GetFileNameWithoutExtension(args[0]), entries);

                return ConsoleReturnCodes.SuccessSorted;
            }
            else
            {
                if (args.Length > 1 && !args[1].Trim().ToUpper().Equals("MERGED"))
                {
                    Console.WriteLine($"Warning: '{args[1].ToUpper()}' is not a valid keyword, output will be merged");
                }

                IList<Entry> entries;
                try {
                    entries = this.ocrParser.Parse(ocrContent).ToList();

                } catch (UnreadableEntryException e) {
                    Console.WriteLine(e.Message);

                    return ConsoleReturnCodes.UnreadableFileContent;
                }
                FileWriter.WriteListInMergedFile(Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(args[0])), entries);

                return ConsoleReturnCodes.SuccessMerged;
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

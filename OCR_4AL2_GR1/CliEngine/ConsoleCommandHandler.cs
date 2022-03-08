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
        private readonly int PARAMETERS_COUNT = 2;
        private readonly string SORTED_KEYWORD = "SORTED";
        private readonly string MERGED_KEYWORD = "MERGED";

        private readonly IOcrParser ocrParser;

        public ConsoleCommandHandler(IOcrParser ocrParser)
        {
            this.ocrParser = ocrParser;
        }

        public ConsoleReturnCodes Handle(string[] args)
        {
            if (args.Length != PARAMETERS_COUNT)
            {
                Console.WriteLine($"Error: wrong number of arguments in command (needs {PARAMETERS_COUNT})");

                return ConsoleReturnCodes.WrongNumberOfArguments;
            }

            string path = args[0].Trim();
            string keyword = args[1].ToUpper().Trim();

            string[] ocrContent = this.GetOcrContentFrom(path);

            if (ocrContent == null)
            {
                return ConsoleReturnCodes.FileNotFound;
            }
            
            if (args.Length > 1 && keyword.Equals(SORTED_KEYWORD))
            {
                return this.HandleSort(ocrContent, path);
            }
            else
            {
                if (args.Length > 1 && !keyword.Equals(MERGED_KEYWORD))
                {
                    Console.WriteLine($"Warning: {keyword} is not a valid keyword, output will be merged");
                }

                return this.HandleMerge(ocrContent, path);
            }
        }

        private string[] GetOcrContentFrom(string path)
        {
            try {
                return this.IsFolder(path) ?
                    this.GetOcrContentFromFilesInFolder(path) :
                    this.GetOcrContentFromSingleFile(path);

            } catch (FileNotFoundException e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private bool IsFolder(string path)
        {
            return (File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory;
        }

        private string[] GetOcrContentFromFilesInFolder(string folderPath)
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

        private string[] GetOcrContentFromSingleFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private ConsoleReturnCodes HandleSort(string[] ocrContent, string outputFilePath)
        {
            IDictionary<string, List<Entry>> entries;
            try {
                entries = this.ocrParser.Parse(ocrContent).ToDictionary();

            } catch (UnreadableEntryException e) {
                Console.WriteLine(e.Message);
                return ConsoleReturnCodes.UnreadableFileContent;
            }
            FileWriter.WriteDictionaryInSortedFiles(Path.GetFileNameWithoutExtension(outputFilePath), entries);

            return ConsoleReturnCodes.SuccessSorted;
        }

        private ConsoleReturnCodes HandleMerge(string[] ocrContent, string outputFilePath)
        {
            IList<Entry> entries;
            try {
                entries = this.ocrParser.Parse(ocrContent).ToList();

            } catch (UnreadableEntryException e) {
                Console.WriteLine(e.Message);

                return ConsoleReturnCodes.UnreadableFileContent;
            }
            FileWriter.WriteListInMergedFile(Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(outputFilePath)), entries);

            return ConsoleReturnCodes.SuccessMerged;
        }
    }
}

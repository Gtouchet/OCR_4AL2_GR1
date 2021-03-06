using OCR_4AL2_GR1.Application.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OCR_4AL2_GR1
{
    public static class FileWriter
    {
        private static string DEFAULT_OUTPUT_DIRECTORY = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent + "/Output";

        public static async void WriteListInMergedFile(string fileName, IEnumerable<Entry> entries)
        {
            if (!Directory.Exists(DEFAULT_OUTPUT_DIRECTORY))
            {
                CreateOutputDirectory();
            }

            await File.WriteAllLinesAsync(
                    Path.Combine(DEFAULT_OUTPUT_DIRECTORY, fileName + "_mergedResult.txt"),
                    entries.Select(entry => entry.ToString())
            );
        }

        public static async void WriteDictionaryInSortedFiles(string fileName, IDictionary<string, List<Entry>> entries)
        {
            if (!Directory.Exists(DEFAULT_OUTPUT_DIRECTORY))
            {
                CreateOutputDirectory();
            }

            foreach (string key in entries.Keys)
            {
                string keyword = GetStatusKeyword(key);
                await File.WriteAllLinesAsync(
                    Path.Combine(DEFAULT_OUTPUT_DIRECTORY, fileName + $"_{keyword}.txt"),
                    entries[key].Select(entry => entry.ToString())
                );
            }
        }

        private static void CreateOutputDirectory()
        {
            Directory.CreateDirectory(DEFAULT_OUTPUT_DIRECTORY);
        }

        private static string GetStatusKeyword(string key)
        {
            return key.Equals("ERR") ? "errored" : key.Equals("ILL") ? "unknown" : "authorized";
        }
    }
}

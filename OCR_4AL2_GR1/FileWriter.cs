using OCR_4AL2_GR1.Application.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OCR_4AL2_GR1
{
    public static class FileWriter
    {
        private static string DEFAULT_OUTPUT_DIRECTORY = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent + "/Output";

        public static async void WriteEntriesInSingleFile(string fileName, IEnumerable<Entry> entries)
        {
            await File.WriteAllLinesAsync(
                Path.Combine(DEFAULT_OUTPUT_DIRECTORY, fileName + "_mixedResult.txt"),
                entries.Select(entry => entry.ToString())
            );
        }

        public static async void WriteEntriesSortedInFiles(string fileName, IDictionary<string, List<Entry>> entries)
        {
            foreach (string key in entries.Keys)
            {
                string keyword = key.Equals("ERR") ? "invalidChecksum" : key.Equals("ILL") ? "unreadable" : "authorized";
                await File.WriteAllLinesAsync(
                    Path.Combine(DEFAULT_OUTPUT_DIRECTORY, fileName + $"_{keyword}.txt"),
                    entries[key].Select(entry => entry.ToString())
                );
            }
        }
    }
}

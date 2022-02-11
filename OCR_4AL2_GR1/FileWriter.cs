using OCR_4AL2_GR1.Application;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OCR_4AL2_GR1
{
    public static class FileWriter
    {
        private static string DEFAULT_OUTPUT_DIRECTORY = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent + "/Output";
        private static string RESULT_FILE_EXTENSION = "_result.txt";

        public static async void Write(string fileName, IEnumerable<Entry> entries)
        {
            await File.WriteAllLinesAsync(
                Path.Combine(DEFAULT_OUTPUT_DIRECTORY, fileName + RESULT_FILE_EXTENSION),
                entries.Select(entry => entry.ToString()).ToList()
            );
        }
    }
}

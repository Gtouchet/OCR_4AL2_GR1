
using System.Collections.Generic;

namespace OCR_4AL2_GR1
{
    public static class FileReader
    {
        public static IEnumerable<string> GetContent(string filePath)
        {
            string[] result = new string[4];

            result[0] = " _     _  _     _  _     _ ";
            result[1] = "| |  | _|| |  | _|| |  | _|";
            result[2] = "|_|  ||_ |_|  ||_ |_|  ||_ ";
            result[3] = "                           ";

            return result;
        }
    }
}

using System.Collections.Generic;

namespace OCR_4AL2_GR1
{
    public static class FileReader
    {
        public static IEnumerable<string> GetContent(string filePath)
        {
            string[] result = new string[8];

            result[0] = " _     _  _     _  _     _ ";
            result[1] = "| |  | _|| |  | _|| |  | _|";
            result[2] = "|_|  ||_ |_|  ||_ |_|  ||_ ";
            result[3] = "                           ";
            result[4] = " _     _  _     _  _     _ ";
            result[5] = "| |  | _|| |  | _|| |  | _|";
            result[6] = "|_|  | _||_|  | _||_|  | _|";
            result[7] = "                           ";

            return result;
        }
    }
}

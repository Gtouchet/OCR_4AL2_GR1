using System;
using System.Collections.Generic;

namespace OCR_4AL2_GR1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Entry> entries = new DataParser(FileReader.GetContent("path")).Parse();
            foreach (Entry entry in entries)
            {
                Console.WriteLine(entry);
            }
        }
    }
}

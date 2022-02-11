using OCR_4AL2_GR1.Application.Exceptions;
using OCR_4AL2_GR1.OcrConfigurations;
using System.Collections.Generic;

namespace OCR_4AL2_GR1.Application
{
    public class DataParser
    {
        private readonly string[] fileData;
        private readonly IOcrConfiguration configuration;

        public DataParser(IOcrConfiguration configuration, string[] fileData)
        {
            this.configuration = configuration;
            this.fileData = fileData;
        }

        public IEnumerable<Entry> Parse()
        {
            string[] entry = new string[this.configuration.CodeHeightInLines];

            for (int entryLinePosition = 0; entryLinePosition < this.fileData.Length; entryLinePosition += configuration.CodeHeightInLines)
            {
                if (this.fileData.Length - entryLinePosition < configuration.CodeHeightInLines)
                {
                    throw new UnreadableEntryException(entryLinePosition + 1);
                }

                for (int line = 0; line < this.configuration.CodeHeightInLines; line += 1)
                {
                    entry[line] = this.fileData[entryLinePosition + line];
                }

                yield return new Entry(this.configuration, entry);
            }
        }
    }
}

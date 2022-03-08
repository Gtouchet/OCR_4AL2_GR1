using OCR_4AL2_GR1.Application.Exceptions;
using OCR_4AL2_GR1.Application.Models;
using OCR_4AL2_GR1.Parser.OcrConfigurations;
using System.Collections.Generic;

namespace OCR_4AL2_GR1.Application.Parser
{
    public class OcrParser : IOcrParser, IOcrParserTo
    {
        private readonly IOcrConfiguration configuration;
        private List<Entry> entriesList;

        private OcrParser(IOcrConfiguration configuration)
        {
            this.configuration = configuration;
            this.entriesList = new List<Entry>();
        }

        public static IOcrParser Of(IOcrConfiguration configuration)
        {
            return new OcrParser(configuration);
        }

        public IOcrParserTo Parse(string[] fileData)
        {
            for (int entryLinePosition = 0; entryLinePosition < fileData.Length; entryLinePosition += this.configuration.CodeHeightInLines)
            {
                if (!this.IsNextEntryValid(fileData.Length, entryLinePosition))
                {
                    throw new UnreadableEntryException(entryLinePosition);
                }

                string[] entry = new string[this.configuration.CodeHeightInLines];

                for (int line = 0; line < this.configuration.CodeHeightInLines; line += 1)
                {
                    if (!this.IsEntryLineValid(fileData[line]))
                    {
                        throw new UnreadableEntryException(entryLinePosition + line);
                    }
                    entry[line] = fileData[entryLinePosition + line];
                }

                this.entriesList.Add(new Entry(this.configuration, entry));
            }

            return this;
        }

        public List<Entry> ToList()
        {
            return this.entriesList;
        }

        public Dictionary<string, List<Entry>> ToDictionary()
        {
            Dictionary<string, List<Entry>> entries = new Dictionary<string, List<Entry>>()
            {
                { "",    new List<Entry>() },
                { "ERR", new List<Entry>() },
                { "ILL", new List<Entry>() },
            };

            this.entriesList.ForEach(entry => entries[entry.Status].Add(entry));

            return entries;
        }

        private bool IsNextEntryValid(int fileLinesCount, int actualLineInFile)
        {
            return fileLinesCount - actualLineInFile >= this.configuration.CodeHeightInLines;
        }

        private bool IsEntryLineValid(string actualLine)
        {
            return actualLine.Length == this.configuration.CodeWidthInColumns;
        }
    }
}

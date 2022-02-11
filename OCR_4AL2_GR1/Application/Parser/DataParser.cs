using OCR_4AL2_GR1.Application.Exceptions;
using OCR_4AL2_GR1.Application.Models;
using OCR_4AL2_GR1.OcrConfigurations;
using System.Collections.Generic;

namespace OCR_4AL2_GR1.Application.Parser
{
    public class DataParser : IDataParser, IDataParserTo
    {
        private readonly IOcrConfiguration configuration;
        private List<Entry> entriesList;

        private DataParser(IOcrConfiguration configuration)
        {
            this.configuration = configuration;
            this.entriesList = new List<Entry>();
        }

        public static IDataParser Of(IOcrConfiguration configuration)
        {
            return new DataParser(configuration);
        }

        public IDataParserTo Parse(string[] fileData)
        {
            for (int entryLinePosition = 0; entryLinePosition < fileData.Length; entryLinePosition += configuration.CodeHeightInLines)
            {
                if (fileData.Length - entryLinePosition < configuration.CodeHeightInLines)
                {
                    throw new UnreadableEntryException(entryLinePosition + 1);
                }

                string[] entry = new string[configuration.CodeHeightInLines];

                for (int line = 0; line < configuration.CodeHeightInLines; line += 1)
                {
                    entry[line] = fileData[entryLinePosition + line];
                }

                this.entriesList.Add(new Entry(configuration, entry));
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
    }
}

using OCR_4AL2_GR1.OcrConfigurations;

namespace OCR_4AL2_GR1.Application
{
    public class Entry
    {
        private const char UNREADABLE_ELEMENT = '?';
        private const string INVALID_CHECKSUM_KEY = " ERR";
        private const string UNREADABLE_ELEMENT_KEY = " ILL";

        private readonly IOcrConfiguration configuration;
        private readonly string decryptedEntry;
        private readonly Checksum checksum;

        public Entry(IOcrConfiguration configuration, string[] cryptedEntry)
        {
            this.configuration = configuration;
            this.decryptedEntry = this.DecryptEntry(cryptedEntry);
            this.checksum = new Checksum(UNREADABLE_ELEMENT, this.decryptedEntry);
        }

        private string DecryptEntry(string[] cryptedEntry)
        {
            string decryptedEntry = string.Empty;

            for (int elementColumnPosition = 0; elementColumnPosition < this.configuration.CodeWidthInColumns; elementColumnPosition += this.configuration.ElementWidth)
            {
                string element = string.Empty;
                for (int line = 0; line < this.configuration.CodeHeightInLines; line += 1)
                {
                    for (int column = elementColumnPosition; column < elementColumnPosition + this.configuration.ElementWidth; column += 1)
                    {
                        element += cryptedEntry[line][column];
                    }
                }
                decryptedEntry += configuration.Codex.TryGetValue(element, out string value) ? value : UNREADABLE_ELEMENT;
            }

            return decryptedEntry;
        }

        public override string ToString()
        {
            //return this.decryptedEntry + (this.decryptedEntry.Contains(UNREADABLE_ELEMENT) ? UNREADABLE_ELEMENT_KEY : this.checksum.IsValid ? string.Empty : INVALID_CHECKSUM_KEY);

            string toString = this.decryptedEntry;

            if (this.decryptedEntry.Contains(UNREADABLE_ELEMENT))
            {
                return toString + UNREADABLE_ELEMENT_KEY;
            }

            return toString + (this.checksum.IsValid ? string.Empty : INVALID_CHECKSUM_KEY);
        }
    }
}

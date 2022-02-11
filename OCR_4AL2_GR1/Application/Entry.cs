using OCR_4AL2_GR1.OcrConfigurations;

namespace OCR_4AL2_GR1.Application
{
    public class Entry
    {
        private const char UNREADABLE_ELEMENT = '?';

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
            string decryptedEntry = "";

            for (int elementColumnPosition = 0; elementColumnPosition < this.configuration.CodeWidthInColumns; elementColumnPosition += this.configuration.ElementWidth)
            {
                string element = "";
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
            return $"Decrypted entry: {this.decryptedEntry} - Checksum: {(this.checksum.IsValid ? "valid" : "invalid")}";
        }
    }
}

using OCR_4AL2_GR1.Parser.OcrConfigurations;

namespace OCR_4AL2_GR1.Application.Models
{
    public class Entry
    {
        private readonly IOcrConfiguration configuration;
        private readonly Checksum checksum;

        public readonly string DecryptedEntry;
        public readonly string Status;

        public Entry(IOcrConfiguration configuration, string[] cryptedEntry)
        {
            this.configuration = configuration;
            this.DecryptedEntry = DecryptEntry(cryptedEntry);
            this.checksum = new Checksum(this.DecryptedEntry);
            this.Status = SetStatus();
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
                decryptedEntry += this.configuration.Codex.TryGetValue(element, out string value) ? value : "?";
            }

            return decryptedEntry;
        }

        private string SetStatus()
        {
            return this.DecryptedEntry.Contains("?") ? "ILL" : this.checksum.IsValid ? string.Empty : "ERR";
        }

        public override string ToString()
        {
            return $"{this.DecryptedEntry} {this.Status}";
        }
    }
}

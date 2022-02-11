using OCR_4AL2_GR1.OcrConfigurations;

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
            DecryptedEntry = DecryptEntry(cryptedEntry);
            checksum = new Checksum(DecryptedEntry);
            Status = SetStatus();
        }

        private string DecryptEntry(string[] cryptedEntry)
        {
            string decryptedEntry = string.Empty;

            for (int elementColumnPosition = 0; elementColumnPosition < configuration.CodeWidthInColumns; elementColumnPosition += configuration.ElementWidth)
            {
                string element = string.Empty;
                for (int line = 0; line < configuration.CodeHeightInLines; line += 1)
                {
                    for (int column = elementColumnPosition; column < elementColumnPosition + configuration.ElementWidth; column += 1)
                    {
                        element += cryptedEntry[line][column];
                    }
                }
                decryptedEntry += configuration.Codex.TryGetValue(element, out string value) ? value : "?";
            }

            return decryptedEntry;
        }

        private string SetStatus()
        {
            return DecryptedEntry.Contains("?") ? "ILL" : checksum.IsValid ? string.Empty : "ERR";
        }

        public override string ToString()
        {
            return $"{DecryptedEntry} {Status}";
        }
    }
}

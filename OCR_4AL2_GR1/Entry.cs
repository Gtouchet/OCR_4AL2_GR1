
namespace OCR_4AL2_GR1
{
    public class Entry
    {
        private readonly IOcrConfiguration configuration;
        private readonly string decryptedCode;
        private readonly Checksum checksum;

        public Entry(IOcrConfiguration configuration, string[] code)
        {
            this.configuration = configuration;
            this.decryptedCode = this.Decrypt(code);
            this.checksum = new Checksum(this.decryptedCode);
        }

        private string Decrypt(string[] code)
        {
            string decryptedCode = "";

            for (int i = 0; i < configuration.CodeWidthInColumns; i += configuration.SingleEntryWidth)
            {
                string decryptedElement = "";
                for (int line = 0; line < configuration.CodeHeightInLines; line += 1)
                {
                    for (int column = i; column < i + configuration.SingleEntryWidth; column += 1)
                    {
                        decryptedElement += code[line][column];
                    }
                }
                decryptedCode += configuration.Codex.TryGetValue(decryptedElement, out string value) ? value : "?";
            }

            return decryptedCode;
        }

        public override string ToString()
        {
            return $"Code: {this.decryptedCode} - Checksum: {(this.checksum.IsValid ? "valid" : "invalid")}";
        }
    }
}


namespace OCR_4AL2_GR1
{
    public class Entry
    {
        private readonly string DecryptedCode;
        private readonly Checksum Checksum;
        private readonly string decryptedCode;
        private readonly IOcrConfiguration configuration;

        public Entry(IOcrConfiguration configuration, string[] code)
        {
            this.DecryptedCode = this.Decrypt(code);
            this.Checksum = new Checksum(this.DecryptedCode);
            this.configuration = configuration;
            this.decryptedCode = this.Decrypt(code);            
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
                if (configuration.Codex.TryGetValue(decryptedElement, out string value))
                    decryptedCode += value;
                else
                    decryptedCode += "?";
            }

            return decryptedCode;
        }

        public override string ToString()
        {
            return $"Code: {this.DecryptedCode} - Checksum: {(this.Checksum.IsValid ? "valid" : "invalid")}";
        }
    }
}

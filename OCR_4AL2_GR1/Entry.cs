
namespace OCR_4AL2_GR1
{
    public class Entry
    {
        private readonly string DecryptedCode;
        private readonly bool IsChecksumValid;

        public Entry(string[] code)
        {
            this.DecryptedCode = this.Decrypt(code);
            this.IsChecksumValid = this.ValidateChecksum(this.DecryptedCode);
        }

        private string Decrypt(string[] code)
        {
            string decryptedCode = "";

            for (int i = 0; i < OcrCodex.CODE_COLUMN_COUNT; i += OcrCodex.COLUMN_PER_NUMBER)
            {
                string decryptedNumber = "";
                for (int line = 0; line < OcrCodex.CODE_LINE_COUNT; line += 1)
                {
                    for (int column = i; column < i + OcrCodex.COLUMN_PER_NUMBER; column += 1)
                    {
                        decryptedNumber += code[line][column];
                    }
                }
                decryptedCode += OcrCodex.CODEX.ContainsKey(decryptedNumber) ? OcrCodex.CODEX[decryptedNumber] : "?";
            }

            return decryptedCode;
        }

        private bool ValidateChecksum(string decryptedCode)
        {
            return true;
        }

        public override string ToString()
        {
            return $"Code: {this.DecryptedCode} - Checksum: {(this.IsChecksumValid ? "valid" : "invalid")}";
        }
    }
}

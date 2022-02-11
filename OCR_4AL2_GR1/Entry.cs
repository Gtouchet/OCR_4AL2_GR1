
namespace OCR_4AL2_GR1
{
    public class Entry
    {
        private readonly string decryptedCode;
        private readonly OcrConfiguration configuration;

        public Entry(OcrConfiguration configuration, string[] code)
        {
            this.configuration = configuration;
            this.decryptedCode = this.Decrypt(code);            
        }

        private string Decrypt(string[] code)
        {
            string decryptedCode = "";

            for (int i = 0; i < configuration.ColumnCount; i += configuration.ColumnPerNumber)
            {
                string decryptedNumber = "";
                for (int line = 0; line < configuration.LineCount; line += 1)
                {
                    for (int column = i; column < i + configuration.ColumnPerNumber; column += 1)
                    {
                        decryptedNumber += code[line][column];
                    }
                }
                decryptedCode += OcrCodex.CODEX.ContainsKey(decryptedNumber) ? OcrCodex.CODEX[decryptedNumber] : "?";
            }

            return decryptedCode;
        }

        public override string ToString()
        {
            return this.decryptedCode;
        }
    }
}


namespace OCR_4AL2_GR1
{
    public class Entry
    {
        private readonly string DecryptedCode;

        public Entry(string[] code)
        {
            this.DecryptedCode = this.Decrypt(code);
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

        public override string ToString()
        {
            return this.DecryptedCode;
        }
    }
}

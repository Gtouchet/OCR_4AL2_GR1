using System.Collections.Generic;

namespace OCR_4AL2_GR1
{
    public class Entry
    {
        private readonly string DecryptedCode;

        public Entry(IEnumerable<string> code)
        {
            this.DecryptedCode = this.Decrypt(code);
        }

        private string Decrypt(IEnumerable<string> code)
        {
            return "123456789";
        }

        public override string ToString()
        {
            return this.DecryptedCode;
        }
    }
}
